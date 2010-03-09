using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class MonsterStickMan : AbstractSprite
    {
        #region Abstract Sprite Members
        protected override double GetHeight()
        {
            return 1.0;
        }

        protected override double GetRadius()
        {
            return 0.1;
        }

        protected override double GetAttackRange()
        {
            return 0.4;
        }

        protected override double GetAttackAngleRange()
        {
            return 0.17;
        }

        protected override double GetAttackPower()
        {
            return 2.5;
        }

        protected override double GetDefaultHealth()
        {
            return 100;
        }

        protected override double GetMaxHealth()
        {
            return 200;
        }

        protected override double GetMaxJumpAcceleration()
        {
            return 0.83;
        }

        protected override double GetCrouchSpeedMultiplier()
        {
            return 0.2;
        }

        protected override double GetDefaultWalkingDistance()
        {
            return 0.01;
        }

        protected override double GetJumpSpeedMultiplier()
        {
            return 1.6;
        }

        protected override double GetAttackWalkSpeedMultiplier()
        {
            return 0;
        }
        #endregion
    }
}
