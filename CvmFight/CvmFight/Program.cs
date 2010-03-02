using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Input;

namespace CvmFight
{
    class Program
    {
        #region Fields and parts
        private World world = new World();

        private AbstractGameViewer gameViewer = new MiniMap();

        private UserInput userInput = new UserInput();

        private RayTracer rayTracer = new RayTracer(200,110);
        #endregion

        #region Public Methods and event handlers
        public void Start()
        {
            Events.TargetFps = 60;
            Events.Tick += Update;
            Events.KeyboardDown += OnKeyboardDown;
            Events.KeyboardUp += OnKeyboardUp;
            Events.MouseMotion += OnMouseMotion;
            Events.Run();
        }

        public void Update(object sender, TickEventArgs args)
        {
            if (userInput.IsPressUp)
                world.Physics.TryMakeWalk(world.CurrentPlayer, world.SpritePool, world.Map);
            else if (userInput.IsPressDown)
                world.Physics.TryMakeWalk(world.CurrentPlayer, Math.PI, world.SpritePool, world.Map);
            
            if (userInput.IsPressLeft)
                world.Physics.TryMakeWalk(world.CurrentPlayer, Math.PI * 1.5, world.SpritePool, world.Map);
            else if (userInput.IsPressRight)
                world.Physics.TryMakeWalk(world.CurrentPlayer, Math.PI * 0.5, world.SpritePool, world.Map);

            rayTracer.Trace(world.CurrentPlayer, world.Map);

            world.Physics.TryMakeRotate(world.CurrentPlayer, userInput.CurrentMouseRelativeX);
            userInput.CurrentMouseRelativeX = 0;

            gameViewer.Update(world);
        }

        public void OnKeyboardDown(object sender, KeyboardEventArgs args)
        {
            if (args.Key == Key.UpArrow || args.Key == Key.W)
                userInput.IsPressUp = true;
            else if (args.Key == Key.DownArrow || args.Key == Key.S)
                userInput.IsPressDown = true;
            else if (args.Key == Key.LeftArrow || args.Key == Key.A)
                userInput.IsPressLeft = true;
            else if (args.Key == Key.RightArrow || args.Key == Key.D)
                userInput.IsPressRight = true;
        }

        public void OnKeyboardUp(object sender, KeyboardEventArgs args)
        {
            if (args.Key == Key.UpArrow || args.Key == Key.W)
                userInput.IsPressUp = false;
            else if (args.Key == Key.DownArrow || args.Key == Key.S)
                userInput.IsPressDown = false;
            else if (args.Key == Key.LeftArrow || args.Key == Key.A)
                userInput.IsPressLeft = false;
            else if (args.Key == Key.RightArrow || args.Key == Key.D)
                userInput.IsPressRight = false;
        }

        public void OnMouseMotion(object sender, MouseMotionEventArgs args)
        {
            userInput.CurrentMouseRelativeX = args.RelativeX;
            userInput.CurrentMouseRelativeY = args.RelativeY;
        }
        #endregion

        #region Static
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }
        #endregion
    }
}