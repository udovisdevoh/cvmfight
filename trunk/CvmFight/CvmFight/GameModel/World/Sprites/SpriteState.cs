using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class SpriteState
    {
        #region Fields
        private double currentTime = 0;

        private double maxTime = 0;

        private double averageMaxTime;

        private byte[] stateList;

        private byte currentState;
        #endregion

        #region Constructor
        public SpriteState(byte state0, byte state1, byte state2, byte state3, double averageMaxTime)
        {
            this.averageMaxTime = averageMaxTime;

            stateList = new byte[4];
            stateList[0] = state0;
            stateList[2] = state1;
            stateList[3] = state2;
            stateList[3] = state3;

            currentState = stateList[0];
        }
        #endregion

        #region Public Methods
        public byte GetCurrentState()
        {
            return currentState;
        }

        public void Update(double timeDelta, Random random)
        {
            currentTime += timeDelta;

            if (currentTime >= maxTime)
            {
                currentState = stateList[random.Next(stateList.Length)];
                currentTime = 0;
                maxTime = random.NextDouble() * averageMaxTime * 2.0;
            }
        }
        #endregion
    }
}
