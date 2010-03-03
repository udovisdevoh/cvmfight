﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    static class Optics
    {
        #region Constants
        private const double rayDistanceResolution = 0.05;
        #endregion

        #region Public Methods
        public static double FixAngleDegree(double angle)
        {
	        while (angle > 360)
		        angle -= 360;
	        while (angle < 0)
		        angle += 360;
        		
	        return angle;
        }

        public static bool IsSpriteViewable(AbstractSprite viewerSprite, AbstractSprite viewedSprite, AbstractMap map, int fov)
        {
            if (viewerSprite == viewedSprite)
                return true;


            double angleRadian = FixAngleRadian(GetSpriteAngleToSpriteRadian(viewerSprite, viewedSprite));
            double angleDegree = FixAngleDegree(angleRadian / Math.PI * 180);

            double minimumViewingAngle = viewerSprite.AngleDegree - (double)fov / 2.0;
            double maximumViewingAngle = viewerSprite.AngleDegree + (double)fov / 2.0;

            if (angleDegree < minimumViewingAngle)
                return false;
            if (angleDegree > maximumViewingAngle)
                return false;


            double xMove = Math.Cos(angleRadian) * rayDistanceResolution;
            double yMove = Math.Sin(angleRadian) * rayDistanceResolution;

            double x = viewerSprite.PositionX;
            double y = viewerSprite.PositionY;

            double xDistanceToPerform = Math.Abs(viewerSprite.PositionX - viewedSprite.PositionX);
            double yDistanceToPerform = Math.Abs(viewerSprite.PositionY - viewedSprite.PositionY);



            double xDistance = 0;
            double yDistance = 0;

            while (true)
            {
                x += xMove;
                y += yMove;

                xDistance += Math.Abs(xMove);
                yDistance += Math.Abs(yMove);

                if (map.GetMatterTypeAt(x, y) != null)
                {
                    return false;
                }

                if (x < 0 || y < 0 || x > map.Width || y > map.Height)
                {
                    return false;
                }


                if (xDistance >= xDistanceToPerform && yDistance >= yDistanceToPerform)
                {
                    return true;
                }
            }
        }

        private static double FixAngleRadian(double angle)
        {
            while (angle > Math.PI * 2)
                angle -= Math.PI * 2;
            while (angle < 0)
                angle += Math.PI * 2;

            return angle;
        }

        public static double GetSpriteAngleToSpriteRadian(AbstractSprite viewerSprite, AbstractSprite viewedSprite)
        {
            double fullVectorX = viewedSprite.PositionX - viewerSprite.PositionX;
            double fullVectorY = viewedSprite.PositionY - viewerSprite.PositionY;
            return Math.Atan2(fullVectorY, fullVectorX);
        }
        #endregion
    }
}
