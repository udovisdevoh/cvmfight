using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class SpriteFrame
    {
        #region Constants
        public const byte Front = 0;
        
        public const byte Back = 1;

        public const byte Left = 2;

        public const byte Right = 3;

        public const byte FrontLeft = 4;

        public const byte FrontRight = 5;

        public const byte BacktLeft = 6;

        public const byte BackRight = 7;

        public const byte Walk1 = 8;

        public const byte Walk2 = 9;

        public const byte Punch = 10;

        public const byte Kick1 = 11;

        public const byte Kick2 = 12;

        public const byte Block = 13;

        public const byte Crouch = 14;

        public const byte CrouchBlock = 15;

        public const byte Hit = 16;
        #endregion

        #region Fields
        private byte angle;

        private byte status;

        private string imageFileName;
        #endregion

        #region Constructor
        public SpriteFrame(byte angle, byte status, string imageFileName)
        {
            this.angle = angle;
            this.status = status;
            this.imageFileName = imageFileName;
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
