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
            bool predatorAttackIsAtParoxism;
            double damage;

            if (predator.StrongAttackCycle.IsAtParoxism)
            {
                damage = predator.AttackPowerStrong;
                predatorAttackIsAtParoxism = true;
            }
            else if (predator.FastAttackCycle.IsAtParoxism)
            {
                damage = predator.AttackPowerFast;
                predatorAttackIsAtParoxism = true;
            }
            else
            {
                return;
            }



            if (predatorAttackIsAtParoxism && predator.ReceivedAttackCycle.GetCycleState() <= 0)
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
                                    prey.Health -= predator.AttackPowerStrong / Physics.GetSpriteDistance(predator, prey);

                                    prey.ReceivedAttackAngleRadian = predator.AngleRadian;
                                    prey.ReceivedAttackCycle.Fire();
                                    prey.LatestPredator = predator;
                                    prey.LatestPredatorDamage = damage;

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
