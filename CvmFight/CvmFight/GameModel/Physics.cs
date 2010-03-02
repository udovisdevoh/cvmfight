using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    /// <summary>
    /// Physics
    /// </summary>
    class Physics
    {
        #region Constants
        private double spriteToMapCollisionPrecision = 0.05;
        #endregion

        #region Public Methods
        /// <summary>
        /// Whether sprite is in collision with another sprite or the map
        /// </summary>
        /// <param name="sprite">sprite</param>
        /// <param name="spritePool">sprite pool</param>
        /// <param name="map">map</param>
        /// <returns>Whether sprite is in collision with another sprite or the map</returns>
        public bool IsDetectCollision(AbstractSprite sprite, SpritePool spritePool, AbstractMap map)
        {
            return IsDetectSpriteCollision(sprite, spritePool) || IsDetectMapCollision(sprite, map);
        }

        /// <summary>
        /// Whether sprite is in collision with sprite pool
        /// </summary>
        /// <param name="sprite">sprite</param>
        /// <param name="spritePool">sprite pool</param>
        /// <returns>Whether sprite is in collision with sprite pool</returns>
        public bool IsDetectSpriteCollision(AbstractSprite sprite, SpritePool spritePool)
        {
            foreach (AbstractSprite otherSprite in spritePool)
                if (sprite != otherSprite)
                    if (IsDetectSpriteCollision(sprite, otherSprite))
                        return true;
            return false;
        }

        /// <summary>
        /// Whether sprite 1 is in collision with sprite 2
        /// </summary>
        /// <param name="sprite1">sprite 1</param>
        /// <param name="sprite2">sprite 2</param>
        /// <returns>Whether sprite 1 is in collision with sprite 2</returns>
        public bool IsDetectSpriteCollision(AbstractSprite sprite1, AbstractSprite sprite2)
        {
            return GetSpriteDistance(sprite1, sprite2) < sprite1.Radius + sprite2.Radius;
        }

        /// <summary>
        /// Whether sprite is in collision with map walls
        /// </summary>
        /// <param name="sprite">sprite</param>
        /// <param name="map">map</param>
        /// <returns>Whether sprite is in collision with map walls</returns>
        public bool IsDetectMapCollision(AbstractSprite sprite, AbstractMap map)
        {
            double currentRadius = sprite.Radius;

            do
            {
                if (map.GetMatterTypeAt(sprite.PositionX - sprite.Radius, sprite.PositionY - sprite.Radius) != null)
                    return true;
                else if (map.GetMatterTypeAt(sprite.PositionX, sprite.PositionY - sprite.Radius) != null)
                    return true;
                else if (map.GetMatterTypeAt(sprite.PositionX + sprite.Radius, sprite.PositionY - sprite.Radius) != null)
                    return true;
                else if (map.GetMatterTypeAt(sprite.PositionX - sprite.Radius, sprite.PositionY) != null)
                    return true;
                else if (map.GetMatterTypeAt(sprite.PositionX + sprite.Radius, sprite.PositionY) != null)
                    return true;
                else if (map.GetMatterTypeAt(sprite.PositionX - sprite.Radius, sprite.PositionY + sprite.Radius) != null)
                    return true;
                else if (map.GetMatterTypeAt(sprite.PositionX, sprite.PositionY + sprite.Radius) != null)
                    return true;
                else if (map.GetMatterTypeAt(sprite.PositionX + sprite.Radius, sprite.PositionY + sprite.Radius) != null)
                    return true;

                currentRadius -= spriteToMapCollisionPrecision;
            } while (currentRadius > 0);

            return false;
        }

        /// <summary>
        /// Returns distance between 2 sprites
        /// </summary>
        /// <param name="sprite1">sprite 1</param>
        /// <param name="sprite2">sprite 2</param>
        /// <returns>distance between 2 sprites</returns>
        public double GetSpriteDistance(AbstractSprite sprite1, AbstractSprite sprite2)
        {
            return Math.Sqrt(Math.Pow(sprite2.PositionX - sprite1.PositionX, 2) + Math.Pow(sprite2.PositionY - sprite1.PositionY, 2));
        }

        /// <summary>
        /// Make walk sprite
        /// </summary>
        /// <param name="sprite">sprite</param>
        public void TryMakeWalk(AbstractSprite sprite)
        {
            TryMakeWalk(sprite, 0);
        }

        /// <summary>
        /// Make walk sprite
        /// </summary>
        /// <param name="sprite">sprite</param>
        /// <param name="angleOffsetRadian">angle offset (default 0) (in radian)</param>
        public void TryMakeWalk(AbstractSprite sprite, double angleOffsetRadian)
        {
            double xMove = Math.Cos(sprite.AngleRadian + angleOffsetRadian) * sprite.DefaultWalkingDistance;
            double yMove = Math.Sin(sprite.AngleRadian + angleOffsetRadian) * sprite.DefaultWalkingDistance;

            sprite.PositionX += xMove;
            sprite.PositionY += yMove;
        }
        #endregion
    }
}
