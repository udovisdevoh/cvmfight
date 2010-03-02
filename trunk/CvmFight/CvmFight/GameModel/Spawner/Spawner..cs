using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CvmFight
{
    class Spawner
    {
        #region Fields
        private AbstractMap map = null;

        private EmptyMapLocationCache emptyMapLocationCache;

        private Random random;
        #endregion

        #region Constructor
        public Spawner(Random random)
        {
            this.random = random;
        }
        #endregion

        #region Methods
        public void TryRespawn(SpritePool spritePool, AbstractMap map)
        {
            AbstractFighter fighter;
            foreach (AbstractSprite sprite in spritePool)
            {
                if (sprite is AbstractFighter)
                {
                    fighter = (AbstractFighter)sprite;
                    if (!fighter.IsAlive)
                        Respawn(fighter, map, spritePool);
                }
            }
        }
        #endregion

        #region Private Methods
        private void Respawn(AbstractFighter fighter, AbstractMap map, SpritePool spritePool)
        {
            if (this.map != map)
            {
                this.map = map;
                emptyMapLocationCache = new EmptyMapLocationCache(this.map);
                Point point = emptyMapLocationCache.GetAvailableLocation(map, spritePool);
                fighter.PositionX = (double)point.X;
                fighter.PositionY = (double)point.Y;
                fighter.Health = fighter.DefaultHealth;
                fighter.AngleDegree = random.Next(360);
            }
        }
        #endregion
    }
}
