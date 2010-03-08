using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    /// <summary>
    /// Abstract sprite
    /// </summary>
    class AbstractSprite : IComparable<AbstractSprite>
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

        /// <summary>
        /// We multiply this to walking speed when sprite is crouch
        /// </summary>
        private double crouchSpeedMultiplier = 0.5;

        /// <summary>
        /// Distance to a reference sprite (which could be anything)
        /// </summary>
        private double distanceToReferenceSprite;

        /// <summary>
        /// Sprite's maximum jump acceleration
        /// </summary>
        private double maxJumpAcceleration = 1.0;

        /// <summary>
        /// Sprite's current jump force
        /// </summary>
        private double currentJumpAcceleration = 0.0;

        /// <summary>
        /// Whether sprite must jump again because he has no cynetic energy left
        /// </summary>
        private bool isNeedToJumpAgain = false;
        #endregion

        #region Parts
        /// <summary>
        /// Represents the sprite's attack cycle
        /// </summary>
        private SpriteActionCycle attackCycle = new SpriteActionCycle(0.2);
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

        /// <summary>
        /// Sprite's default walking distance per tick
        /// </summary>
        public double DefaultWalkingDistance
        {
            get { return defaultWalkingDistance; }
            set { defaultWalkingDistance = value; }
        }

        /// <summary>
        /// Whether sprite is crouch
        /// </summary>
        public bool IsCrouch
        {
            get { return isCrouch; }
            set { isCrouch = value; }
        }

        /// <summary>
        /// We multiply this to walking speed when sprite is crouch
        /// </summary>
        public double CrouchSpeedMultiplier
        {
            get { return crouchSpeedMultiplier; }
            set { crouchSpeedMultiplier = value; }
        }

        /// <summary>
        /// Distance to a reference sprite (which could be anything)
        /// </summary>
        public double DistanceToReferenceSprite
        {
            get { return distanceToReferenceSprite; }
            set { distanceToReferenceSprite = value; }
        }

        /// <summary>
        /// Sprite's max jump acceleration
        /// </summary>
        public double MaxJumpAcceleration
        {
            get { return maxJumpAcceleration; }
            set { maxJumpAcceleration = value; }
        }

        /// <summary>
        /// Sprite's current jump force
        /// </summary>
        public double CurrentJumpAcceleration
        {
            get { return currentJumpAcceleration; }
            set { currentJumpAcceleration = value; }
        }

        /// <summary>
        /// Whether sprite must jump again because he has no cynetic energy left
        /// </summary>
        public bool IsNeedToJumpAgain
        {
            get { return isNeedToJumpAgain; }
            set { isNeedToJumpAgain = value; }
        }

        public SpriteActionCycle AttackCycle
        {
            get { return attackCycle; }
        }

        public void Update(double timeDelta)
        {
            attackCycle.Update(timeDelta);
            Physics.MakeFall(this, timeDelta);
        }
        #endregion

        #region IComparable<AbstractSprite> Members
        public int CompareTo(AbstractSprite other)
        {
            return (int)(other.distanceToReferenceSprite * 100 - distanceToReferenceSprite * 100);
        }
        #endregion
    }
}
