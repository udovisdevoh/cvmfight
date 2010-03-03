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
        private bool isFullScreen = false;

        private int screenWidth = 1024;

        private int screenHeight = 768;

        private Surface mainSurface;

        private ColumnViewer columnViewer;
        #endregion

        #region Constructor
        public GameViewer3D(int screenWidth, int screenHeight, int columnCount)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            
            columnViewer = new ColumnViewer(this.screenWidth, this.screenHeight, columnCount);
            
            mainSurface = new Surface(screenWidth, screenHeight);
            mainSurface = Video.SetVideoMode(screenWidth, screenHeight, true, false, isFullScreen, true);
        }
        #endregion

        #region Public Methods
        public override void Update(World world, RayTracer rayTracer)
        {
            columnViewer.Update(world.CurrentPlayer, rayTracer, mainSurface);
            mainSurface.Update();
        }
        #endregion
    }
}