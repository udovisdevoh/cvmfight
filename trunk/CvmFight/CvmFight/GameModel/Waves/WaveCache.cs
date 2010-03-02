using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Waves
{
    /// <summary>
    /// Cache for wave values
    /// </summary>
    class WaveCache
    {
        #region Fields
        /// <summary>
        /// Internal cache
        /// </summary>
        private Dictionary<int, double> internalCache = new Dictionary<int, double>();

        /// <summary>
        /// Cache's precision
        /// </summary>
        private double precision = 0.05;
        #endregion

        #region Constructor
        /// <summary>
        /// Create wave cache
        /// </summary>
        public WaveCache()
        {
        }

        /// <summary>
        /// Create wave cache
        /// </summary>
        /// <param name="precision">precision (default: 0.01)</param>
        public WaveCache(double precision)
        {
            this.precision = precision;
        }
        #endregion

        #region Public Methods
        public bool TryGetValue(double x, out double value)
        {
            int roundedX = (int)Math.Round(x / precision);

            return internalCache.TryGetValue(roundedX, out value);
        }

        public void Add(double x, double value)
        {
            int roundedX = (int)Math.Round(x / precision);

            if (!internalCache.ContainsKey(roundedX))
                internalCache.Add(roundedX, value);
        }
        #endregion
    }
}
