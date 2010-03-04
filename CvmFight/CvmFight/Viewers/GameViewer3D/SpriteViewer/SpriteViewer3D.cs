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
    class SpriteViewer3D
    {
        #region Fields
        private int screenWidth;

        private int screenHeight;

        private SpriteCollectionCache3D spriteCollectionCache3D = new SpriteCollectionCache3D();
        #endregion

        #region Constructor
        public SpriteViewer3D(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }
        #endregion

        #region Public Methods
        public void View(AbstractSprite viewerSprite, AbstractSprite viewedSprite, Surface mainSurface)
        {
            Rectangle destinationRectangle;

            double angle = Optics.GetSpriteAngleToSpriteRadian(viewerSprite, viewedSprite);
            double distance = Optics.GetStraightDistance(viewerSprite, viewedSprite);

            Surface spriteSurface = spriteCollectionCache3D.GetSpriteCache(viewedSprite).GetSurface(angle, distance, out destinationRectangle);
            mainSurface.Blit(spriteSurface, destinationRectangle);
        }
        #endregion
    }
}
