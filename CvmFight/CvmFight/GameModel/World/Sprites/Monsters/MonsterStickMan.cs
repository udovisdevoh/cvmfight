using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class MonsterStickMan : AbstractFighter
    {
        public MonsterStickMan()
        {
            DefaultHealth = 100;
            MaxHealth = 200;
            Radius = 0.1;
            DefaultWalkingDistance = 0.1;
        }
    }
}
