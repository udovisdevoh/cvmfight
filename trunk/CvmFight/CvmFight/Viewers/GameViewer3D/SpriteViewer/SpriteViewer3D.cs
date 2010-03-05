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

        private int fov;

        private double heightDistanceRatio;

        private SpriteCollectionCache3D spriteCollectionCache3D;
        #endregion

        #region Constructor
        public SpriteViewer3D(int screenWidth, int screenHeight, SpritePool spritePool, int fov, double heightDistanceRatio)
        {
            this.heightDistanceRatio = heightDistanceRatio;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.fov = fov;
            spriteCollectionCache3D = new SpriteCollectionCache3D(spritePool);
        }
        #endregion

        #region Public Methods
        public void View(AbstractSprite viewerSprite, AbstractSprite viewedSprite, Surface mainSurface, Point[,] pointGrid)
        {
            double angleDegree = Optics.GetSpriteAngleToSpriteRadian(viewerSprite, viewedSprite) / Math.PI * 180.0;
            double straightDistance = Optics.GetStraightDistance(viewerSprite, viewedSprite);
            double theoreticalColumnHeight = Optics.GetColumnHeight(straightDistance, screenHeight, heightDistanceRatio);
            double topMargin = Optics.GetColumnTopMargin(screenHeight, theoreticalColumnHeight, viewerSprite.PositionZ, viewerSprite.IsCrouch);

            


            //byte brightness = (byte)(columnHeight / maxColumnHeight * 255);

            double spriteHeight = 768.0;
            int destinationX = 0;
            int destinationY = 0;

            #warning Sprite status, viewed angle and height must be parsed here (along with destinatonX and destinatonY)

            Surface spriteSurface = spriteCollectionCache3D.GetSpriteCache(viewedSprite).GetSurface(SpriteScallableFrame.Walk1, SpriteScallableFrame.Front, spriteHeight);


            destinationX = (int)(getXPosition(angleDegree, fov, screenWidth, spriteSurface.Width));
            destinationY = (int)topMargin;

            #warning, remove this ugly hack
            if (destinationX < 0 || destinationX > screenWidth)
                mainSurface.Blit(spriteSurface,new Point(destinationX, destinationY));
            else
                mainSurface.Blit(spriteSurface, pointGrid[destinationX, destinationY]);
        }
        #endregion

        #region Private Methods
        private double getXPosition(double angleDegree, int fov, int screenWidth, int spriteWidth)
        {
            return angleDegree / (double)(fov) * (double)(screenWidth) + ((double)(screenWidth) / 2.0) - ((double)(spriteWidth) / 2.0);
        }
        #endregion
    }
}
