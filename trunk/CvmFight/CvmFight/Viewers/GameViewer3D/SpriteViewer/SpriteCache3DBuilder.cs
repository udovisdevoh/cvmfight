using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class SpriteCache3DBuilder
    {
        #region Public Methods
        public SpriteCache3D Build(AbstractSprite sprite)
        {
            SpriteCache3D spriteCache = new SpriteCache3D();
            if (sprite is MonsterStickMan)
            {
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk1, "Assets/Textures/Sprites/StickMan/StickManFrontWalk1.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk2, "Assets/Textures/Sprites/StickMan/StickManFrontWalk2.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch, "Assets/Textures/Sprites/StickMan/StickManFrontPunch.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, "Assets/Textures/Sprites/StickMan/StickManFrontKick1.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, "Assets/Textures/Sprites/StickMan/StickManFrontKick2.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Block, "Assets/Textures/Sprites/StickMan/StickManFrontBlock.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, "Assets/Textures/Sprites/StickMan/StickManFrontCrouch.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, "Assets/Textures/Sprites/StickMan/StickManFrontCrouchBlock.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Hit, "Assets/Textures/Sprites/StickMan/StickManFrontHit.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, "Assets/Textures/Sprites/StickMan/StickManFrontCrouchHit.png"));

                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk1, "Assets/Textures/Sprites/StickMan/StickManLeftWalk1.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk2, "Assets/Textures/Sprites/StickMan/StickManLeftWalk2.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch, "Assets/Textures/Sprites/StickMan/StickManLeftPunch.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, "Assets/Textures/Sprites/StickMan/StickManLeftKick1.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, "Assets/Textures/Sprites/StickMan/StickManLeftKick2.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Block, "Assets/Textures/Sprites/StickMan/StickManLeftBlock.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, "Assets/Textures/Sprites/StickMan/StickManLeftCrouch.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, "Assets/Textures/Sprites/StickMan/StickManLeftCrouchBlock.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Hit, "Assets/Textures/Sprites/StickMan/StickManLeftHit.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, "Assets/Textures/Sprites/StickMan/StickManLeftCrouch.png"));

                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk1, "Assets/Textures/Sprites/StickMan/StickManLeftWalk1.png",true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk2, "Assets/Textures/Sprites/StickMan/StickManLeftWalk2.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch, "Assets/Textures/Sprites/StickMan/StickManLeftPunch.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, "Assets/Textures/Sprites/StickMan/StickManLeftKick1.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, "Assets/Textures/Sprites/StickMan/StickManLeftKick2.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Block, "Assets/Textures/Sprites/StickMan/StickManLeftBlock.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, "Assets/Textures/Sprites/StickMan/StickManLeftCrouch.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, "Assets/Textures/Sprites/StickMan/StickManLeftCrouchBlock.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Hit, "Assets/Textures/Sprites/StickMan/StickManLeftHit.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, "Assets/Textures/Sprites/StickMan/StickManLeftCrouch.png", true));

                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk1, "Assets/Textures/Sprites/StickMan/StickManBackWalk1.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk2, "Assets/Textures/Sprites/StickMan/StickManBackWalk2.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch, "Assets/Textures/Sprites/StickMan/StickManBackPunchBlock.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, "Assets/Textures/Sprites/StickMan/StickManBackKick.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, "Assets/Textures/Sprites/StickMan/StickManBackKick.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Block, "Assets/Textures/Sprites/StickMan/StickManBackPunchBlock.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, "Assets/Textures/Sprites/StickMan/StickManBackCrouch.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, "Assets/Textures/Sprites/StickMan/StickManBackCrouch.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Hit, "Assets/Textures/Sprites/StickMan/StickManBackHit.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, "Assets/Textures/Sprites/StickMan/StickManBackCrouch.png"));

                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk1, "Assets/Textures/Sprites/StickMan/StickManFrontLeftWalk1.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk2, "Assets/Textures/Sprites/StickMan/StickManFrontLeftWalk2.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch, "Assets/Textures/Sprites/StickMan/StickManFrontLeftPunch.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Block, "Assets/Textures/Sprites/StickMan/StickManFrontLeftBlock.png"));

                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk1, "Assets/Textures/Sprites/StickMan/StickManFrontLeftWalk1.png",true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk2, "Assets/Textures/Sprites/StickMan/StickManFrontLeftWalk2.png",true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch, "Assets/Textures/Sprites/StickMan/StickManFrontLeftPunch.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Block, "Assets/Textures/Sprites/StickMan/StickManFrontLeftBlock.png",true));

                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk1, "Assets/Textures/Sprites/StickMan/StickManBackLeftWalk1.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk2, "Assets/Textures/Sprites/StickMan/StickManBackLeftWalk2.png"));

                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk1, "Assets/Textures/Sprites/StickMan/StickManBackLeftWalk1.png",true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk2, "Assets/Textures/Sprites/StickMan/StickManBackLeftWalk2.png",true));
            }
            return spriteCache;
        }
        #endregion
    }
}