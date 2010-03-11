using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class SpriteActionCycle
    {
        #region Fields
        private double cycleLength;

        private double currentCyclePosition;

        private bool isForward = true;

        private bool isFired;

        private bool isNeedToClickAgain = false;
        #endregion

        #region Constructor
        public SpriteActionCycle(double cycleLength)
        {
            this.cycleLength = cycleLength;
        }
        #endregion

        #region Public Method
        public void Fire()
        {
            if (!isNeedToClickAgain)
                isFired = true;
        }

        public void Update(double timeDelta)
        {
            if (currentCyclePosition > cycleLength)
            {
                isForward = false;
            }
            else if (currentCyclePosition < 0)
            {
                isForward = true;
                isFired = false;
                isNeedToClickAgain = true;
            }


            if (isFired)
            {
                if (isForward)
                {
                    currentCyclePosition += timeDelta / 10;
                }
                else
                {
                    currentCyclePosition -= timeDelta / 10;
                }
            }
            else
            {
                currentCyclePosition = 0;
            }
        }

        /// <summary>
        /// Don't use that to know when attack occurs in game logic
        /// </summary>
        /// <returns></returns>
        public int GetCycleState()
        {
            int state = 0;
            if (currentCyclePosition > cycleLength / 2)
            {
                state = 2;
            }
            else if (currentCyclePosition > 0)
            {
                state = 1;
            }

            return state;
        }

        public void UnFire()
        {
            isNeedToClickAgain = false;
        }

        public void Reset()
        {
            UnFire();
            currentCyclePosition = 0;
        }

        public void SetPercentComplete(double percentComplete)
        {
            currentCyclePosition = this.cycleLength * percentComplete;
        }
        #endregion

        #region Properties
        public bool IsAtParoxism
        {
            get { return currentCyclePosition > cycleLength; }
        }

        public bool IsFired
        {
            get { return isFired; }
        }

        public bool IsForward
        {
            get { return isForward; }
            set { isForward = value; }
        }
        #endregion

    }
}
