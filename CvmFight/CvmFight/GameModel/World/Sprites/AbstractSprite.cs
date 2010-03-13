﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    /// <summary>
    /// Abstract sprite
    /// </summary>
    abstract class AbstractSprite : IComparable<AbstractSprite>
    {
        #region Fields
        /// <summary>
        /// Sprite's default health
        /// </summary>
        private double defaultHealth;

        /// <summary>
        /// Sprite's max health
        /// </summary>
        private double maxHealth;

        /// <summary>
        /// Sprite's health
        /// </summary>
        private double health;

        /// <summary>
        /// Frag count
        /// </summary>
        private short fragCount;

        /// <summary>
        /// Whether the sprite is alive
        /// </summary>
        private bool isAlive = false;

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

        /// <summary>
        /// Whether the sprite is blocking
        /// </summary>
        private bool isBlock = false;

        /// <summary>
        /// Sprite's strong attack power
        /// </summary>
        private double attackPowerStrong = 0.5;

        /// <summary>
        /// Sprite's fast attack power
        /// </summary>
        private double attackPowerFast = 0.15;

        /// <summary>
        /// Sprite's attack range
        /// </summary>
        private double attackRange = 0;

        /// <summary>
        /// Attack angle range
        /// </summary>
        private double attackAngleRange = 0.1;

        /// <summary>
        /// Received attack angle
        /// </summary>
        private double receivedAttackAngleRadian = 0.0;

        /// <summary>
        /// Jump speed multiplier
        /// </summary>
        private double jumpSpeedMultiplier = 1.6;

        /// <summary>
        /// When attacking, multiply the speed to something
        /// </summary>
        private double attackWalkSpeedMultiplier = 0;

        /// <summary>
        /// Frag ranking
        /// </summary>
        private int ranking = 0;

        /// <summary>
        /// Mouse look on Y axis
        /// </summary>
        private double mouseLook = 0;

        private double latestPredatorDamage = 0;

        private double attackRangeJumpMultiplier;

        private bool isJustReceivedStrongPunch = false;

        private bool isJustReceivedStrongKick = false;

        private bool isJustReceivedFastAttack = false;
        #endregion

        #region Parts
        /// <summary>
        /// Represents the sprite's strong attack cycle
        /// </summary>
        private SpriteActionCycle strongAttackCycle;

        /// <summary>
        /// Represents the sprite's fast attack cycle
        /// </summary>
        private SpriteActionCycle fastAttackCycle;

        /// <summary>
        /// Represents the sprite's received attack cycle
        /// </summary>
        private SpriteActionCycle receivedAttackCycle;

        /// <summary>
        /// When block is successful
        /// </summary>
        private SpriteActionCycle blockSuccessCycle;

        /// <summary>
        /// Walking cycle
        /// </summary>
        private SpriteActionCycle walkCycle;

        /// <summary>
        /// Represents the sprite's current AI state for what kind of movement he's doing
        /// </summary>
        private SpriteState stateMovement;

        /// <summary>
        /// Represents the sprite's current AI state for jump, crouch or normal
        /// </summary>
        private SpriteState stateJumpCrouch;

        /// <summary>
        /// Represents the sprite's current attack or block behavior
        /// </summary>
        private SpriteState stateAttackBlock;

        /// <summary>
        /// Represents the sprite's current attack or block behavior
        /// </summary>
        private SpriteState stateAttackType;

        /// <summary>
        /// Represents latest sprite which attacked this
        /// </summary>
        private AbstractSprite latestPredator;
        #endregion

        #region Constructor
        public AbstractSprite()
        {
            Height = GetHeight();
            Radius = GetRadius();
            AttackRange = GetAttackRange();
            AttackAngleRange = GetAttackAngleRange();
            AttackPowerStrong = GetAttackPowerStrong();
            AttackPowerFast = GetAttackPowerFast();
            DefaultHealth = GetDefaultHealth();
            Health = 0;
            MaxHealth = GetMaxHealth();
            MaxJumpAcceleration = GetMaxJumpAcceleration();
            CrouchSpeedMultiplier = GetCrouchSpeedMultiplier();
            DefaultWalkingDistance = GetDefaultWalkingDistance();
            JumpSpeedMultiplier = GetJumpSpeedMultiplier();
            AttackWalkSpeedMultiplier = GetAttackWalkSpeedMultiplier();
            AttackRangeJumpMultiplier = GetAttackRangeJumpMultiplier();

            stateMovement = new SpriteState(SpriteStates.Offensive, SpriteStates.Defensive, SpriteStates.FurtiveLeft, SpriteStates.FurtiveRight, 10);
            stateJumpCrouch = new SpriteState(SpriteStates.Stand, SpriteStates.Jump, SpriteStates.Crouch, SpriteStates.Stand, SpriteStates.Stand, 20);
            stateAttackBlock = new SpriteState(SpriteStates.Attack, SpriteStates.Block, SpriteStates.OpenToAttack, 30);
            stateAttackType = new SpriteState(SpriteStates.FastAttack, SpriteStates.StrongAttack, 40);

            strongAttackCycle = new SpriteActionCycle(GetStrongAttackTime());
            fastAttackCycle = new SpriteActionCycle(GetFastAttackTime());
            receivedAttackCycle = new SpriteActionCycle(GetReceivedAttackCycleLength());
            walkCycle = new SpriteActionCycle(GetWalkCycleLength());
            stateMovement = new SpriteState(SpriteStates.Offensive, SpriteStates.Offensive, SpriteStates.Offensive, SpriteStates.Defensive, SpriteStates.FurtiveLeft, SpriteStates.FurtiveRight, GetMovementCycleLength());
            stateJumpCrouch = new SpriteState(SpriteStates.Stand, SpriteStates.Jump, SpriteStates.Crouch, SpriteStates.Stand, SpriteStates.Stand, GetJumpCrouchCycleLength());
            stateAttackBlock = new SpriteState(SpriteStates.Attack, SpriteStates.Block, SpriteStates.OpenToAttack, GetStateAttackBlockCycleLength());
            blockSuccessCycle = new SpriteActionCycle(GetBlockSuccessTime());
        }
        #endregion

        #region Protected Abstract Methods
        protected abstract double GetHeight();

        protected abstract double GetRadius();

        protected abstract double GetAttackRange();

        protected abstract double GetAttackAngleRange();

        protected abstract double GetAttackPowerStrong();

        protected abstract double GetAttackPowerFast();

        protected abstract double GetDefaultHealth();

        protected abstract double GetMaxHealth();

        protected abstract double GetMaxJumpAcceleration();

        protected abstract double GetCrouchSpeedMultiplier();

        protected abstract double GetDefaultWalkingDistance();

        protected abstract double GetJumpSpeedMultiplier();

        protected abstract double GetAttackWalkSpeedMultiplier();

        protected abstract double GetStrongAttackTime();

        protected abstract double GetFastAttackTime();

        protected abstract double GetReceivedAttackCycleLength();

        protected abstract double GetWalkCycleLength();

        protected abstract double GetStateAttackBlockCycleLength();

        protected abstract double GetJumpCrouchCycleLength();

        protected abstract double GetMovementCycleLength();

        protected abstract double GetAttackRangeJumpMultiplier();

        protected abstract double GetBlockSuccessTime();
        #endregion

        #region Public Methods
        public void Update(double timeDelta, SpritePool spritePool, AbstractMap map)
        {
            isJustReceivedStrongPunch = false;
            isJustReceivedStrongKick = false;
            isJustReceivedFastAttack = false;

            strongAttackCycle.Update(timeDelta);
            fastAttackCycle.Update(timeDelta);
            blockSuccessCycle.Update(timeDelta);
            Physics.MakeFall(this, timeDelta);
        }

        public void RefreshRanking(SpritePool spritePool)
        {
            ranking = 1;
            foreach (AbstractSprite sprite in spritePool)
            {
                if (fragCount < sprite.fragCount)
                {
                    ranking++;
                }
            }
        }

        public void TryMouseLook(short mouseLookDiff)
        {
            mouseLook += ((double)mouseLookDiff / 200);
            mouseLook = Math.Min(0.5, mouseLook);
            mouseLook = Math.Max(-0.5, mouseLook);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Whether the sprite is alive
        /// </summary>
        public bool IsAlive
        {
            get { return isAlive; }
            set
            {
                isAlive = value;
                if (health <= 0.0 && isAlive)
                    health = 1;
                else if (health > 0 && !isAlive)
                    health = 0.0;
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

        public SpriteActionCycle StrongAttackCycle
        {
            get { return strongAttackCycle; }
        }

        public SpriteActionCycle FastAttackCycle
        {
            get { return fastAttackCycle; }
        }

        public SpriteActionCycle WalkCycle
        {
            get { return walkCycle; }
        }

        public bool IsBlock
        {
            get { return isBlock; }
            set { isBlock = value; }
        }

        /// <summary>
        /// Sprite's max health
        /// </summary>
        public double MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }

        /// <summary>
        /// Sprite's default health
        /// </summary>
        public double DefaultHealth
        {
            get { return defaultHealth; }
            set { defaultHealth = value; }
        }

        /// <summary>
        /// Sprite's current health
        /// </summary>
        public double Health
        {
            get { return health; }
            set
            {
                health = value;
                if (health > maxHealth)
                    health = maxHealth;
                if (health <= 0)
                    isAlive = false;
                else if (health > 0)
                    isAlive = true;
            }
        }

        /// <summary>
        /// Frag count
        /// </summary>
        public short FragCount
        {
            get { return fragCount; }
            set { fragCount = value; }
        }

        public double AttackPowerStrong
        {
            get { return attackPowerStrong; }
            set { attackPowerStrong = value; }
        }

        public double AttackPowerFast
        {
            get { return attackPowerFast; }
            set { attackPowerFast = value; }
        }

        public double AttackRange
        {
            get { return attackRange; }
            set { attackRange = value; }
        }

        public double AttackAngleRange
        {
            get { return attackAngleRange; }
            set { attackAngleRange = value; }
        }

        public double ReceivedAttackAngleRadian
        {
            get { return receivedAttackAngleRadian; }
            set { receivedAttackAngleRadian = value; }
        }

        public SpriteActionCycle ReceivedAttackCycle
        {
            get { return receivedAttackCycle; }
            set { receivedAttackCycle = value; }
        }

        public double JumpSpeedMultiplier
        {
            get { return jumpSpeedMultiplier; }
            set { jumpSpeedMultiplier = value; }
        }

        public double AttackWalkSpeedMultiplier
        {
            get { return attackWalkSpeedMultiplier; }
            set { attackWalkSpeedMultiplier = value; }
        }

        public SpriteState StateMovement
        {
            get { return stateMovement; }
            set { stateMovement = value; }
        }

        public SpriteState StateJumpCrouch
        {
            get { return stateJumpCrouch; }
        }

        public SpriteState StateAttackBlock
        {
            get { return stateAttackBlock; }
        }

        public SpriteState StateAttackType
        {
            get { return stateAttackType; }
        }

        /// <summary>
        /// Frag count ranking
        /// </summary>
        public int Ranking
        {
            get { return ranking; }
        }

        public double MouseLook
        {
            get { return mouseLook; }
        }

        public AbstractSprite LatestPredator
        {
            get { return latestPredator; }
            set { latestPredator = value; }
        }

        public double LatestPredatorDamage
        {
            get{return latestPredatorDamage;}
            set{latestPredatorDamage=value;}
        }

        public double AttackRangeJumpMultiplier
        {
            get { return attackRangeJumpMultiplier; }
            set { attackRangeJumpMultiplier = value; }
        }

        public SpriteActionCycle BlockSuccessCycle
        {
            get { return blockSuccessCycle; }
        }

        public bool IsJustReceivedStrongPunch
        {
            get { return isJustReceivedStrongPunch; }
            set { isJustReceivedStrongPunch = value; }
        }

        public bool IsJustReceivedStrongKick
        {
            get { return isJustReceivedStrongKick; }
            set { isJustReceivedStrongKick = value; }
        }

        public bool IsJustReceivedFastAttack
        {
            get { return isJustReceivedFastAttack; }
            set { isJustReceivedFastAttack = value; }
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
