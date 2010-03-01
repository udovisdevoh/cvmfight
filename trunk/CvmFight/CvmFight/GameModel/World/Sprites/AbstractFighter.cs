using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    /// <summary>
    /// Represents the player and monsters
    /// </summary>
    class AbstractFighter : AbstractSprite
    {
        #region Fields
        /// <summary>
        /// Whether the sprite is alive
        /// </summary>
        private bool isAlive;

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
        #endregion
    }
}
