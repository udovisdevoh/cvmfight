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
                spriteCache.AddFrame(new SpriteFrame(SpriteFrame.Front, SpriteFrame.Walk1, "StickManFrontWalk1.png"));
                spriteCache.AddFrame(new SpriteFrame(SpriteFrame.Front, SpriteFrame.Walk2, "StickManFrontWalk2.png"));
                spriteCache.AddFrame(new SpriteFrame(SpriteFrame.Front, SpriteFrame.Punch, "StickManFrontPunch.png"));
                spriteCache.AddFrame(new SpriteFrame(SpriteFrame.Front, SpriteFrame.Kick1, "StickManFrontKick1.png"));
                spriteCache.AddFrame(new SpriteFrame(SpriteFrame.Front, SpriteFrame.Kick2, "StickManFrontKick2.png"));
                spriteCache.AddFrame(new SpriteFrame(SpriteFrame.Front, SpriteFrame.Block, "StickManFrontBlock.png"));
                spriteCache.AddFrame(new SpriteFrame(SpriteFrame.Front, SpriteFrame.Crouch, "StickManFrontCrouch.png"));
                spriteCache.AddFrame(new SpriteFrame(SpriteFrame.Front, SpriteFrame.CrouchBlock, "StickManFrontCrouchBlock.png"));
                spriteCache.AddFrame(new SpriteFrame(SpriteFrame.Front, SpriteFrame.Hit, "StickManFrontHit.png"));
            }
            return spriteCache;
        }
    }
}