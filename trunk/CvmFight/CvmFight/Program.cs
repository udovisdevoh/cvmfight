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
        private const int screenWidth = 640;

        private const int screenHeight = 480;

        private static int idealRayTracerResolution = 320;

        private const int fov = 110;

        private const int targetFps = 60;

        private bool isDestroyMouse = true;

        private bool isFullScreen = true;

        private bool isEnableSpriteCache = false;

        private bool isEnableLazySpriteImageLoad = true;
        #endregion

        #region Fields and parts
        private Random random = new Random();

        private World world;

        private AbstractGameViewer gameViewer;

        private UserInput userInput = new UserInput();

        private RayTracer rayTracer;

        private BattleManager battleManager = new BattleManager();

        private Ai ai;
        
        private Point centerMousePositon;

        private DateTime previousDateTime = DateTime.Now;

        private DamageManager damageManager = new DamageManager();
        #endregion

        #region Constructor
        public Program()
        {
            idealRayTracerResolution = RayTracer.GetValidResolution(idealRayTracerResolution, screenWidth);
            rayTracer = new RayTracer(idealRayTracerResolution, fov);

            world = new World(random);
            ai = new Ai(random);

            //gameViewer = new MiniMap(screenWidth, screenHeight, isFullScreen);
            gameViewer = new GameViewer3D(screenWidth, screenHeight, rayTracer.ColumnCount, world.SpritePool, isFullScreen, rayTracer.Fov, isEnableSpriteCache, random, isEnableLazySpriteImageLoad);
            centerMousePositon = new Point(screenWidth / 2, screenHeight / 2);
        }
        #endregion

        #region Public Methods and event handlers
        public void Start()
        {
            if (isDestroyMouse)
                Cursor.Hide();
            Events.TargetFps = targetFps;
            Events.Tick += Update;
            Events.KeyboardDown += OnKeyboardDown;
            Events.KeyboardUp += OnKeyboardUp;
            Events.MouseMotion += OnMouseMotion;
            Events.MouseButtonDown += OnMouseDown;
            Events.MouseButtonUp += OnMouseUp;
            Events.Run();
        }

        public void Update(object sender, TickEventArgs args)
        {
            //We process the time multiplicator
            double timeDelta = ((TimeSpan)(DateTime.Now - previousDateTime)).TotalMilliseconds / 16.0;
            previousDateTime = DateTime.Now;


            #warning Remove
            //timeDelta /= 5.0;

            //We clear the sprite's shared consciousness because sprite positions changed
            world.SharedConsciousness.Clear();

            if (userInput.IsPressUp)
                Physics.TryMakeWalk(world.CurrentPlayer, world.SpritePool, world.Map, timeDelta);
            else if (userInput.IsPressDown)
                Physics.TryMakeWalk(world.CurrentPlayer, Math.PI, world.SpritePool, world.Map, timeDelta);
            
            if (userInput.IsPressLeft)
                Physics.TryMakeWalk(world.CurrentPlayer, Math.PI * 1.5, world.SpritePool, world.Map, timeDelta);
            else if (userInput.IsPressRight)
                Physics.TryMakeWalk(world.CurrentPlayer, Math.PI * 0.5, world.SpritePool, world.Map, timeDelta);


            //Blocking
            world.CurrentPlayer.IsBlock = userInput.IsPressDown;


            //Crouch and jump
            world.CurrentPlayer.IsCrouch = userInput.IsPressCrouch;   

            if (userInput.IsPressJump)
            {
                world.CurrentPlayer.IsCrouch = false;
                world.CurrentPlayer.IsBlock = false;
                Physics.MakeJump(world.CurrentPlayer,timeDelta);
            }
            else
            {
                world.CurrentPlayer.IsNeedToJumpAgain = false;
            }




            //We manage attack buttons
            if (userInput.IsPressMouseButtonLeft)
            {
                if (world.CurrentPlayer.ReceivedAttackCycle.GetCycleState() <= 0)
                {
                    if (!world.CurrentPlayer.FastAttackCycle.IsFired)
                    {
                        world.CurrentPlayer.IsBlock = false;
                        world.CurrentPlayer.StrongAttackCycle.Fire();
                    }
                }
            }
            else if (userInput.IsPressMouseButtonRight)
            {
                if (world.CurrentPlayer.ReceivedAttackCycle.GetCycleState() <= 0)
                {
                    if (!world.CurrentPlayer.StrongAttackCycle.IsFired)
                    {
                        world.CurrentPlayer.IsBlock = false;
                        world.CurrentPlayer.FastAttackCycle.Fire();
                    }
                }
            }
            else
            {
                world.CurrentPlayer.StrongAttackCycle.UnFire();
                world.CurrentPlayer.FastAttackCycle.UnFire();
            }





            //We animate the sprites using the AI
            foreach (AbstractSprite sprite in world.SpritePool)
                if (sprite != world.CurrentPlayer)
                    ai.Animate(sprite, world.Map, world.SpritePool, world.SharedConsciousness, timeDelta, rayTracer.Fov, random, world.CurrentPlayer);



            //We update the sprites
            foreach (AbstractSprite sprite in world.SpritePool)
                sprite.Update(timeDelta, world.SpritePool,world.Map);

            //We perform fighting logic
            battleManager.Update(world.SpritePool, world.SharedConsciousness, world.CurrentPlayer);

            //We perform damage logic
            bool isNeedRefreshHud;
            damageManager.Update(world.SpritePool, world.CurrentPlayer, world.Map, timeDelta, out isNeedRefreshHud);

            if (isNeedRefreshHud)
            {
                gameViewer.DirthenHud();
                world.Spawner.TryRespawn(world.SpritePool, world.Map);
            }

            rayTracer.Trace(world.CurrentPlayer, world.Map);

            Physics.TryMakeRotate(world.CurrentPlayer, userInput.MouseMotionX);

            world.CurrentPlayer.TryMouseLook(userInput.MouseMotionY);

            userInput.MouseMotionX = 0;
            userInput.MouseMotionY = 0;

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
            else if (args.Key == Key.Space)
                userInput.IsPressJump = true;
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
            else if (args.Key == Key.Space)
                userInput.IsPressJump = false;
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

        public void OnMouseDown(object sender, MouseButtonEventArgs args)
        {
            if (args.Button == MouseButton.PrimaryButton)
                userInput.IsPressMouseButtonLeft = true;
            else if (args.Button == MouseButton.SecondaryButton)
                userInput.IsPressMouseButtonRight = true;
        }

        public void OnMouseUp(object sender, MouseButtonEventArgs args)
        {
            if (args.Button == MouseButton.PrimaryButton)
                userInput.IsPressMouseButtonLeft = false;
            else if (args.Button == MouseButton.SecondaryButton)
                userInput.IsPressMouseButtonRight = false;
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