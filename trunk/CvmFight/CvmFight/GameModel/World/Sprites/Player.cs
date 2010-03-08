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
            AttackPower = 4;
            DefaultHealth = 100.0;
            Health = 0;
            MaxHealth = 200.0;
            DefaultWalkingDistance = 0.05;
            MaxJumpAcceleration = 0.83;
        }
        #endregion
    }
}
