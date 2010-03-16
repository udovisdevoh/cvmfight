using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    abstract class AbstractSprite : IComparable<AbstractSprite>
    {
        #region Fields
        /// <summary>
        /// Distance to a reference sprite (which could be anything)
        /// </summary>
        private double distanceToReferenceSprite;

        /// <summary>
        /// sprite's angle
        /// </summary>
        private double angleRadian = 0.0;

        /// <summary>
        /// x coordinate position
        /// </summary>
        private double positionX = 0.0;

        /// <summary>
        /// y coordinate position
        /// </summary>
        private double positionY = 0.0;
        #endregion

        #region IComparable<AbstractSprite> Members
        public int CompareTo(AbstractSprite other)
        {
            return (int)(other.distanceToReferenceSprite * 100 - distanceToReferenceSprite * 100);
        }
        #endregion

        #region Public Abstract Methods
        public abstract void Update(double timeDelta, SpritePool spritePool, AbstractMap abstractMap);
        #endregion

        #region Properties
        /// <summary>
        /// Distance to a reference sprite (which could be anything)
        /// </summary>
        public double DistanceToReferenceSprite
        {
            get { return distanceToReferenceSprite; }
            set { distanceToReferenceSprite = value; }
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
        #endregion
    }
}
