using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Graphics.Primitives;
using SdlDotNet.Graphics;

namespace CvmFight
{
    class SpritePrimitiveCache
    {
        #region Fields
        private Dictionary<AbstractSprite, IPrimitive> internalCache = new Dictionary<AbstractSprite, IPrimitive>();
        #endregion

        #region Public Methods
        public bool TryGetValue(AbstractSprite sprite, out IPrimitive circle)
        {
            return internalCache.TryGetValue(sprite, out circle);
        }

        public void Add(AbstractSprite sprite, IPrimitive circle)
        {
            internalCache.Add(sprite, circle);
        }
        #endregion
    }
}
