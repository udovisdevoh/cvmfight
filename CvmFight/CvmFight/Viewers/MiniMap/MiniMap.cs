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
        private Surface screen;

        private Random random = new Random();

        public MiniMap()
        {
            screen = new Surface(1024, 768);
            screen = Video.SetVideoMode(1024, 768);
        }

        public override void Update(World world)
        {
            if (random.Next(2) == 0)
                screen.Fill(Color.Beige);
            else
                screen.Fill(Color.Blue);
            screen.Update();
        }
    }
}
