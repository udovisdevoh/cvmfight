﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class SpriteCache3DBuilder
    {
        #region Public Methods
        public SpriteCache3D Build(AbstractSprite sprite, bool isEnableSpriteCache, bool isEnableLazySpriteImageLoad)
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
            return spriteCache;
        }
        #endregion

        #region Private Methods
        private void BuildStickMan(SpriteCache3D spriteCache, bool isEnableLazySpriteImageLoad)
        {
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk1, "Assets/Sprites/StickMan/StickManFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk2, "Assets/Sprites/StickMan/StickManFrontWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch1, "Assets/Sprites/StickMan/StickManFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch2, "Assets/Sprites/StickMan/StickManFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, "Assets/Sprites/StickMan/StickManFrontKick1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, "Assets/Sprites/StickMan/StickManFrontKick2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Block, "Assets/Sprites/StickMan/StickManFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, "Assets/Sprites/StickMan/StickManFrontCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/StickMan/StickManFrontCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Hit, "Assets/Sprites/StickMan/StickManFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, "Assets/Sprites/StickMan/StickManFrontCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk1, "Assets/Sprites/StickMan/StickManLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk2, "Assets/Sprites/StickMan/StickManLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch1, "Assets/Sprites/StickMan/StickManFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, "Assets/Sprites/StickMan/StickManLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, "Assets/Sprites/StickMan/StickManLeftKick1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, "Assets/Sprites/StickMan/StickManLeftKick2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Block, "Assets/Sprites/StickMan/StickManLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, "Assets/Sprites/StickMan/StickManLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/StickMan/StickManLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Hit, "Assets/Sprites/StickMan/StickManLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, "Assets/Sprites/StickMan/StickManLeftCrouch.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk1, "Assets/Sprites/StickMan/StickManLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk2, "Assets/Sprites/StickMan/StickManLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch1, "Assets/Sprites/StickMan/StickManFrontWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, "Assets/Sprites/StickMan/StickManLeftPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, "Assets/Sprites/StickMan/StickManLeftKick1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, "Assets/Sprites/StickMan/StickManLeftKick2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Block, "Assets/Sprites/StickMan/StickManLeftBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, "Assets/Sprites/StickMan/StickManLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/StickMan/StickManLeftCrouchBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Hit, "Assets/Sprites/StickMan/StickManLeftHit.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, "Assets/Sprites/StickMan/StickManLeftCrouch.png", true, isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk1, "Assets/Sprites/StickMan/StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk2, "Assets/Sprites/StickMan/StickManBackWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch1, "Assets/Sprites/StickMan/StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch2, "Assets/Sprites/StickMan/StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, "Assets/Sprites/StickMan/StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, "Assets/Sprites/StickMan/StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Block, "Assets/Sprites/StickMan/StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, "Assets/Sprites/StickMan/StickManBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/StickMan/StickManBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Hit, "Assets/Sprites/StickMan/StickManBackHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, "Assets/Sprites/StickMan/StickManBackCrouch.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk1, "Assets/Sprites/StickMan/StickManFrontLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk2, "Assets/Sprites/StickMan/StickManFrontLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch1, "Assets/Sprites/StickMan/StickManFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, "Assets/Sprites/StickMan/StickManFrontLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Block, "Assets/Sprites/StickMan/StickManFrontLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Hit, "Assets/Sprites/StickMan/StickManFrontLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, "Assets/Sprites/StickMan/StickManLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/StickMan/StickManLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, "Assets/Sprites/StickMan/StickManLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, "Assets/Sprites/StickMan/StickManFrontLeftKick1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, "Assets/Sprites/StickMan/StickManFrontLeftKick2.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk1, "Assets/Sprites/StickMan/StickManFrontLeftWalk1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk2, "Assets/Sprites/StickMan/StickManFrontLeftWalk2.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch1, "Assets/Sprites/StickMan/StickManFrontWalk1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, "Assets/Sprites/StickMan/StickManFrontLeftPunch2.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Block, "Assets/Sprites/StickMan/StickManFrontLeftBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Hit, "Assets/Sprites/StickMan/StickManFrontLeftHit.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, "Assets/Sprites/StickMan/StickManLeftCrouch.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/StickMan/StickManLeftCrouchBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, "Assets/Sprites/StickMan/StickManLeftCrouch.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, "Assets/Sprites/StickMan/StickManFrontLeftKick1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, "Assets/Sprites/StickMan/StickManFrontLeftKick2.png", true));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk1, "Assets/Sprites/StickMan/StickManBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk2, "Assets/Sprites/StickMan/StickManBackLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Block, "Assets/Sprites/StickMan/StickManBackLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch1, "Assets/Sprites/StickMan/StickManFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, "Assets/Sprites/StickMan/StickManBackLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Hit, "Assets/Sprites/StickMan/StickManBackLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, "Assets/Sprites/StickMan/StickManBackLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/StickMan/StickManBackLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, "Assets/Sprites/StickMan/StickManBackLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, "Assets/Sprites/StickMan/StickManBackLeftKick1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, "Assets/Sprites/StickMan/StickManBackLeftKick2.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk1, "Assets/Sprites/StickMan/StickManBackLeftWalk1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk2, "Assets/Sprites/StickMan/StickManBackLeftWalk2.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Block, "Assets/Sprites/StickMan/StickManBackLeftBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch1, "Assets/Sprites/StickMan/StickManFrontWalk1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, "Assets/Sprites/StickMan/StickManBackLeftPunch2.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Hit, "Assets/Sprites/StickMan/StickManBackLeftHit.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, "Assets/Sprites/StickMan/StickManBackLeftCrouchBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/StickMan/StickManBackLeftCrouchBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, "Assets/Sprites/StickMan/StickManBackLeftCrouchBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, "Assets/Sprites/StickMan/StickManBackLeftKick1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, "Assets/Sprites/StickMan/StickManBackLeftKick2.png", true));




            //For non-centered sprites images
            spriteCache.SetOffset(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, -0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, 0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, -0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, 0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, -0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, 0.333, 0);



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
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk1, "Assets/Sprites/NutKunDo/NutKunDoFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk2, "Assets/Sprites/NutKunDo/NutKunDoFrontWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch1, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch2, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Block, "Assets/Sprites/NutKunDo/NutKunDoFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Hit, "Assets/Sprites/NutKunDo/NutKunDoFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk1, "Assets/Sprites/NutKunDo/NutKunDoBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk2, "Assets/Sprites/NutKunDo/NutKunDoBackWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch1, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch2, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Block, "Assets/Sprites/NutKunDo/NutKunDoFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, "Assets/Sprites/NutKunDo/NutKunDoBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/NutKunDo/NutKunDoBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Hit, "Assets/Sprites/NutKunDo/NutKunDoFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, "Assets/Sprites/NutKunDo/NutKunDoBackCrouch.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk1, "Assets/Sprites/NutKunDo/NutKunDoFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk2, "Assets/Sprites/NutKunDo/NutKunDoFrontWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch1, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Block, "Assets/Sprites/NutKunDo/NutKunDoFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Hit, "Assets/Sprites/NutKunDo/NutKunDoFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk1, "Assets/Sprites/NutKunDo/NutKunDoFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk2, "Assets/Sprites/NutKunDo/NutKunDoFrontWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch1, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Block, "Assets/Sprites/NutKunDo/NutKunDoFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Hit, "Assets/Sprites/NutKunDo/NutKunDoFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk1, "Assets/Sprites/NutKunDo/NutKunDoFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk2, "Assets/Sprites/NutKunDo/NutKunDoFrontWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch1, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Block, "Assets/Sprites/NutKunDo/NutKunDoFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Hit, "Assets/Sprites/NutKunDo/NutKunDoFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk1, "Assets/Sprites/NutKunDo/NutKunDoFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk2, "Assets/Sprites/NutKunDo/NutKunDoFrontWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch1, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Block, "Assets/Sprites/NutKunDo/NutKunDoFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Hit, "Assets/Sprites/NutKunDo/NutKunDoFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk1, "Assets/Sprites/NutKunDo/NutKunDoFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk2, "Assets/Sprites/NutKunDo/NutKunDoFrontWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch1, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Block, "Assets/Sprites/NutKunDo/NutKunDoFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Hit, "Assets/Sprites/NutKunDo/NutKunDoFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk1, "Assets/Sprites/NutKunDo/NutKunDoFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk2, "Assets/Sprites/NutKunDo/NutKunDoFrontWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch1, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, "Assets/Sprites/NutKunDo/NutKunDoFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Block, "Assets/Sprites/NutKunDo/NutKunDoFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Hit, "Assets/Sprites/NutKunDo/NutKunDoFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, "Assets/Sprites/NutKunDo/NutKunDoFrontCrouchHit.png", isEnableLazySpriteImageLoad));


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
        }
        #endregion
    }
}