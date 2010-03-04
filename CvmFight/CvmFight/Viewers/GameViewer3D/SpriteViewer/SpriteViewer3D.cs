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

        private SpriteCollectionCache3D spriteCollectionCache3D;
        #endregion

        #region Constructor
        public SpriteViewer3D(int screenWidth, int screenHeight, SpritePool spritePool)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            spriteCollectionCache3D = new SpriteCollectionCache3D(spritePool);
        }
        #endregion

        #region Public Methods
        public void View(AbstractSprite viewerSprite, AbstractSprite viewedSprite, Surface mainSurface, Point[,] pointGrid)
        {
            double angle = Optics.GetSpriteAngleToSpriteRadian(viewerSprite, viewedSprite);
            double distance = Optics.GetStraightDistance(viewerSprite, viewedSprite);
            double spriteHeight = 768.0;
            int destinationX = 0;
            int destinationY = 0;

            #warning Sprite status, viewed angle and height must be parsed here (along with destinatonX and destinatonY)

            Surface spriteSurface = spriteCollectionCache3D.GetSpriteCache(viewedSprite).GetSurface(SpriteScallableFrame.Walk1, SpriteScallableFrame.Front, spriteHeight);
            mainSurface.Blit(spriteSurface, pointGrid[destinationX, destinationY]);
        }
        #endregion
    }
}
