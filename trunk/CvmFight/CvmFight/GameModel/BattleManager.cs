using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class BattleManager
    {
        #region Public Methods
        public void Update(SpritePool spritePool, SharedConsciousness sharedConsciousness, AbstractHumanoid currentPlayer)
        {
            foreach (AbstractHumanoid sprite in spritePool)
                Update(sprite, spritePool, sharedConsciousness, currentPlayer);
        }
        #endregion

        #region Private Methods
        private void Update(AbstractHumanoid predator, SpritePool spritePool, SharedConsciousness sharedConsciousness, AbstractHumanoid currentPlayer)
        {
            bool predatorAttackIsAtParoxism;
            double damage;
            bool isFastAttack = false;

            if (predator.StrongAttackCycle.IsAtParoxism)
            {
                damage = predator.AttackPowerStrong;
                predatorAttackIsAtParoxism = true;
            }
            else if (predator.FastAttackCycle.IsAtParoxism)
            {
                damage = predator.AttackPowerFast;
                predatorAttackIsAtParoxism = true;
                isFastAttack = true;
            }
            else if (predator.IsAttackStraw)
            {
                damage = predator.AttackPowerStraw;
                predatorAttackIsAtParoxism = true;
            }
            else if (predator.SpinAttackCycle.IsFired)
            {
                damage = predator.AttackPowerStrong;
                predatorAttackIsAtParoxism = true;
            }
            else
            {
                return;
            }



            if (predatorAttackIsAtParoxism && predator.ReceivedAttackCycle.GetCycleState() <= 0)
            {
                foreach (AbstractHumanoid prey in spritePool)
                {
                    if (prey == predator)
                        continue;

                    if (predator.IsAttackStraw || BattlePhysics.IsWithinAttackRange(predator, prey))
                    {
                        if (BattlePhysics.IsInAttackOrBlockAngle(predator, prey))
                        {
                            if (BattlePhysics.IsInAttackHeight(predator, prey))
                            {
                                if (!prey.IsBlock || !BattlePhysics.IsInAttackOrBlockAngle(prey, predator) || !BattlePhysics.IsInBlockingHeight(prey, predator))
                                {
                                    //We abort prey's attack
                                    prey.FastAttackCycle.Reset();
                                    prey.StrongAttackCycle.Reset();
                                    prey.BlockSuccessCycle.Reset();
                                    prey.SpinChargeAttackCycle.Reset();
                                    prey.SpinAttackCycle.Reset();

                                    prey.FastAttackCycle.IsNeedToClickAgain = true;
                                    prey.StrongAttackCycle.IsNeedToClickAgain = true;

                                    prey.ReceivedAttackAngleRadian = predator.AngleRadian;
                                    prey.ReceivedAttackCycle.Fire();

                                    if (isFastAttack)
                                    {
                                        prey.ReceivedAttackCycle.PercentComplete = 0.25;
                                        prey.ReceivedAttackCycle.IsForward = false;
                                        prey.IsJustReceivedFastAttack = true;
                                    }
                                    else if (predator.IsAttackStraw)
                                    {
                                        prey.ReceivedAttackCycle.PercentComplete = 0.05;
                                        prey.ReceivedAttackCycle.IsForward = false;
                                        prey.IsJustReceivedFastAttack = true;
                                    }
                                    else
                                    {
                                        if (predator.IsCrouch || predator.PositionZ >= 0)
                                            prey.IsJustReceivedStrongKick = true;
                                        else
                                            prey.IsJustReceivedStrongPunch = true;
                                    }

                                    prey.LatestPredator = predator;
                                    prey.LatestPredatorDamage = damage;

                                    if (!(prey is Player))
                                    {
                                        prey.StateJumpCrouch.Reset();
                                        prey.StateMovement.Reset();
                                        prey.StateAttackBlock.Reset();
                                        if (prey.StateAttackBlock.GetCurrentState() == SpriteStates.SpinCharge)
                                        {
                                            prey.StateAttackBlock.Reset();
                                        }
                                    }

                                    if (!(predator is Player))
                                    {
                                        predator.StateJumpCrouch.Renew();
                                        predator.StateMovement.Renew();
                                        predator.StateAttackBlock.Renew();
                                    }
                                }
                                else if (prey.IsBlock)
                                {
                                    prey.BlockSuccessCycle.Reset();
                                    prey.BlockSuccessCycle.Fire();
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
