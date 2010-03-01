using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace CvmFight
{
    class Program
    {
        private Surface screen;

        private Random random = new Random();
        
        static void Main(string[] args)
        {
            Program p = new Program();
            p.initialisation();
        }

        public void initialisation()
        {
            screen = new Surface(1024, 768);
            screen = Video.SetVideoMode(1024, 768);
            Events.TargetFps = 40;
            Events.Tick += run;
            Events.Run();
        }

        public void run(object sender, TickEventArgs args)
        {
            if (random.Next(2) == 0)
                screen.Fill(Color.Beige);
            else
                screen.Fill(Color.Blue);

            screen.Update();
        }
      
    }
}