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
        #endregion

        #region Public Methods
        public CachedWaveMap(Random random)
        {
            waveMap = new WaveMap(random);
            waveMapCache = new WaveMapCache(waveMap, precision);
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
        #endregion
    }
}
