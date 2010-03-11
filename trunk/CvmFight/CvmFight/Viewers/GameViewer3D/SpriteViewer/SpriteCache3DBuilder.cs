﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class SpriteCache3DBuilder
    {
        #region Public Methods
        public SpriteCache3D Build(AbstractSprite sprite, bool isEnableSpriteCache)
        {
            SpriteCache3D spriteCache = new SpriteCache3D(isEnableSpriteCache);
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
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Hit, "Assets/Textures/Sprites/StickMan/StickManFrontLeftHit.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, "Assets/Textures/Sprites/StickMan/StickManLeftCrouch.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, "Assets/Textures/Sprites/StickMan/StickManLeftCrouchBlock.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, "Assets/Textures/Sprites/StickMan/StickManLeftCrouch.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, "Assets/Textures/Sprites/StickMan/StickManFrontLeftKick1.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, "Assets/Textures/Sprites/StickMan/StickManFrontLeftKick2.png"));

                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk1, "Assets/Textures/Sprites/StickMan/StickManFrontLeftWalk1.png",true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk2, "Assets/Textures/Sprites/StickMan/StickManFrontLeftWalk2.png",true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch, "Assets/Textures/Sprites/StickMan/StickManFrontLeftPunch.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Block, "Assets/Textures/Sprites/StickMan/StickManFrontLeftBlock.png",true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Hit, "Assets/Textures/Sprites/StickMan/StickManFrontLeftHit.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, "Assets/Textures/Sprites/StickMan/StickManLeftCrouch.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, "Assets/Textures/Sprites/StickMan/StickManLeftCrouchBlock.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, "Assets/Textures/Sprites/StickMan/StickManLeftCrouch.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, "Assets/Textures/Sprites/StickMan/StickManFrontLeftKick1.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, "Assets/Textures/Sprites/StickMan/StickManFrontLeftKick2.png", true));

                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk1, "Assets/Textures/Sprites/StickMan/StickManBackLeftWalk1.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk2, "Assets/Textures/Sprites/StickMan/StickManBackLeftWalk2.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Block, "Assets/Textures/Sprites/StickMan/StickManBackLeftBlock.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch, "Assets/Textures/Sprites/StickMan/StickManBackLeftPunch.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Hit, "Assets/Textures/Sprites/StickMan/StickManBackLeftHit.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, "Assets/Textures/Sprites/StickMan/StickManBackLeftCrouchBlock.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, "Assets/Textures/Sprites/StickMan/StickManBackLeftCrouchBlock.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, "Assets/Textures/Sprites/StickMan/StickManBackLeftCrouchBlock.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, "Assets/Textures/Sprites/StickMan/StickManBackLeftKick1.png"));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, "Assets/Textures/Sprites/StickMan/StickManBackLeftKick2.png"));

                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk1, "Assets/Textures/Sprites/StickMan/StickManBackLeftWalk1.png",true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk2, "Assets/Textures/Sprites/StickMan/StickManBackLeftWalk2.png",true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Block, "Assets/Textures/Sprites/StickMan/StickManBackLeftBlock.png",true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch, "Assets/Textures/Sprites/StickMan/StickManBackLeftPunch.png",true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Hit, "Assets/Textures/Sprites/StickMan/StickManBackLeftHit.png",true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, "Assets/Textures/Sprites/StickMan/StickManBackLeftCrouchBlock.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, "Assets/Textures/Sprites/StickMan/StickManBackLeftCrouchBlock.png", true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, "Assets/Textures/Sprites/StickMan/StickManBackLeftCrouchBlock.png",true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, "Assets/Textures/Sprites/StickMan/StickManBackLeftKick1.png",true));
                spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, "Assets/Textures/Sprites/StickMan/StickManBackLeftKick2.png",true));

                //For non-centered sprites images
                spriteCache.SetOffset(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, 0.5, 0);
                spriteCache.SetOffset(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, 0.5, 0);

                spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, -0.5, 0);
                spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, 0.5, 0);

                spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, -0.5, 0);
                spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, 0.5, 0);
            }
            return spriteCache;
        }
        #endregion
    }
}