using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Primitives;

namespace CvmFight
{
    class SpriteViewer3D
    {
        #region Fields
        private int screenWidth;

        private int screenHeight;
        #endregion

        #region Constructor
        public SpriteViewer3D(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }
        #endregion

        #region Public Methods
        public void ViewSprite(AbstractSprite sprite, Surface mainSurface)
        {
        }
        #endregion
    }
}
