using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Graphics.Primitives;
using SdlDotNet.Graphics;

namespace CvmFight
{
    class CircleCache
    {
        #region Fields
        private Dictionary<AbstractSprite, Circle> internalCache = new Dictionary<AbstractSprite, Circle>();
        #endregion

        #region Public Methods
        public bool TryGetValue(AbstractSprite sprite, out Circle circle)
        {
            return internalCache.TryGetValue(sprite, out circle);
        }

        public void Add(AbstractSprite sprite, Circle circle)
        {
            internalCache.Add(sprite, circle);
        }
        #endregion
    }
}
