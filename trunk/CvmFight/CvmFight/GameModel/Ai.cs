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
        public void Animate(AbstractSprite sprite, AbstractMap map, SpritePool spritePool, SharedConsciousness sharedConsciousness, double timeDelta, int fov, Random random, AbstractSprite currentPlayer)
        {
            AbstractSprite prey = TryChosePrey(sprite, spritePool, sharedConsciousness, map, fov, currentPlayer);
            
            sprite.IsNeedToJumpAgain = false;

            //We manage jumping state
            if (sprite.StateJumpCrouch.GetCurrentState() == SpriteStates.Jump)
            {
                sprite.IsCrouch = false;
                Physics.MakeJump(sprite, timeDelta);
            }

            //We manage crouch state
            if (sprite.StateJumpCrouch.GetCurrentState() == SpriteStates.Crouch)
            {
                sprite.IsCrouch = true;
            }


            //We manage standing state
            if (sprite.StateJumpCrouch.GetCurrentState() == SpriteStates.Stand)
            {
                sprite.IsCrouch = false;
                sprite.IsNeedToJumpAgain = false;
            }


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

            sprite.StateJumpCrouch.Update(timeDelta,random);
        }
        #endregion

        #region Private Methods
        private AbstractSprite TryChosePrey(AbstractSprite predator, SpritePool spritePool, SharedConsciousness sharedConsciousness, AbstractMap map, int fov, AbstractSprite currentPlayer)
        {
            foreach (AbstractSprite prey in spritePool)
            {
                if (prey != predator)
                {
                    if (Physics.IsWithinAttackRange(predator,prey))
                    {
                        return prey;
                    }
                    else if (sharedConsciousness.IsSpriteViewable(predator, prey, map, fov))
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
