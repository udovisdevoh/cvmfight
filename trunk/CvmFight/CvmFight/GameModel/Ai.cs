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
        public void Animate(AbstractSprite predator, AbstractMap map, SpritePool spritePool, SharedConsciousness sharedConsciousness, double timeDelta, int fov, Random random, AbstractSprite currentPlayer)
        {
            AbstractSprite prey = TryChoosePrey(predator, spritePool, sharedConsciousness, map, fov, currentPlayer);
            
            predator.IsNeedToJumpAgain = false;
            predator.IsBlock = false;

            //We manage jumping state
            if (predator.StateJumpCrouch.GetCurrentState() == SpriteStates.Jump)
            {
                predator.IsCrouch = false;
                Physics.MakeJump(predator, timeDelta);
            }

            //We manage crouch state
            if (predator.StateJumpCrouch.GetCurrentState() == SpriteStates.Crouch)
            {
                predator.IsCrouch = true;
            }


            //We manage standing state
            if (predator.StateJumpCrouch.GetCurrentState() == SpriteStates.Stand)
            {
                predator.IsCrouch = false;
                predator.IsNeedToJumpAgain = false;
            }

            //We manage walking
            if (prey != null)
            {
                if (random.Next(5) == 0)
                    predator.AngleRadian = Optics.GetSpriteAngleToSpriteRadian(predator, prey);


                if (predator.StateMovement.GetCurrentState() == SpriteStates.Offensive)
                {
                    Physics.TryMakeWalk(predator, spritePool, map, timeDelta);
                }
                else if (predator.StateMovement.GetCurrentState() == SpriteStates.Defensive)
                {
                    Physics.TryMakeWalk(predator, Math.PI, spritePool, map, timeDelta);
                }
                else if (predator.StateMovement.GetCurrentState() == SpriteStates.FurtiveLeft)
                {
                    Physics.TryMakeWalk(predator, Math.PI * 1.5, spritePool, map, timeDelta);
                }
                else if (predator.StateMovement.GetCurrentState() == SpriteStates.FurtiveRight)
                {
                    Physics.TryMakeWalk(predator, Math.PI * 0.5, spritePool, map, timeDelta);
                }



                //We manage attacking and blocking
                bool isWithinAttackRange = Physics.IsWithinAttackRange(predator, prey);
                bool isWithinAttackOrBlockAngle = Physics.IsInAttackOrBlockAngle(predator, prey);
                byte currentAttackBlockState = predator.StateAttackBlock.GetCurrentState();

                if (currentAttackBlockState == SpriteStates.Block && predator.PositionZ > 0)
                    currentAttackBlockState = SpriteStates.Attack;

                if (isWithinAttackRange || isWithinAttackOrBlockAngle)
                {
                    if (currentAttackBlockState == SpriteStates.Attack)
                    {
                        if (random.Next(2) == 1)
                        {
                            if (isWithinAttackRange && isWithinAttackOrBlockAngle)
                            {
                                predator.StrongAttackCycle.UnFire();
                                predator.StrongAttackCycle.Fire();
                            }
                        }
                    }
                    else if (currentAttackBlockState == SpriteStates.Block)
                    {
                        predator.StrongAttackCycle.UnFire();
                        predator.IsBlock = true;
                    }
                }
                predator.StateAttackBlock.Update(timeDelta, random);

                predator.StateMovement.Update(timeDelta, random);
            }
            else
            {
                if (!Physics.TryMakeWalk(predator, spritePool, map, timeDelta))
                {
                    predator.AngleDegree = (double)random.Next(360);
                }
            }

            predator.StateJumpCrouch.Update(timeDelta,random);
        }
        #endregion

        #region Private Methods
        private AbstractSprite TryChoosePrey(AbstractSprite predator, SpritePool spritePool, SharedConsciousness sharedConsciousness, AbstractMap map, int fov, AbstractSprite currentPlayer)
        {
            AbstractSprite closestPrey = null;
            double closestDistance = -1;
            foreach (AbstractSprite prey in spritePool)
            {
                if (prey == predator)
                    continue;

                if (!Physics.IsWithinAttackRange(predator, prey) && !sharedConsciousness.IsSpriteViewable(predator, prey, map, fov))
                    continue;

                double currentDistance = Physics.GetSpriteDistance(predator, prey);

                if (closestPrey == null || currentDistance < closestDistance)
                {
                    closestPrey = prey;
                    closestDistance = currentDistance;
                }   
            }

            return closestPrey;
        }    
        #endregion
    }
}
