using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace CvmFight
{
    class Program
    {
        private World world = new World();

        private AbstractGameViewer gameViewer = new MiniMap();

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        public void Start()
        {
            Events.TargetFps = 60;
            Events.Tick += Update;
            Events.Run();
        }

        public void Update(object sender, TickEventArgs args)
        {
            gameViewer.Update(world);
        }
    }
}