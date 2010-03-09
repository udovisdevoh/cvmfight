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
        public void Update(SpritePool spritePool, SharedConsciousness sharedConsciousness)
        {
            isNeedRefreshHud = false;
            foreach (AbstractSprite sprite in spritePool)
                Update(sprite, spritePool, sharedConsciousness);
        }
        #endregion

        #region Private Methods
        private void Update(AbstractSprite predator, SpritePool spritePool, SharedConsciousness sharedConsciousness)
        {
            if (predator.AttackCycle.IsAtParoxism)
            {
                foreach (AbstractSprite prey in spritePool)
                {
                    if (prey == predator)
                        continue;

                    if (Physics.IsWithinAttackRange(predator, prey))
                    {
                        if (Physics.IsInAttackOrBlockAngle(predator, prey))
                        {
                            if (!prey.IsBlock || !Physics.IsInAttackOrBlockAngle(prey, predator))
                            {
                                prey.Health -= predator.AttackPower / Physics.GetSpriteDistance(predator,prey);

                                prey.ReceivedAttackAngleRadian = predator.AngleRadian;
                                prey.ReceivedAttackCycle.Fire();

                                if (predator.PositionZ > 0 || predator.IsCrouch)
                                    prey.ReceivedAttackAngleRadian -= 0.5;
                                else
                                    prey.ReceivedAttackAngleRadian += 0.5;

                                if (!prey.IsAlive)
                                {
                                    isNeedRefreshHud = true;
                                    predator.FragCount++;
                                }

                                if (prey is Player)
                                {
                                    isNeedRefreshHud = true;
                                }
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
