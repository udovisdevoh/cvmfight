using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Waves
{
    interface IWave : IEquatable<IWave>
    {
        /// <summary>
        /// Get amplitude momentum Y value at X
        /// </summary>
        /// <param name="x">x coordinates</param>
        /// <returns>amplitude momentum Y value at X</returns>
        double GetYValueAt(double x);

        /// <summary>
        /// Normalize the wave
        /// </summary>
        /// <returns>Normalized wave</returns>
        void Normalize();
    }
}
