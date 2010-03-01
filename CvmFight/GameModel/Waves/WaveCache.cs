﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Waves
{
    class WaveCache
    {
        #region Fields
        private Dictionary<double, double> internalCache = new Dictionary<double, double>();
        #endregion

        #region Public Methods
        public bool ContainsKey(double x)
        {
            return internalCache.ContainsKey(x);
        }

        public void Add(double x, double value)
        {
            if (!internalCache.ContainsKey(x))
                internalCache.Add(x, value);
        }

        public double Get(double x)
        {
            return internalCache[x];
        }
        #endregion
    }
}
