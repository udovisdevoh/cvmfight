using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    /// <summary>
    /// Which keys are up or down
    /// </summary>
    class UserInput
    {
        #region Fields
        private bool isPressUp = false;

        private bool isPressDown = false;

        private bool isPressLeft = false;

        private bool isPressRight = false;
        #endregion

        #region Properties
        public bool IsPressUp
        {
            get { return isPressUp; }
            set { isPressUp = value; }
        }

        public bool IsPressDown
        {
            get { return isPressDown; }
            set { isPressDown = value; }
        }

        public bool IsPressLeft
        {
            get { return isPressLeft; }
            set { isPressLeft = value; }
        }

        public bool IsPressRight
        {
            get { return isPressRight; }
            set { isPressRight = value; }
        }
        #endregion
    }
}
