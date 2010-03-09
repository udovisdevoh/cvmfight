using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class Player : AbstractSprite
    {
        #region Constructor
        /// <summary>
        /// Create player's sprite
        /// </summary>
        public Player()
        {
            IsAlive = false;
            Height = 1.0;
            Radius = 0.1;
            AttackRange = 0.3;
            AttackAngleRange = 0.17;
            AttackPower = 2.5;
            DefaultHealth = 100.0;
            Health = 0;
            MaxHealth = 200.0;
            MaxJumpAcceleration = 0.83;
            CrouchSpeedMultiplier = 0.2;
            DefaultWalkingDistance = 0.02;
            JumpSpeedMultiplier = 1.6;
        }
        #endregion
    }
}
