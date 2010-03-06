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
            double angleDegree = (Optics.GetSpriteAngleToSpriteRadian(viewerSprite, viewedSprite) - viewerSprite.AngleRadian) / Math.PI * 180.0;
            double straightDistance = Optics.GetStraightDistance(viewerSprite, viewedSprite);
            double theoreticalColumnHeight = Optics.GetColumnHeight(straightDistance, screenHeight, heightDistanceRatio);
            double topMargin = Optics.GetColumnTopMargin(screenHeight, theoreticalColumnHeight, viewerSprite.PositionZ, viewerSprite.IsCrouch);


            while (angleDegree < (viewedSprite.AngleDegree - fov / 2))
                angleDegree += 360.0;

            while (angleDegree > (viewedSprite.AngleDegree + fov / 2))
                angleDegree -= 360.0;


            //byte brightness = (byte)(columnHeight / maxColumnHeight * 255);

            int spriteHeight = (int)(theoreticalColumnHeight * 0.6);
            int destinationX = 0;
            int destinationY;

            #warning Sprite status, viewed angle and height must be parsed here (along with destinatonX and destinatonY)

            byte angleType = GetAngleType(viewerSprite.AngleDegree, viewedSprite.AngleDegree);


            Surface spriteSurface = spriteCollectionCache3D.GetSpriteCache(viewedSprite).GetSurface(SpriteScallableFrame.Walk1, angleType, spriteHeight);


            destinationX = (int)(getXPosition(angleDegree, fov, screenWidth, spriteSurface.Width));
            destinationY = (int)(topMargin + theoreticalColumnHeight - spriteSurface.Height);

            if (PointLoader.IsPositionValid(destinationX, destinationY))
                mainSurface.Blit(spriteSurface, PointLoader.GetPoint(destinationX, destinationY));
        }

        private byte GetAngleType(double viewerAngleDegree, double viewedAngleDegree)
        {          
            double relativeAngle = Optics.FixAngleDegree(viewedAngleDegree - viewerAngleDegree + 180);


            byte angleType = SpriteScallableFrame.Front;

            /*if (relativeAngle >= 337 || relativeAngle <= 22 )
                angleType = SpriteScallableFrame.Front;*/
            /*else if (relativeAngle >= 157 && relativeAngle <= 202)
                angleType = SpriteScallableFrame.Back;*/

            if (relativeAngle >= 67 && relativeAngle <= 112)
                angleType = SpriteScallableFrame.Left;
            else if (relativeAngle >= 247 && relativeAngle <= 292)
                angleType = SpriteScallableFrame.Right;


            return angleType;
        }
        #endregion

        #region Private Methods
        private double getXPosition(double angleDegree, int fov, int screenWidth, int spriteWidth)
        {
            return angleDegree / (double)(fov) * (double)(screenWidth) + ((double)(screenWidth) / 2.0) -((double)(spriteWidth) / 2.0);
        }
        #endregion
    }
}
