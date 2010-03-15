﻿using System;
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

                    if (Physics.IsWithinAttackRange(predator, prey))
                    {
                        if (Physics.IsInAttackOrBlockAngle(predator, prey))
                        {
                            if (Physics.IsInAttackHeight(predator, prey))
                            {
                                if (!prey.IsBlock || !Physics.IsInAttackOrBlockAngle(prey, predator) || !Physics.IsInBlockingHeight(prey, predator))
                                {
                                    //We abort prey's attack
                                    prey.FastAttackCycle.Reset();
                                    prey.StrongAttackCycle.Reset();
                                    prey.BlockSuccessCycle.Reset();

                                    prey.ReceivedAttackAngleRadian = predator.AngleRadian;
                                    prey.ReceivedAttackCycle.Fire();

                                    if (isFastAttack)
                                    {
                                        prey.ReceivedAttackCycle.SetPercentComplete(0.25);
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
                                    }

                                    if (!(predator is Player))
                                    {
                                        prey.StateJumpCrouch.Renew();
                                        prey.StateMovement.Renew();
                                        prey.StateAttackBlock.Renew();
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
