using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class Ai
    {
        #region Fields
        private Random random;
        #endregion

        #region Constructor
        public Ai(Random random)
        {
            this.random = random;
        }
        #endregion

        #region Public Methods
        public void Animate(AbstractSprite sprite, AbstractMap map, SpritePool spritePool, double timeDelta)
        {
            if (!Physics.TryMakeWalk(sprite, spritePool, map, timeDelta))
            {
                sprite.AngleDegree = (double)random.Next(360);
            }            
        }
        #endregion
    }
}
