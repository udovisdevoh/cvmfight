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

        private UserInput keyBoardInput = new UserInput();
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
            if (keyBoardInput.IsPressUp)
                world.Physics.TryMakeWalk(world.CurrentPlayer, world.SpritePool, world.Map);
            else if (keyBoardInput.IsPressDown)
                world.Physics.TryMakeWalk(world.CurrentPlayer, Math.PI, world.SpritePool, world.Map);
            
            if (keyBoardInput.IsPressLeft)
                world.Physics.TryMakeWalk(world.CurrentPlayer, Math.PI * 1.5, world.SpritePool, world.Map);
            else if (keyBoardInput.IsPressRight)
                world.Physics.TryMakeWalk(world.CurrentPlayer, Math.PI * 0.5, world.SpritePool, world.Map);

            gameViewer.Update(world);
        }

        public void OnKeyboardDown(object sender, KeyboardEventArgs args)
        {
            if (args.Key == Key.UpArrow || args.Key == Key.W)
                keyBoardInput.IsPressUp = true;
            else if (args.Key == Key.DownArrow || args.Key == Key.S)
                keyBoardInput.IsPressDown = true;
            else if (args.Key == Key.LeftArrow || args.Key == Key.A)
                keyBoardInput.IsPressLeft = true;
            else if (args.Key == Key.RightArrow || args.Key == Key.D)
                keyBoardInput.IsPressRight = true;
        }

        public void OnKeyboardUp(object sender, KeyboardEventArgs args)
        {
            if (args.Key == Key.UpArrow || args.Key == Key.W)
                keyBoardInput.IsPressUp = false;
            else if (args.Key == Key.DownArrow || args.Key == Key.S)
                keyBoardInput.IsPressDown = false;
            else if (args.Key == Key.LeftArrow || args.Key == Key.A)
                keyBoardInput.IsPressLeft = false;
            else if (args.Key == Key.RightArrow || args.Key == Key.D)
                keyBoardInput.IsPressRight = false;
        }

        public void OnMouseMotion(object sender, MouseMotionEventArgs args)
        {
            //args.RelativeX
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