using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Waves
{
    #region Delegate types
    /// <summary>
    /// Wave's function delegate type
    /// </summary>
    /// <param name="x">x</param>
    /// <returns>y</returns>
    public delegate double WaveFunction(double x);
    #endregion

    static class WaveFunctions
    {
        #region Fields
        private static WaveFunction sine = Math.Sin;

        private static WaveFunction square = SquareWave;

        private static WaveFunction triangle = TriangleWave;

        private static WaveFunction saw = SawWave;

        private static WaveFunction negativeSaw = NegativeSawWave;
        #endregion

        #region Public Methods
        /// <summary>
        /// Random wave functions
        /// </summary>
        /// <param name="random">random number generator</param>
        /// <returns>Random wave functions</returns>
        public static WaveFunction GetRandomWaveFunction(Random random)
        {
            return GetRandomWaveFunction(random, false);
        }

        /// <summary>
        /// Return random wave function
        /// </summary>
        /// <param name="random">random number generator</param>
        /// <param name="isOnlyContinuous">whether we only want continuous waves (default: false)</param>
        /// <returns>random wave function</returns>
        public static WaveFunction GetRandomWaveFunction(Random random, bool isOnlyContinuous)
        {
            int functionType;
            if (isOnlyContinuous)
                functionType = random.Next(1, 3);
            else
                functionType = random.Next(1, 5);

            if (functionType == 1)
                return sine;
            else if (functionType == 2)
                return triangle;
            else if (functionType == 3)
                return square;
            else
            {
                if (random.Next(0, 2) == 1)
                {
                    return saw;
                }
                else
                {
                    return negativeSaw;
                }
            }
        }
        #endregion

        #region Private Methods
        private static double SquareWave(double x)
        {
            return Math.Round(Math.Sin(x));
        }

        private static double TriangleWave(double x)
        {
            return Math.Asin(Math.Sin(x));
        }

        private static double SawWave(double x)
        {
            return x - Math.Round(x);
        }

        private static double NegativeSawWave(double x)
        {
            return (x - Math.Round(x)) * -1.0;
        }
        #endregion

        #region Properties
        public static WaveFunction Sine
        {
            get { return sine; }
        }

        public static WaveFunction Square
        {
            get { return square; }
        }

        public static WaveFunction Saw
        {
            get { return saw; }
        }

        public static WaveFunction NegativeSaw
        {
            get { return negativeSaw; }
        }
        #endregion
    }

}
