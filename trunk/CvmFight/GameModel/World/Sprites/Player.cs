﻿using System;
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
            Weight = 1.0;
            Height = 1.0;
            Radius = 0.1;
            DefaultHealth = 100.0;
            Health = DefaultHealth;
            MaxHealth = 200.0;
        }
        #endregion
    }
}