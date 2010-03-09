using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Primitives;

namespace CvmFight
{
    class SpriteCollectionCache3D
    {
        #region Fields
        private Dictionary<Type, SpriteCache3D> internalCache;

        private SpriteCache3DBuilder spriteCache3DBuilder = new SpriteCache3DBuilder();
        #endregion

        #region Constructor
        public SpriteCollectionCache3D(SpritePool spritePool, bool isEnableSpriteCache)
        {
            internalCache = new Dictionary<Type, SpriteCache3D>();

            HashSet<Type> addedTypeList = new HashSet<Type>();

            foreach (AbstractSprite sprite in spritePool)
            {
                if (!addedTypeList.Contains(sprite.GetType()))
                {
                    internalCache[sprite.GetType()] = spriteCache3DBuilder.Build(sprite, isEnableSpriteCache);
                    addedTypeList.Add(sprite.GetType());
                }
            }
        }
        #endregion

        #region Public Methods
        public SpriteCache3D GetSpriteCache(AbstractSprite sprite)
        {
            return internalCache[sprite.GetType()];
        }
        #endregion
    }
}
