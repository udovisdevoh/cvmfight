using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Primitives;

namespace CvmFight
{
    class GameViewer3D : AbstractGameViewer
    {
        #region Fields and parts
        private bool isFullScreen = true;

        private int screenWidth;

        private int screenHeight;

        private Surface mainSurface;

        private ColumnViewer columnViewer;

        private SpriteViewer3D spriteViewer;

        private Gradient gradient;
        #endregion

        #region Constructor
        public GameViewer3D(int screenWidth, int screenHeight, int columnCount)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            spriteViewer = new SpriteViewer3D(screenWidth, screenHeight);

            this.gradient = new Gradient(screenWidth, screenHeight);
            
            columnViewer = new ColumnViewer(this.screenWidth, this.screenHeight, columnCount);
            
            mainSurface = new Surface(screenWidth, screenHeight);
            mainSurface = Video.SetVideoMode(screenWidth, screenHeight, true, false, isFullScreen, true);
        }
        #endregion

        #region Public Methods
        public override void Update(World world, RayTracer rayTracer)
        {
            mainSurface.Blit(gradient.Surface);
            columnViewer.Update(world.CurrentPlayer, rayTracer, mainSurface);

            //We display the sprites
            foreach (AbstractSprite sprite in world.SpritePool)
                if (sprite != world.CurrentPlayer && Optics.IsSpriteViewable(world.CurrentPlayer,sprite,world.Map,rayTracer.Fov))
                    spriteViewer.ViewSprite(sprite, mainSurface);

            mainSurface.Update();
        }
        #endregion
    }
}