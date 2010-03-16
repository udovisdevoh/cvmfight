﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class MonsterNutKunDo : AbstractHumanoid
    {
        #region Abstract Sprite Members
        protected override double GetHeight()
        {
            return 1.15;
        }

        protected override double GetRadius()
        {
            return 0.1;
        }

        protected override double GetAttackRange()
        {
            //return 0.4;
            return 0.455;
        }

        protected override double GetAttackAngleRange()
        {
            return 0.17;
        }

        protected override double GetAttackPowerStrong()
        {
            return 1.4;
        }

        protected override double GetAttackPowerFast()
        {
            return 0.3 * 8; //*8 to compensate for the shortness of damage
        }

        protected override double GetDefaultHealth()
        {
            return 200;
        }

        protected override double GetMaxHealth()
        {
            return 400;
        }

        protected override double GetMaxJumpAcceleration()
        {
            return 0.58;
        }

        protected override double GetCrouchSpeedMultiplier()
        {
            //return 0.2;
            return 0;
        }

        protected override double GetDefaultWalkingDistance()
        {
            return 0.02;
        }

        protected override double GetJumpSpeedMultiplier()
        {
            //return 1.6;
            return 1;
        }

        protected override double GetAttackWalkSpeedMultiplier()
        {
            //return 0;
            return 1;
        }

        protected override double GetStrongAttackTime()
        {
            //return 0.2;
            //return 1;
            return 4;
        }

        protected override double GetFastAttackTime()
        {
            return 1;
        }

        protected override double GetReceivedAttackCycleLength()
        {
            //return 0.35;
            return 2;
        }

        protected override double GetWalkCycleLength()
        {
            return 1.0;
        }

        protected override double GetStateAttackBlockCycleLength()
        {
            return 50;
        }

        protected override double GetJumpCrouchCycleLength()
        {
            return 20;
        }

        protected override double GetMovementCycleLength()
        {
            return 10;
        }

        protected override double GetAttackRangeJumpMultiplier()
        {
            //return 1.1375;
            return 1;
        }

        protected override double GetAttackRangeCrouchMultiplier()
        {
            return 1.1375;
        }

        protected override double GetAttackAngleSpinMultiplier()
        {
            return 3;
        }

        protected override double GetBlockSuccessTime()
        {
            return 0.5;
        }

        protected override double GetSpinAttackChargeTime()
        {
            return 10;
        }

        protected override double GetSpinAttackTime()
        {
            return 5;
        }
        #endregion
    }
}
