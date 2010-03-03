using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    /// <summary>
    /// Abstract sprite
    /// </summary>
    class AbstractSprite
    {
        #region Fields
        /// <summary>
        /// x coordinate position
        /// </summary>
        private double positionX = 0.0;

        /// <summary>
        /// y coordinate position
        /// </summary>
        private double positionY = 0.0;

        /// <summary>
        /// height from the ground
        /// </summary>
        private double positionZ = 0.0;

        /// <summary>
        /// sprite's angle
        /// </summary>
        private double angleRadian = 0.0;

        /// <summary>
        /// sprite's radius
        /// </summary>
        private double radius = 0.0;

        /// <summary>
        /// sprite's height
        /// </summary>
        private double height = 0.0;

        /// <summary>
        /// Sprite's default walking distance per tick
        /// </summary>
        private double defaultWalkingDistance = 0.1;

        /// <summary>
        /// Whether sprite is crouch
        /// </summary>
        private bool isCrouch = false;
        #endregion

        #region Properties
        /// <summary>
        /// x coordinate position
        /// </summary>
        public double PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }

        /// <summary>
        /// y coordinate position
        /// </summary>
        public double PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }

        /// <summary>
        /// z coordinate position
        /// </summary>
        public double PositionZ
        {
            get { return positionZ; }
            set { positionZ = value; }
        }

        /// <summary>
        /// Return angle in radian from -1 to 1
        /// </summary>
        public double AngleRadian
        {
            get
            {
                return angleRadian;
            }

            set
            {
                while (value >= Math.PI * 2)
                    value -= Math.PI * 2;

                while (value < 0)
                    value += Math.PI * 2;

                angleRadian = value;
            }
        }

        /// <summary>
        /// Angle in degree (from 0 to 360)
        /// </summary>
        public double AngleDegree
        {
            get
            {
                return angleRadian / Math.PI * 180.0;
            }

            set
            {
                AngleRadian = value / 180.0 * Math.PI;
            }
        }

        /// <summary>
        /// Sprite's radius
        /// </summary>
        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        /// <summary>
        /// Sprite's diameter
        /// </summary>
        public double Diameter
        {
            get { return radius * 2; }
            set { radius = value / 2; }
        }

        /// <summary>
        /// Sprite's height
        /// </summary>
        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double DefaultWalkingDistance
        {
            get { return defaultWalkingDistance; }
            set { defaultWalkingDistance = value; }
        }

        public bool IsCrouch
        {
            get { return isCrouch; }
            set { isCrouch = value; }
        }
        #endregion
    }
}
