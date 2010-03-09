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
    class SpriteCache3D
    {
        #region Fields
        private bool isEnableSpriteCache;
        #endregion

        #region Parts
        private SpriteScallableFrame[,] internalSpriteFrameMap = new SpriteScallableFrame[32, 32];
        #endregion

        #region Constructor
        public SpriteCache3D(bool isEnableSpriteCache)
        {
            this.isEnableSpriteCache = isEnableSpriteCache;
        }
        #endregion

        #region Public Methods
        public Surface GetSurface(byte spriteStatus, byte spriteAngle, int spriteHeight)
        {
            return internalSpriteFrameMap[spriteAngle, spriteStatus].GetScaledSurface(spriteHeight, isEnableSpriteCache);
        }

        public void AddFrame(SpriteScallableFrame spriteFrame)
        {
            internalSpriteFrameMap[spriteFrame.Angle, spriteFrame.Status] = spriteFrame;
        }
        #endregion
    }
}
