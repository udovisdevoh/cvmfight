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
        #region Constants
        /// <summary>
        /// How many desired monsters
        /// </summary>
        private int monsterCount = 10;
        #endregion

        #region Fields and parts
        /// <summary>
        /// Current player
        /// </summary>
        private Player currentPlayer = new Player();

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

        /// <summary>
        /// Sprite shared consciousness
        /// </summary>
        private SharedConsciousness sharedConsciousness;

        /// <summary>
        /// Random number generator
        /// </summary>
        private Random random;
        #endregion

        #region Constructor
        public World(Random random)
        {
            this.random = random;
            spawner = new Spawner(random);
            //map = new HardCodedMap();
            //map = new CachedWaveMap(random);
            map = new MapFromImage("Assets/Maps/CvmMap.png", random);
            spritePool = new SpritePool(currentPlayer);

            sharedConsciousness = new SharedConsciousness(spritePool.Count);

            for (int i = 0; i < monsterCount; i++)
                spritePool.Add(new MonsterStickMan());

            spawner.TryRespawn(spritePool,map);
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

        public Player CurrentPlayer
        {
            get{return currentPlayer;}
        }

        public SharedConsciousness SharedConsciousness
        {
            get { return sharedConsciousness; }
        }

        public Spawner Spawner
        {
            get { return spawner; }
        }
        #endregion
    }
}