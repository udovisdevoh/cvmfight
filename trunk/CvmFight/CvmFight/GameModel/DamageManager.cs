﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class DamageManager
    {
        #region Public Methods
        public void Update(SpritePool spritePool, AbstractSprite currentPlayer, AbstractMap map, double timeDelta, out bool isNeedRefreshHud)
        {
            isNeedRefreshHud = false;
            
            foreach (AbstractSprite sprite in spritePool)
            {
                bool currentSpriteNeedRefreshHud;
                Update(sprite, spritePool, currentPlayer, map, timeDelta, out currentSpriteNeedRefreshHud);
                isNeedRefreshHud = isNeedRefreshHud || currentSpriteNeedRefreshHud;
            }
        }
        #endregion

        #region Private Methods
        private void Update(AbstractSprite sprite, SpritePool spritePool, AbstractSprite currentPlayer, AbstractMap map, double timeDelta, out bool isNeedRefreshHud)
        {
            isNeedRefreshHud = false;

            
            sprite.ReceivedAttackCycle.Update(timeDelta);

            //We manage received attack
            if (sprite.ReceivedAttackCycle.GetCycleState() > 0)
            {
                Physics.TryMakeWalk(sprite, sprite.ReceivedAttackAngleRadian - sprite.AngleRadian, spritePool, map, 1);
                sprite.IsNeedToJumpAgain = false;
                Physics.MakeJump(sprite, timeDelta);
                sprite.Health -= sprite.LatestPredator.AttackPower;

                if (!sprite.IsAlive)
                {
                    isNeedRefreshHud = true;
                    sprite.LatestPredator.FragCount++;
                    currentPlayer.RefreshRanking(spritePool);
                }

                if (sprite == currentPlayer)
                {
                    isNeedRefreshHud = true;
                }
            }
            else
            {
                sprite.ReceivedAttackCycle.UnFire();
            }

        }
        #endregion
    }
}
