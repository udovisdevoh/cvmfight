using System;
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
        private bool isFullScreen;

        private bool isMiniMapOn;

        private int screenWidth;

        private int screenHeight;

        private Surface mainSurface;

        private ColumnViewer columnViewer;

        private SpriteViewer3D spriteViewer;

        private Gradient gradient;

        private MiniMap minimap;

        private Hud hud;
        #endregion

        #region Constructor
        public GameViewer3D(int screenWidth, int screenHeight, int columnCount, SpritePool spritePool, bool isFullScreen, int fov)
        {
            minimap = new MiniMap(screenWidth, screenHeight);

            hud = new Hud(screenWidth, screenHeight);

            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.isFullScreen = isFullScreen;

            spriteViewer = new SpriteViewer3D(screenWidth, screenHeight, spritePool, fov, heightDistanceRatio);

            this.gradient = new Gradient(screenWidth, screenHeight);

            columnViewer = new ColumnViewer(this.screenWidth, this.screenHeight, columnCount, heightDistanceRatio);
            
            //mainSurface = new Surface(screenWidth, screenHeight);
            mainSurface = Video.SetVideoMode(screenWidth, screenHeight, true, false, isFullScreen, true);
        }
        #endregion

        #region Public Methods
        public override void Update(World world, RayTracer rayTracer)
        {
            mainSurface.Blit(gradient.Surface);
            columnViewer.Update(world.CurrentPlayer, rayTracer, world.Map, mainSurface);

            #warning, some sprites are invisible in 3D mode, but visible on minimap

            //We display the sprites
            world.SpritePool.SortByDistance(world.CurrentPlayer);
            foreach (AbstractSprite sprite in world.SpritePool)
                if (sprite != world.CurrentPlayer && world.SharedConsciousness.IsSpriteViewable(world.CurrentPlayer,sprite,world.Map,rayTracer.Fov))
                    spriteViewer.View(world.CurrentPlayer, sprite, mainSurface);

            if (isMiniMapOn)
                minimap.Update(world, rayTracer, mainSurface);

            hud.Update(world.CurrentPlayer, mainSurface);

            mainSurface.Update();
        }
        #endregion

        #region Properties
        public override bool IsMiniMapOn
        {
            get { return isMiniMapOn; }
            set { isMiniMapOn = value; }
        }
        #endregion
    }
}