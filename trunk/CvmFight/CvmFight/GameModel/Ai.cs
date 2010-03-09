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
        public void Animate(AbstractSprite sprite, AbstractMap map, SpritePool spritePool, SharedConsciousness sharedConsciousness, double timeDelta, int fov, Random random)
        {
            AbstractSprite prey = TryChosePrey(sprite, spritePool, sharedConsciousness, map, fov);

            if (prey != null)
            {
                sprite.AngleRadian = Optics.GetSpriteAngleToSpriteRadian(sprite, prey);

                if (sprite.StateMovement.GetCurrentState() == SpriteStates.Offensive)
                {
                    Physics.TryMakeWalk(sprite, spritePool, map, timeDelta);
                }
                else if (sprite.StateMovement.GetCurrentState() == SpriteStates.Defensive)
                {
                    Physics.TryMakeWalk(sprite, Math.PI, spritePool, map, timeDelta);
                }
                else if (sprite.StateMovement.GetCurrentState() == SpriteStates.FurtiveLeft)
                {
                    Physics.TryMakeWalk(sprite, Math.PI * 1.5, spritePool, map, timeDelta);
                }
                else if (sprite.StateMovement.GetCurrentState() == SpriteStates.FurtiveRight)
                {
                    Physics.TryMakeWalk(sprite, Math.PI * 0.5, spritePool, map, timeDelta);
                }

                sprite.StateMovement.Update(timeDelta, random);
            }
            else
            {
                if (!Physics.TryMakeWalk(sprite, spritePool, map, timeDelta))
                {
                    sprite.AngleDegree = (double)random.Next(360);
                }
            }
        }
        #endregion

        #region Private Methods
        private AbstractSprite TryChosePrey(AbstractSprite predator, SpritePool spritePool, SharedConsciousness sharedConsciousness, AbstractMap map, int fov)
        {
            foreach (AbstractSprite prey in spritePool)
            {
                if (prey != predator)
                {
                    if (sharedConsciousness.IsSpriteViewable(predator, prey, map, fov))
                    {
                        return prey;
                    }
                    else if (Physics.IsWithinAttackRange(predator,prey))
                    {
                        return prey;
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
