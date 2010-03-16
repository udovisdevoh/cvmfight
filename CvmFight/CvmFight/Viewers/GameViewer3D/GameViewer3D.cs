﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Primitives;

namespace CvmFight
{
    class GameViewer3D : AbstractGameViewer
    {
        #region Constants
        private double heightDistanceRatio = 2;
        #endregion

        #region Fields and parts
        private bool isMiniMapOn;

        private bool isSoundOn;

        private int screenWidth;

        private int screenHeight;

        private Surface mainSurface;

        private ColumnViewer columnViewer;

        private SpriteViewer3D spriteViewer;

        private Gradient gradient;

        private MiniMap minimap;

        private SoundManager soundManager;

        private Hud hud;

        private Random random;
        #endregion

        #region Constructor
        public GameViewer3D(Surface mainSurface, int screenWidth, int screenHeight, int columnCount, SpritePool spritePool, int fov, bool isEnableSpriteCache, Random random, bool isEnableLazySpriteImageLoad, AbstractMap map, bool isSoundOn)
        {
            this.mainSurface = mainSurface;
            this.isSoundOn = isSoundOn;
            this.random = random;
            minimap = new MiniMap(screenWidth, screenHeight, map);

            if (isSoundOn)
                soundManager = new SoundManager(random);

            hud = new Hud(screenWidth, screenHeight);

            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            spriteViewer = new SpriteViewer3D(screenWidth, screenHeight, spritePool, fov, heightDistanceRatio, isEnableSpriteCache, isEnableLazySpriteImageLoad, random);

            this.gradient = new Gradient(screenWidth, screenHeight * 2);

            columnViewer = new ColumnViewer(this.screenWidth, this.screenHeight, columnCount, heightDistanceRatio);
        }
        #endregion

        #region Public Methods
        public override void Update(World world, RayTracer rayTracer)
        {
            if (isSoundOn)
                soundManager.Update(world.CurrentPlayer, world.CurrentPlayer);

            int receivedAttackCycle = world.CurrentPlayer.ReceivedAttackCycle.GetCycleState();
            if (receivedAttackCycle > 0 && (receivedAttackCycle == 0 || (random.Next(6) == 0)))
            {
                mainSurface.Fill(Color.Red);
            }
            else
            {
                int gradientOffset = (int)(world.CurrentPlayer.MouseLook * screenHeight) - screenHeight / 2;
                mainSurface.Blit(gradient.Surface, PointLoader.GetPoint(0, gradientOffset));

                columnViewer.Update(world.CurrentPlayer, rayTracer, world.Map, mainSurface);

                //We display the sprites
                world.SpritePool.SortByDistance(world.CurrentPlayer);
                foreach (AbstractHumanoid sprite in world.SpritePool)
                {
                    if (sprite != world.CurrentPlayer && world.SharedConsciousness.IsSpriteViewable(world.CurrentPlayer, sprite, world.Map, rayTracer.Fov))
                    {
                        spriteViewer.View(world.CurrentPlayer, sprite, mainSurface);
                        if (isSoundOn)
                        {
                            soundManager.Update(sprite, world.CurrentPlayer);
                        }
                    }
                }

                hud.Update(world.CurrentPlayer, mainSurface);

                if (isMiniMapOn)
                    minimap.Update(world, rayTracer, mainSurface);
            }

            mainSurface.Update();
        }

        public override void DirthenHud()
        {
            hud.Dirthen();
        }
        #endregion

        #region Properties
        public override bool IsMiniMapOn
        {
            get { return isMiniMapOn; }
            set { isMiniMapOn = value; }
        }

        public override SoundManager SoundManager
        {
            get { return soundManager; }
        }
        #endregion
    }
}