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

        /// <summary>
        /// Manages spawning and respawning
        /// </summary>
        private Spawner spawner;
        #endregion

        #region Constructor
        public World()
        {
            Random random = new Random();

            spawner = new Spawner(random);
            currentPlayer = new Player();
            map = new WaveMap(random);
            spritePool = new SpritePool();
            spawner.TryRespawn(spritePool,map);
            spritePool.Add(currentPlayer);
        }
        #endregion

        #region Properties
        public AbstractMap Map
        {
            get { return map; }
        }

        public SpritePool SpritePool
        {
            get { return spritePool; }
        }
        #endregion
    }
}
