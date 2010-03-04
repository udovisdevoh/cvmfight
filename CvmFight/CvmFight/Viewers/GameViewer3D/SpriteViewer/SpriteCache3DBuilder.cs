using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class SpriteCache3DBuilder
    {
        public SpriteCache3D Build(AbstractSprite sprite)
        {
            SpriteCache3D spriteCache = new SpriteCache3D();
            if (sprite is MonsterStickMan)
            {
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk1, "Textures/Sprites/StickMan/StickManFrontWalk1.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk2, "Textures/Sprites/StickMan/StickManFrontWalk2.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch, "Textures/Sprites/StickMan/StickManFrontPunch.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, "Textures/Sprites/StickMan/StickManFrontKick1.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, "Textures/Sprites/StickMan/StickManFrontKick2.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Block, "Textures/Sprites/StickMan/StickManFrontBlock.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, "Textures/Sprites/StickMan/StickManFrontCrouch.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, "Textures/Sprites/StickMan/StickManFrontCrouchBlock.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Hit, "Textures/Sprites/StickMan/StickManFrontHit.png"));
            }
            return spriteCache;
        }
    }
}