using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class MonsterStickMan : AbstractSprite
    {
        public MonsterStickMan()
        {
            IsAlive = false;
            Height = 1.0;
            Radius = 0.1;
            AttackRange = 0.4;
            AttackAngleRange = 0.17;
            AttackPower = 2.5;
            DefaultHealth = 100.0;
            Health = 0;
            MaxHealth = 200.0;
            MaxJumpAcceleration = 0.83;
            CrouchSpeedMultiplier = 0.2;
            DefaultWalkingDistance = 0.01;
            JumpSpeedMultiplier = 1.6;
            AttackWalkSpeedMultiplier = 0;
        }
    }
}
