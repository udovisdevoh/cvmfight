using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    /// <summary>
    /// Represents common conscousness among sprites
    /// </summary>
    class SharedConsciousness
    {
        #region Fields
        private int spriteCount;

        private Dictionary<AbstractSprite, Dictionary<AbstractSprite,bool>> internalList = new Dictionary<AbstractSprite, Dictionary<AbstractSprite,bool>>();
        #endregion

        #region Constructor
        public SharedConsciousness(int spriteCount)
        {
            this.spriteCount = spriteCount;
        }
        #endregion

        #region Public Methods
        public void Clear()
        {
            foreach (Dictionary<AbstractSprite,bool> spriteList in internalList.Values)
                spriteList.Clear();
        }

        public bool IsSpriteViewable(AbstractSprite viewerSprite, AbstractSprite viewedSprite, AbstractMap map, int fov)
        {
            Dictionary<AbstractSprite, bool> viewedList;
            if (!internalList.TryGetValue(viewerSprite, out viewedList))
            {
                viewedList = new Dictionary<AbstractSprite, bool>();
                internalList.Add(viewerSprite, viewedList);
            }

            bool isViewed;
            if (!viewedList.TryGetValue(viewedSprite, out isViewed))
            {
                isViewed = Optics.IsSpriteViewable(viewerSprite, viewedSprite, map, fov);
                viewedList.Add(viewedSprite, isViewed);
            }

            return isViewed;
        }
        #endregion
    }
}
