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
        #region Parts
        private SpriteFrame[,] internalSpriteFrameMap = new SpriteFrame[32, 32];
        #endregion

        #region Public Methods
        public Surface GetSurface(byte spriteStatus, byte spriteAngle, double distance, out Rectangle destinationRectangle)
        {
            internalSpriteFrameMap[spriteAngle, spriteStatus].GetScaledSurface(distance);
        }

        public void AddFrame(SpriteFrame spriteFrame)
        {
            internalSpriteFrameMap[spriteFrame.Angle, spriteFrame.Status] = spriteFrame;
        }
        #endregion
    }
}
