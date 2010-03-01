using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    /// <summary>
    /// Represents the world
    /// </summary>
    class World
    {
        #region Fields
        private Player currentPlayer;
        #endregion

        #region Parts
        /// <summary>
        /// Map
        /// </summary>
        private AbstractMap map;

        /// <summary>
        /// Sprite pool
        /// </summary>
        private SpritePool spritePool;
        #endregion

        #region Constructor
        public World()
        {
            currentPlayer = new Player();
            map = new HardCodedMap();
            spritePool = new SpritePool();
            spritePool.Add(currentPlayer);
        }
        #endregion
    }
}
