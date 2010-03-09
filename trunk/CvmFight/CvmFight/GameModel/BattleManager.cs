using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class BattleManager
    {
        #region Fields
        private bool isNeedRefreshHud;
        #endregion

        #region Public Methods
        public void Update(SpritePool spritePool, SharedConsciousness sharedConsciousness, AbstractSprite currentPlayer)
        {
            isNeedRefreshHud = false;
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
                            prey.IsBlockSuccessful = false;
                            if (!prey.IsBlock || !Physics.IsInAttackOrBlockAngle(prey, predator))
                            {
                                prey.Health -= predator.AttackPower / Physics.GetSpriteDistance(predator,prey);

                                prey.ReceivedAttackAngleRadian = predator.AngleRadian;
                                prey.ReceivedAttackCycle.Fire();

                                if (!prey.IsAlive)
                                {
                                    isNeedRefreshHud = true;
                                    predator.FragCount++;
                                    currentPlayer.RefreshRanking(spritePool);
                                }
                                
                                if (prey == currentPlayer)
                                {
                                    isNeedRefreshHud = true;
                                }
                            }
                            else if (prey.IsBlock)
                            {
                                prey.IsBlockSuccessful = true;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Properties
        public bool IsNeedRefreshHud
        {
            get { return isNeedRefreshHud; }
            set { isNeedRefreshHud = value; }
        }
        #endregion
    }
}
