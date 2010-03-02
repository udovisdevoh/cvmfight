using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace CvmFight
{
    class MiniMap : AbstractGameViewer
    {
        #region Fields and parts
        private Surface screen;

        private Random random = new Random();
        #endregion

        #region Constructor
        public MiniMap()
        {
            screen = new Surface(1024, 768);
            screen = Video.SetVideoMode(1024, 768);
        }
        #endregion

        #region Public Methods
        public override void Update(World world)
        {


            for (int x = 0; x < world.Map.Width; x++)
            {
                for (int y = 0; y < world.Map.Width; y++)
                {
                    screen.Draw(new Point(x, y), Color.Blue);
                }
            }

            screen.Update();
        }
        #endregion
    }
}
