using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class ColumnViewer
    {
        #region Fields
        private int columnCount;
        #endregion

        #region Constructor
        public ColumnViewer(int screenWidth, int screenHeight, int columnCount)
        {
            this.columnCount = columnCount;
        }
        #endregion

        #region Public Methods
        public void Update(RayTracer rayTracer)
        {
        }
        #endregion
    }
}
