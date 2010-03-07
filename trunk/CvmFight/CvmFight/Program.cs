using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Input;
using System.Windows.Forms;

namespace CvmFight
{
    class Program
    {
        #region Constants
        private const int screenWidth = 1024;

        private const int screenHeight = 768;

        private const int rayTracerResolution = 256;

        private const int fov = 110;

        private bool isDestroyMouse = false;

        private bool isFullScreen = false;
        #endregion

        #region Fields and parts
        private World world = new World();

        private AbstractGameViewer gameViewer;

        private UserInput userInput = new UserInput();

        private RayTracer rayTracer = new RayTracer(rayTracerResolution, fov);
        
        private Point centerMousePositon;

        private DateTime previousDateTime = DateTime.Now;
        #endregion

        #region Constructor
        public Program()
        {
            //gameViewer = new MiniMap(screenWidth, screenHeight, isFullScreen);
            gameViewer = new GameViewer3D(screenWidth, screenHeight, rayTracer.ColumnCount, world.SpritePool, isFullScreen, rayTracer.Fov);
            centerMousePositon = new Point(screenWidth / 2, screenHeight / 2);
        }
        #endregion

        #region Public Methods and event handlers
        public void Start()
        {
            if (isDestroyMouse)
                Cursor.Hide();
            Events.TargetFps = 60;
            Events.Tick += Update;
            Events.KeyboardDown += OnKeyboardDown;
            Events.KeyboardUp += OnKeyboardUp;
            Events.MouseMotion += OnMouseMotion;
            Events.Run();
        }

        public void Update(object sender, TickEventArgs args)
        {
            //We process the time multiplicator
            double timeDelta = ((TimeSpan)(DateTime.Now - previousDateTime)).TotalMilliseconds / 16.0;
            previousDateTime = DateTime.Now;

            //We clear the sprite's shared consciousness
            world.SharedConsciousness.Clear();

            if (userInput.IsPressUp)
                Physics.TryMakeWalk(world.CurrentPlayer, world.SpritePool, world.Map, timeDelta);
            else if (userInput.IsPressDown)
                Physics.TryMakeWalk(world.CurrentPlayer, Math.PI, world.SpritePool, world.Map, timeDelta);
            
            if (userInput.IsPressLeft)
                Physics.TryMakeWalk(world.CurrentPlayer, Math.PI * 1.5, world.SpritePool, world.Map, timeDelta);
            else if (userInput.IsPressRight)
                Physics.TryMakeWalk(world.CurrentPlayer, Math.PI * 0.5, world.SpritePool, world.Map, timeDelta);


            world.CurrentPlayer.IsCrouch = userInput.IsPressCrouch;


            rayTracer.Trace(world.CurrentPlayer, world.Map);

            Physics.TryMakeRotate(world.CurrentPlayer, userInput.MouseMotionX);

            userInput.MouseMotionX = 0;

            gameViewer.Update(world, rayTracer);
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
            else if (args.Key == Key.LeftShift || args.Key == Key.C)
                userInput.IsPressCrouch = true;
            else if (args.Key == Key.Tab)
                gameViewer.IsMiniMapOn = !gameViewer.IsMiniMapOn;
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
            else if (args.Key == Key.LeftShift || args.Key == Key.C)
                userInput.IsPressCrouch = false;
            else if (args.Key == Key.Escape)
                Events.QuitApplication();
        }

        public void OnMouseMotion(object sender, MouseMotionEventArgs args)
        {
            userInput.MouseMotionX = args.RelativeX;
            userInput.MouseMotionY = args.RelativeY;

            if (isDestroyMouse)
                Cursor.Position = centerMousePositon;
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