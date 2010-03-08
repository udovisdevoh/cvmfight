using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class Player : AbstractFighter
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
            DefaultHealth = 100.0;
            Health = 0;
            MaxHealth = 200.0;
            DefaultWalkingDistance = 0.05;
            MaxJumpAcceleration = 1;
        }
        #endregion
    }
}
