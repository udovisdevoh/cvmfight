using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class CachedWaveMap : AbstractMap
    {
        #region Constants
        private double precision = 0.01;
        #endregion

        #region Fields
        private WaveMap waveMap;

        private WaveMapCache waveMapCache;

        private ColorMap colorMap;
        #endregion

        #region Public Methods
        public CachedWaveMap(Random random)
        {
            waveMap = new WaveMap(random);
            waveMapCache = new WaveMapCache(waveMap, precision);
            colorMap = new ColorMap(random,waveMap.Width,waveMap.Height);
        }

        public override AbstractMatterType GetMatterTypeAt(double x, double y)
        {
            return waveMapCache.GetValueAt(x, y);
        }

        public override int Width
        {
            get { return waveMap.Width; }
        }

        public override int Height
        {
            get { return waveMap.Height; }
        }

        /// <summary>
        /// From color map, returns red multiplicator
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">x</param>
        /// <returns>red color multiplicator at x,y</returns>
        public override double GetRedMultiplicatorAt(double x, double y)
        {
            return colorMap.GetRedMultiplicatorAt(x, y);
        }

        /// <summary>
        /// From color map, returns green color multiplicator
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">x</param>
        /// <returns>green color multiplicator at x,y</returns>
        public override double GetGreenMultiplicatorAt(double x, double y)
        {
            return colorMap.GetGreenMultiplicatorAt(x, y);
        }

        /// <summary>
        /// From color map, returns blue color multiplicator
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>blue color multiplicator at x,y</returns>
        public override double GetBlueMultiplicatorAt(double x, double y)
        {
            return colorMap.GetBlueMultiplicatorAt(x, y);
        }
        #endregion
    }
}
