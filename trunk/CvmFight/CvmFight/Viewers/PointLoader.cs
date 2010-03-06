using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CvmFight
{
    static class PointLoader
    {
        #region Constants
        private const int radius = 2048;
        #endregion

        #region Parts
        private static Point[,] pointGrid;
        #endregion

        #region Constructors
        static PointLoader()
        {
            pointGrid = new Point[radius * 2, radius * 2];
            for (int x = 0; x < radius * 2; x++)
                for (int y = 0; y < radius * 2; y++)
                    pointGrid[x, y] = new Point(x - radius, y - radius);
        }
        #endregion

        #region Public Methods
        public static Point GetPoint(int x, int y)
        {
            return pointGrid[x + radius, y + radius];
        }

        public static bool IsPositionValid(int x, int y)
        {
            return Math.Abs(x) < radius && Math.Abs(y) < radius;
        }
        #endregion
    }
}
