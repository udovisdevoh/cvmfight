using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Primitives;

namespace CvmFight
{
    class SpriteScallableFrame
    {
        #region Constants
        public const byte Front = 0;
        
        public const byte Back = 1;

        public const byte Left = 2;

        public const byte Right = 3;

        public const byte FrontLeft = 4;

        public const byte FrontRight = 5;

        public const byte BackLeft = 6;

        public const byte BackRight = 7;

        public const byte Walk1 = 8;

        public const byte Walk2 = 9;

        public const byte Punch = 10;

        public const byte Kick1 = 11;

        public const byte Kick2 = 12;

        public const byte Block = 13;

        public const byte Crouch = 14;

        public const byte CrouchBlock = 15;

        public const byte CrouchHit = 16;

        public const byte Hit = 17;

        private const double MinimumSpriteHeight = 1;

        private const double MaximumSpriteHeight = 1024;

        private const double SpriteSizePrecision = 1;
        #endregion

        #region Static Members
        private static Dictionary<string, Surface> fileSurfaceCache;
        #endregion

        #region Fields and parts
        private byte angle;

        private byte status;

        private string imageFileName;

        private Dictionary<int, Surface> spriteHeightCache = new Dictionary<int, Surface>();

        private Surface originalSurface;
        #endregion

        #region Constructor
        static SpriteScallableFrame()
        {
            fileSurfaceCache = new Dictionary<string, Surface>();
        }

        public SpriteScallableFrame(byte angle, byte status, string imageFileName) : this(angle, status, imageFileName, false) { }

        public SpriteScallableFrame(byte angle, byte status, string imageFileName, bool isFlippedHorizontal)
        {
            this.angle = angle;
            this.status = status;
            this.imageFileName = imageFileName;

            if (!fileSurfaceCache.TryGetValue(imageFileName, out originalSurface))
            {
                originalSurface = new Surface(imageFileName);
                originalSurface.Alpha = 255;
                originalSurface.Transparent = true;
                fileSurfaceCache.Add(imageFileName, originalSurface);
            }

            if (isFlippedHorizontal)
                originalSurface = originalSurface.CreateFlippedHorizontalSurface();
        }
        #endregion

        #region Public Methods
        public Surface GetScaledSurface(int height)
        {
            Surface scalledSurface;

            //int key = height;
            int key = (int)Math.Sqrt((double)height * 10.0);

            if (!spriteHeightCache.TryGetValue(key, out scalledSurface))
            {
                scalledSurface = originalSurface.CreateScaledSurface(height / (double)originalSurface.Height);
                spriteHeightCache.Add(key, scalledSurface);
            }

            return scalledSurface;
        }
        #endregion

        #region Properties
        public byte Angle
        {
            get { return angle; }
        }

        public byte Status
        {
            get { return status; }
        }

        public string ImageFileName
        {
            get { return imageFileName; }
        }
        #endregion
    }
}
