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
        #region Fields and parts
        /// <summary>
        /// Current player
        /// </summary>
        private Player currentPlayer;

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

        #region Properties
        public AbstractMap Map
        {
            get { return map; }
        }
        #endregion
    }
}
