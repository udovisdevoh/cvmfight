﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class SpriteCache3DBuilder
    {
        #region Public Methods
        public SpriteCache3D Build(AbstractHumanoid sprite, bool isEnableSpriteCache, bool isEnableLazySpriteImageLoad)
        {
            SpriteCache3D spriteCache = new SpriteCache3D(isEnableSpriteCache, isEnableLazySpriteImageLoad);
            if (sprite is MonsterStickMan)
            {
                BuildStickMan(spriteCache, isEnableLazySpriteImageLoad);
            }
            else if (sprite is MonsterNutKunDo)
            {
                BuildNutKunDo(spriteCache,isEnableLazySpriteImageLoad);
            }
            else if (sprite is MonsterAladdin)
            {
                BuildAladdin(spriteCache, isEnableLazySpriteImageLoad);
            }
            return spriteCache;
        }
        #endregion

        #region Private Methods
        private void BuildStickMan(SpriteCache3D spriteCache, bool isEnableLazySpriteImageLoad)
        {
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/StickMan/StickManFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/StickMan/StickManFrontWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/StickMan/StickManFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/StickMan/StickManFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/StickMan/StickManFrontKick1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/StickMan/StickManFrontKick2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/StickMan/StickManFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/StickMan/StickManFrontCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/StickMan/StickManFrontCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/StickMan/StickManFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/StickMan/StickManFrontCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/StickMan/StickManLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/StickMan/StickManLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/StickMan/StickManFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/StickMan/StickManLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/StickMan/StickManLeftKick1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/StickMan/StickManLeftKick2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/StickMan/StickManLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/StickMan/StickManLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/StickMan/StickManLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/StickMan/StickManLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/StickMan/StickManLeftCrouch.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/StickMan/StickManLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/StickMan/StickManLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/StickMan/StickManFrontWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/StickMan/StickManLeftPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/StickMan/StickManLeftKick1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/StickMan/StickManLeftKick2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/StickMan/StickManLeftBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/StickMan/StickManLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/StickMan/StickManLeftCrouchBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/StickMan/StickManLeftHit.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/StickMan/StickManLeftCrouch.png", true, isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/StickMan/StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/StickMan/StickManBackWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/StickMan/StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/StickMan/StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/StickMan/StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/StickMan/StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/StickMan/StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/StickMan/StickManBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/StickMan/StickManBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/StickMan/StickManBackHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/StickMan/StickManBackCrouch.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/StickMan/StickManFrontLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/StickMan/StickManFrontLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/StickMan/StickManFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/StickMan/StickManFrontLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/StickMan/StickManFrontLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/StickMan/StickManFrontLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/StickMan/StickManLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/StickMan/StickManLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/StickMan/StickManLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/StickMan/StickManFrontLeftKick1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/StickMan/StickManFrontLeftKick2.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/StickMan/StickManFrontLeftWalk1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/StickMan/StickManFrontLeftWalk2.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/StickMan/StickManFrontWalk1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/StickMan/StickManFrontLeftPunch2.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/StickMan/StickManFrontLeftBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/StickMan/StickManFrontLeftHit.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/StickMan/StickManLeftCrouch.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/StickMan/StickManLeftCrouchBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/StickMan/StickManLeftCrouch.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/StickMan/StickManFrontLeftKick1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/StickMan/StickManFrontLeftKick2.png", true));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/StickMan/StickManFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftKick1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftKick2.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftWalk1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftWalk2.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/StickMan/StickManFrontWalk1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftPunch2.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftHit.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftCrouchBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftCrouchBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftCrouchBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftKick1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/StickMan/StickManBackLeftKick2.png", true));




            //For non-centered sprites images
            spriteCache.SetOffset(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, 0.5, 0);



            //For different scalling of the image
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, 0.5);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, 0.666);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, 0.75);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, 0.5);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, 0.5);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, 0.5);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, 0.5);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, 0.5);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, 0.5);




            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, 0.666);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, 0.75);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, 0.666);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, 0.75);
        }

        private void BuildNutKunDo(SpriteCache3D spriteCache, bool isEnableLazySpriteImageLoad)
        {
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackCrouch.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftWalk1.png",true , isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftCrouchPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftCrouchPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftCrouchBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftHit.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoLeftCrouchHit.png", true, isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftCrouchPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftCrouchPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftCrouchBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftHit.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoFrontLeftCrouchHit.png",true , isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftCrouchPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftCrouchPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftCrouchBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftHit.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/NutKunDo/NutKunDoBackLeftCrouchHit.png", true, isEnableLazySpriteImageLoad));


            //For different scalling
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, 0.6);

            //Offsets
            spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, -0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, 0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, -0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, 0.333, 0);
        }

        private void BuildAladdin(SpriteCache3D spriteCache, bool isEnableLazySpriteImageLoad)
        {
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/Aladdin/AladdinBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/Aladdin/AladdinBackWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/Aladdin/AladdinBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/Aladdin/AladdinBackWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/Aladdin/AladdinBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/Aladdin/AladdinBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/Aladdin/AladdinBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/Aladdin/AladdinBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/Aladdin/AladdinBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/Aladdin/AladdinBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/Aladdin/AladdinBackCrouch.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftCrouchPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftCrouchPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftCrouchBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftHit.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/Aladdin/AladdinLeftCrouchHit.png", true, isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftCrouchPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftCrouchPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftCrouchBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftHit.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/Aladdin/AladdinFrontLeftCrouchHit.png", true, isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftCrouch.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk1, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk2, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch1, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Block, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Hit, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, "CvmFight/Assets/Sprites/Aladdin/AladdinBackLeftCrouch.png", true, isEnableLazySpriteImageLoad));


            //For different scalling
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Hit, 0.66);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, 0.6);

            //Offsets
            spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, -0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, 0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, -0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, 0.333, 0);
        }
        #endregion
    }
}