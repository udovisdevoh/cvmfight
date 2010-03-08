using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    /// <summary>
    /// Physics
    /// </summary>
    static class Physics
    {
        #region Constants
        private static double spriteToMapCollisionPrecision = 0.05;
        #endregion

        #region Public Methods
        /// <summary>
        /// Whether sprite is in collision with another sprite or the map
        /// </summary>
        /// <param name="sprite">sprite</param>
        /// <param name="spritePool">sprite pool</param>
        /// <param name="map">map</param>
        /// <returns>Whether sprite is in collision with another sprite or the map</returns>
        public static bool IsDetectCollision(AbstractSprite sprite, SpritePool spritePool, AbstractMap map)
        {
            return IsDetectSpriteCollision(sprite, spritePool) || IsDetectMapCollision(sprite, map);
        }

        /// <summary>
        /// Whether sprite is in collision with sprite pool
        /// </summary>
        /// <param name="sprite">sprite</param>
        /// <param name="spritePool">sprite pool</param>
        /// <returns>Whether sprite is in collision with sprite pool</returns>
        public static bool IsDetectSpriteCollision(AbstractSprite sprite, SpritePool spritePool)
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
        public static bool IsDetectSpriteCollision(AbstractSprite sprite1, AbstractSprite sprite2)
        {
            return GetSpriteDistance(sprite1, sprite2) < sprite1.Radius + sprite2.Radius;
        }

        /// <summary>
        /// Whether sprite is in collision with map walls
        /// </summary>
        /// <param name="sprite">sprite</param>
        /// <param name="map">map</param>
        /// <returns>Whether sprite is in collision with map walls</returns>
        public static bool IsDetectMapCollision(AbstractSprite sprite, AbstractMap map)
        {
            double currentRadius = sprite.Radius;

            do
            {
                if (sprite.PositionX < 0 || sprite.PositionY < 0 || sprite.PositionX >= map.Width || sprite.PositionY >= map.Height)
                    return true;
                else if (map.GetMatterTypeAt(sprite.PositionX - sprite.Radius, sprite.PositionY - sprite.Radius) != null)
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
        public static double GetSpriteDistance(AbstractSprite sprite1, AbstractSprite sprite2)
        {
            return Math.Sqrt(Math.Pow(sprite2.PositionX - sprite1.PositionX, 2) + Math.Pow(sprite2.PositionY - sprite1.PositionY, 2));
        }

        /// <summary>
        /// Make walk sprite
        /// </summary>
        /// <param name="sprite">sprite</param>
        /// <param name="spritePool">other sprites</param>
        /// <param name="map">map</param>
        /// <param name="timeDelta">time delta</param>
        public static void TryMakeWalk(AbstractSprite sprite, SpritePool spritePool, AbstractMap map, double timeDelta)
        {
            TryMakeWalk(sprite, 0, spritePool, map, timeDelta);
        }

        /// <summary>
        /// Make walk sprite
        /// </summary>
        /// <param name="sprite">sprite</param>
        /// <param name="angleOffsetRadian">angle offset (default 0) (in radian)</param>
        /// <param name="spritePool">other sprites</param>
        /// <param name="map">map</param>
        /// <param name="timeDelta">time delta</param>
        public static void TryMakeWalk(AbstractSprite sprite, double angleOffsetRadian, SpritePool spritePool, AbstractMap map, double timeDelta)
        {
            double xMove = Math.Cos(sprite.AngleRadian + angleOffsetRadian) * sprite.DefaultWalkingDistance * timeDelta;
            double yMove = Math.Sin(sprite.AngleRadian + angleOffsetRadian) * sprite.DefaultWalkingDistance * timeDelta;

            if (sprite.IsCrouch)
            {
                xMove *= sprite.CrouchSpeedMultiplier;
                yMove *= sprite.CrouchSpeedMultiplier;
            }

            sprite.PositionX += xMove;
            if (IsDetectCollision(sprite,spritePool,map))
                sprite.PositionX -= xMove;

            sprite.PositionY += yMove;
            if (IsDetectCollision(sprite,spritePool,map))
                sprite.PositionY -= yMove;
        }

        public static void TryMakeRotate(AbstractSprite sprite, short angleRotationStrength)
        {
            sprite.AngleRadian += ((double)angleRotationStrength / -200);
        }

        public static void MakeJump(AbstractSprite sprite)
        {
            if (!sprite.IsNeedToJumpAgain)
            {
                if (sprite.PositionZ <= 0)
                    sprite.CurrentJumpAcceleration = sprite.MaxJumpAcceleration;
                else
                    sprite.CurrentJumpAcceleration += 0.05;

                if (sprite.CurrentJumpAcceleration < 0)
                {
                    sprite.IsNeedToJumpAgain = true;
                }
            }
        }

        public static void MakeFall(AbstractSprite sprite, double timeDelta)
        {
            sprite.CurrentJumpAcceleration -= 0.1;
            sprite.PositionZ += sprite.CurrentJumpAcceleration / 10 * timeDelta;

            sprite.PositionZ = Math.Max(0, sprite.PositionZ);           
        }
        #endregion
    }
}
