using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class SpritePool : IList<AbstractHumanoid>
    {
        #region Fields
        private HashSet<AbstractHumanoid> internalHash = new HashSet<AbstractHumanoid>();

        private List<AbstractHumanoid> internalList = new List<AbstractHumanoid>();
        #endregion

        #region Constructors
        /// <summary>
        /// Create sprite pool
        /// </summary>
        /// <param name="spriteToAdd">sprite to add</param>
        public SpritePool(AbstractHumanoid spriteToAdd)
        {
            Add(spriteToAdd);
        }

        /// <summary>
        /// Create sprite pool
        /// </summary>
        public SpritePool()
        {
        }
        #endregion

        #region IList<AbstractSprite> Membres
        public int IndexOf(AbstractHumanoid item)
        {
            return internalList.IndexOf(item);
        }

        public void Insert(int index, AbstractHumanoid item)
        {
            internalList.Insert(index, item);
            internalHash.Add(item);
        }

        public void RemoveAt(int index)
        {
            internalHash.Remove(internalList[index]);
            internalList.RemoveAt(index);
        }

        public AbstractHumanoid this[int index]
        {
            get
            {
                return internalList[index];
            }
            set
            {
                internalHash.Add(value);
                internalList[index] = value;
            }
        }

        public void Add(AbstractHumanoid item)
        {
            internalHash.Add(item);
            internalList.Add(item);
        }

        public void Clear()
        {
            internalList.Clear();
            internalHash.Clear();
        }

        public bool Contains(AbstractHumanoid item)
        {
            return internalHash.Contains(item);
        }

        public void CopyTo(AbstractHumanoid[] array, int arrayIndex)
        {
            internalList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return internalList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(AbstractHumanoid item)
        {
            return internalHash.Remove(item) && internalList.Remove(item);
        }

        public IEnumerator<AbstractHumanoid> GetEnumerator()
        {
            return internalList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return internalList.GetEnumerator();
        }
        #endregion

        public void SortByDistance(AbstractHumanoid referenceSprite)
        {
            foreach (AbstractHumanoid sprite in internalList)
                sprite.DistanceToReferenceSprite = Optics.GetStraightDistance(referenceSprite, sprite);

            internalList.Sort();
        }
    }
}
