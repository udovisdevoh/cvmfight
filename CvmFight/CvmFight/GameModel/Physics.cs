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
            foreach (AbstractHumanoid otherSprite in spritePool)
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
        public static bool TryMakeWalk(AbstractSprite sprite, SpritePool spritePool, AbstractMap map, double timeDelta)
        {
            return TryMakeWalk(sprite, 0, spritePool, map, timeDelta);
        }

        /// <summary>
        /// Make walk sprite
        /// </summary>
        /// <param name="sprite">sprite</param>
        /// <param name="angleOffsetRadian">angle offset (default 0) (in radian)</param>
        /// <param name="spritePool">other sprites</param>
        /// <param name="map">map</param>
        /// <param name="timeDelta">time delta</param>
        public static bool TryMakeWalk(AbstractSprite sprite, double angleOffsetRadian, SpritePool spritePool, AbstractMap map, double timeDelta)
        {
            double xMove = Math.Cos(sprite.AngleRadian + angleOffsetRadian) * sprite.DefaultWalkingDistance * timeDelta;
            double yMove = Math.Sin(sprite.AngleRadian + angleOffsetRadian) * sprite.DefaultWalkingDistance * timeDelta;

            if (sprite is AbstractHumanoid)
            {
                AbstractHumanoid humanoid = (AbstractHumanoid)sprite;
                humanoid.WalkCycle.UnFire();
                humanoid.WalkCycle.Fire();
                humanoid.WalkCycle.Update(1);

                if (humanoid.IsCrouch)
                {
                    xMove *= humanoid.CrouchSpeedMultiplier;
                    yMove *= humanoid.CrouchSpeedMultiplier;
                }

                //If is attacking and not jumping
                if (humanoid.StrongAttackCycle.IsFired && humanoid.PositionZ <= 0)
                {
                    xMove *= humanoid.AttackWalkSpeedMultiplier;
                    yMove *= humanoid.AttackWalkSpeedMultiplier;
                }
            }

            //If is jump
            if (sprite.PositionZ > 0)
            {
                xMove *= sprite.JumpSpeedMultiplier;
                yMove *= sprite.JumpSpeedMultiplier;
            }

            sprite.PositionX += xMove;

            bool isDetectCollisionX = IsDetectCollision(sprite, spritePool, map);

            if (isDetectCollisionX)
                sprite.PositionX -= xMove;

            sprite.PositionY += yMove;

            bool isDetectCollisionY = IsDetectCollision(sprite, spritePool, map);

            if (isDetectCollisionY)
                sprite.PositionY -= yMove;

            return !(isDetectCollisionX || isDetectCollisionY);
        }

        /// <summary>
        /// Try make rotate sprite from mouse strength
        /// </summary>
        /// <param name="sprite">sprite</param>
        /// <param name="angleRotationStrength">rotation strength</param>
        public static void TryMakeRotate(AbstractSprite sprite, short angleRotationStrength)
        {
            sprite.AngleRadian += ((double)angleRotationStrength / -200);
        }

        /// <summary>
        /// Make jump sprite
        /// </summary>
        /// <param name="sprite">sprite</param>
        /// <param name="timeDelta">time delta</param>
        public static void MakeJump(AbstractSprite sprite, double timeDelta)
        {
            if (!sprite.IsNeedToJumpAgain)
            {
                if (sprite.PositionZ <= 0)
                {
                    sprite.CurrentJumpAcceleration = sprite.MaxJumpAcceleration;
                }
                else
                    sprite.CurrentJumpAcceleration += 0.065 * timeDelta;

                if (sprite.CurrentJumpAcceleration < 0)
                {
                    sprite.IsNeedToJumpAgain = true;
                }
            }
        }

        /// <summary>
        /// Make fall sprite
        /// </summary>
        /// <param name="sprite">sprite</param>
        /// <param name="timeDelta">time delta</param>
        public static void MakeFall(AbstractSprite sprite, double timeDelta)
        {
            sprite.PositionZ += sprite.CurrentJumpAcceleration / 10 * timeDelta;
            sprite.CurrentJumpAcceleration -= 0.1 * timeDelta;
            sprite.PositionZ = Math.Max(0, sprite.PositionZ);           
        }

        /// <summary>
        /// Whether prey is withing predator's attack range
        /// </summary>
        /// <param name="predator">predator sprite</param>
        /// <param name="prey">prey sprite</param>
        /// <returns>Whether prey is withing predator's attack range</returns>
        public static bool IsWithinAttackRange(AbstractHumanoid predator, AbstractSprite prey)
        {
            return Physics.GetSpriteDistance(predator, prey) <= GetAttackRange(predator, prey);// predatorAttackRange + prey.Radius;
        }

        /// <summary>
        /// Whether prey is withing predator's attack range
        /// </summary>
        /// <param name="predator">predator sprite</param>
        /// <param name="prey">prey sprite</param>
        /// <returns>Whether prey is withing predator's attack range</returns>
        public static bool IsWithinAttackRange(AbstractHumanoid predator, AbstractHumanoid prey, double multiplicator)
        {
            return Physics.GetSpriteDistance(predator, prey) <= GetAttackRange(predator, prey) * multiplicator;// predatorAttackRange + prey.Radius;
        }

        private static double GetAttackRange(AbstractHumanoid predator, AbstractSprite prey)
        {
            double predatorAttackRange = predator.AttackRange;
            if (predator.PositionZ > 0)
                predatorAttackRange *= predator.AttackRangeJumpMultiplier;

            return predatorAttackRange;
        }

        /// <summary>
        /// Whether sprite 1 can attack or block sprite 2 because angle allows it
        /// </summary>
        /// <param name="sprite1">sprite 1</param>
        /// <param name="sprite2">sprite 2</param>
        /// <returns>Whether sprite 1 can attack or block sprite 2 because angle allows it</returns>
        public static bool IsInAttackOrBlockAngle(AbstractHumanoid sprite1, AbstractHumanoid sprite2)
        {
            double angleToSprite = Optics.GetSpriteAngleToSpriteRadian(sprite1, sprite2);

            if (Math.Abs(angleToSprite - sprite1.AngleRadian) < sprite1.AttackAngleRange)
                return true;
            else if (Math.Abs(angleToSprite - sprite1.AngleRadian + Math.PI * 2.0) < sprite1.AttackAngleRange)
                return true;
            else if (Math.Abs(angleToSprite - sprite1.AngleRadian + Math.PI * 2.0) < sprite1.AttackAngleRange)
                return true;

            return false;
        }

        /// <summary>
        /// Whether predator can attack prey
        /// </summary>
        /// <param name="predator">predator</param>
        /// <param name="prey">prey</param>
        /// <returns>whether predator can attack prey</returns>
        public static bool IsInAttackHeight(AbstractHumanoid predator, AbstractHumanoid prey)
        {
            if (predator.IsCrouch)
            {
                if (prey.IsCrouch)
                {
                    return true;
                }
                else if (prey.PositionZ <= predator.Height / 2)
                {
                    return true;
                }
            }
            else
            {
                if (!prey.IsCrouch)
                {
                    return true;
                }
                else if (predator.PositionZ > 0 && predator.PositionZ < prey.Height / 2)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Whether sprite 1 has a valid height to block sprite2's attack
        /// </summary>
        /// <param name="sprite1">sprite 1</param>
        /// <param name="sprite2">sprite 2</param>
        /// <returns>whether sprite 1 has a valid height to block sprite2's attack</returns>
        public static bool IsInBlockingHeight(AbstractHumanoid sprite1, AbstractHumanoid sprite2)
        {
            if (!sprite1.IsCrouch && !sprite2.IsCrouch && sprite1.PositionZ <= 0 && sprite2.PositionZ <= 0)
                return true;

            if (sprite1.PositionZ > sprite2.Height / 4)
                return false;

            if (sprite1.IsCrouch && sprite2.PositionZ > 0)
                return false;

            if (!sprite1.IsCrouch && sprite2.IsCrouch)
                return false;

            return true;
        }
        #endregion
    }
}
