using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class BattleManager
    {
        #region Public Methods
        public void Update(SpritePool spritePool, SharedConsciousness sharedConsciousness, AbstractSprite currentPlayer)
        {
            foreach (AbstractSprite sprite in spritePool)
                Update(sprite, spritePool, sharedConsciousness, currentPlayer);
        }
        #endregion

        #region Private Methods
        private void Update(AbstractSprite predator, SpritePool spritePool, SharedConsciousness sharedConsciousness, AbstractSprite currentPlayer)
        {
            if (predator.AttackCycle.IsAtParoxism && predator.ReceivedAttackCycle.GetCycleState() <= 0)
            {
                foreach (AbstractSprite prey in spritePool)
                {
                    if (prey == predator)
                        continue;

                    if (Physics.IsWithinAttackRange(predator, prey))
                    {
                        if (Physics.IsInAttackOrBlockAngle(predator, prey))
                        {
                            if (Physics.IsInAttackHeight(predator, prey))
                            {
                                if (!prey.IsBlock || !Physics.IsInAttackOrBlockAngle(prey, predator) || !Physics.IsInBlockingHeight(prey, predator))
                                {
                                    prey.Health -= predator.AttackPower / Physics.GetSpriteDistance(predator, prey);

                                    prey.ReceivedAttackAngleRadian = predator.AngleRadian;
                                    prey.ReceivedAttackCycle.Fire();
                                    prey.LatestPredator = predator;

                                    if (!(prey is Player))
                                    {
                                        prey.StateJumpCrouch.Reset();
                                        prey.StateMovement.Reset();
                                        prey.StateAttackBlock.Reset();
                                    }

                                    if (!(predator is Player))
                                    {
                                        prey.StateJumpCrouch.Renew();
                                        prey.StateMovement.Renew();
                                        prey.StateAttackBlock.Renew();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
