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
        #region Fields and parts
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
        public void View(AbstractSprite viewerSprite, AbstractSprite viewedSprite, Surface mainSurface)
        {
            double angleDegree = (Optics.GetSpriteAngleToSpriteRadian(viewerSprite, viewedSprite) - viewerSprite.AngleRadian) / Math.PI * 180.0;
            double straightDistance = Optics.GetStraightDistance(viewerSprite, viewedSprite);
            double theoreticalColumnHeight = Optics.GetColumnHeight(straightDistance, screenHeight, heightDistanceRatio);
            double topMargin = Optics.GetColumnTopMargin(screenHeight, theoreticalColumnHeight, viewerSprite.PositionZ, viewerSprite.IsCrouch);


            while (angleDegree < (0 - fov / 2))
                angleDegree += 360.0;

            while (angleDegree > (0 + fov / 2))
                angleDegree -= 360.0;


            //byte brightness = (byte)(columnHeight / maxColumnHeight * 255);

            int spriteHeight = (int)(theoreticalColumnHeight * 0.6);
            int destinationX = 0;
            int destinationY;

            

            byte angleType = GetAngleType(viewerSprite.AngleDegree, viewedSprite.AngleDegree);

            #warning Sprite status must be parsed here

            byte spriteStatus;



            int attackCycleState = viewedSprite.AttackCycle.GetCycleState();
            int receivedAttackCycleState = viewedSprite.ReceivedAttackCycle.GetCycleState();

            if (viewedSprite.IsCrouch)
            {
                if (attackCycleState == 2)
                {
                    spriteStatus = SpriteScallableFrame.Kick2;
                    spriteHeight = spriteHeight * 3 / 4;
                }
                else if (attackCycleState == 1)
                {
                    spriteStatus = SpriteScallableFrame.Kick1;
                    spriteHeight = spriteHeight * 3 / 4;
                }
                else if (receivedAttackCycleState != 0)
                {
                    spriteHeight /= 2;
                    spriteStatus = SpriteScallableFrame.CrouchHit;
                }
                else if (viewedSprite.IsBlock)
                {
                    spriteHeight /= 2;
                    spriteStatus = SpriteScallableFrame.CrouchBlock;
                }
                else
                {
                    spriteHeight /= 2;
                    spriteStatus = SpriteScallableFrame.Crouch;
                }
            }
            else
            {
                if (attackCycleState == 1)
                {
                    if (viewedSprite.PositionZ > 0)
                    {
                        spriteStatus = SpriteScallableFrame.Kick1;
                    }
                    else
                    {
                        spriteStatus = SpriteScallableFrame.Punch;
                    }
                }
                else if (attackCycleState == 2)
                {
                    if (viewedSprite.PositionZ > 0)
                    {
                        spriteStatus = SpriteScallableFrame.Kick2;
                    }
                    else
                    {
                        spriteStatus = SpriteScallableFrame.Punch;
                    }
                }
                else if (receivedAttackCycleState != 0)
                {
                    spriteStatus = SpriteScallableFrame.Hit;
                }
                else if (viewedSprite.IsBlock)
                {
                    spriteStatus = SpriteScallableFrame.Block;
                }
                else if (viewedSprite.WalkCycle.IsForward)
                {
                    spriteStatus = SpriteScallableFrame.Walk1;
                }
                else
                {
                    spriteStatus = SpriteScallableFrame.Walk2;
                }
            }


            Surface spriteSurface = spriteCollectionCache3D.GetSpriteCache(viewedSprite).GetSurface(spriteStatus, angleType, spriteHeight);

            destinationX = (int)(getXPosition(angleDegree, fov, screenWidth, spriteSurface.Width));
            destinationY = (int)(topMargin + theoreticalColumnHeight - spriteSurface.Height);

            destinationY -= (int)(viewedSprite.PositionZ * theoreticalColumnHeight / 2);

            if (PointLoader.IsPositionValid(destinationX, destinationY))
                mainSurface.Blit(spriteSurface, PointLoader.GetPoint(destinationX, destinationY));
        }

        private byte GetAngleType(double viewerAngleDegree, double viewedAngleDegree)
        {          
            double relativeAngle = Optics.FixAngleDegree(viewedAngleDegree - viewerAngleDegree + 180);


            byte angleType = SpriteScallableFrame.Front;

            /*if (relativeAngle >= 337 || relativeAngle <= 22 )
                angleType = SpriteScallableFrame.Front;
            else */if (relativeAngle >= 157 && relativeAngle <= 202)
                angleType = SpriteScallableFrame.Back;
            if (relativeAngle >= 67 && relativeAngle <= 112)
                angleType = SpriteScallableFrame.Left;
            else if (relativeAngle >= 247 && relativeAngle <= 292)
                angleType = SpriteScallableFrame.Right;
            else if (relativeAngle >= 22 && relativeAngle <= 67)
                angleType = SpriteScallableFrame.FrontLeft;
            else if (relativeAngle >= 292 && relativeAngle <= 337)
                angleType = SpriteScallableFrame.FrontRight;
            else if (relativeAngle >= 112 && relativeAngle <= 157)
                angleType = SpriteScallableFrame.BackLeft;
            else if (relativeAngle >= 202 && relativeAngle <= 247)
                angleType = SpriteScallableFrame.BackRight;

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
