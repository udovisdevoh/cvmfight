using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Input;
using SdlDotNet.Audio;
using System.Windows.Forms;
using System.Threading;

namespace CvmFight
{
    class Program
    {
        #region Constants
        private const int screenWidth = 1280;

        private const int screenHeight = 720;

        private static int idealRayTracerResolution = 320;

        private const int fov = 110;

        private const int targetFps = 60;

        private const int monsterCount = 10;

        private const bool isDestroyMouse = true;

        private const bool isFullScreen = false;

        private const bool isEnableSpriteCache = false;

        private const bool isEnableLazySpriteImageLoad = false;

        private const bool isSoundOn = true;
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

        private Surface mainSurface;
        #endregion

        #region Constructor
        public Program()
        {
            mainSurface = Video.SetVideoMode(screenWidth, screenHeight, false, false, isFullScreen, true);

            idealRayTracerResolution = RayTracer.GetValidResolution(idealRayTracerResolution, screenWidth);
            rayTracer = new RayTracer(idealRayTracerResolution, fov);

            world = new World(random, monsterCount);
            ai = new Ai(random,world.SpritePool.Count);

            gameViewer = new GameViewer3D(mainSurface, screenWidth, screenHeight, rayTracer.ColumnCount, world.SpritePool, rayTracer.Fov, isEnableSpriteCache, random, isEnableLazySpriteImageLoad, world.Map, isSoundOn);
            centerMousePositon = new Point(screenWidth / 2, screenHeight / 2);
        }
        #endregion

        #region Public Methods and event handlers
        public void Start()
        {
            if (isSoundOn)
                gameViewer.SoundManager.PlayRandomMusic();

            if (isDestroyMouse)
                Cursor.Hide();
            Events.TargetFps = targetFps;
            Events.Tick += Update;
            Events.KeyboardDown += OnKeyboardDown;
            Events.KeyboardUp += OnKeyboardUp;
            Events.MouseMotion += OnMouseMotion;
            Events.MouseButtonDown += OnMouseDown;
            Events.MouseButtonUp += OnMouseUp;
            Events.MusicFinished += OnMusicFinished;
            Events.Run();
        }

        public void Update(object sender, TickEventArgs args)
        {
            //Thread.CurrentThread.Priority = ThreadPriority.Highest;

            //We process the time multiplicator
            double timeDelta = ((TimeSpan)(DateTime.Now - previousDateTime)).TotalMilliseconds / 16.0;
            previousDateTime = DateTime.Now;


            //We clear the sprite's shared consciousness because sprite positions changed
            world.SharedConsciousness.Clear();

            //We update the sprites
            foreach (AbstractSprite sprite in world.SpritePool)
                sprite.Update(timeDelta, world.SpritePool, world.Map);


            if (userInput.IsPressUp != userInput.IsPressDown)
            {
                if (userInput.IsPressUp)
                {
                    Physics.TryMakeWalk(world.CurrentPlayer, world.SpritePool, world.Map, timeDelta);
                }
                else if (userInput.IsPressDown)
                {
                    Physics.TryMakeWalk(world.CurrentPlayer, Math.PI, world.SpritePool, world.Map, timeDelta);
                }
            }

            if (userInput.IsPressLeft != userInput.IsPressRight)
            {
                if (userInput.IsPressLeft)
                    Physics.TryMakeWalk(world.CurrentPlayer, Math.PI * 1.5, world.SpritePool, world.Map, timeDelta);
                else if (userInput.IsPressRight)
                    Physics.TryMakeWalk(world.CurrentPlayer, Math.PI * 0.5, world.SpritePool, world.Map, timeDelta);
            }


 
            //Crouch and jump
            world.CurrentPlayer.IsCrouch = userInput.IsPressCrouch;   

            if (userInput.IsPressJump)
            {
                world.CurrentPlayer.IsCrouch = false;
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
                        world.CurrentPlayer.StrongAttackCycle.Fire();
                    }
                }

                if (world.CurrentPlayer.SpinChargeAttackCycle.IsAtParoxism)
                {
                    world.CurrentPlayer.SpinChargeAttackCycle.IsNeedToClickAgain = true;
                }
                else
                {
                    world.CurrentPlayer.SpinChargeAttackCycle.Fire();
                    world.CurrentPlayer.SpinChargeAttackCycle.Update(timeDelta);
                }
            }
            else if (userInput.IsPressMouseButtonRight)
            {
                if (world.CurrentPlayer.ReceivedAttackCycle.GetCycleState() <= 0)
                {
                    if (!world.CurrentPlayer.StrongAttackCycle.IsFired)
                    {
                        world.CurrentPlayer.FastAttackCycle.Fire();
                    }
                }
            }
            else
            {
                if (world.CurrentPlayer.StrongAttackCycle.IsAtBegining)
                    world.CurrentPlayer.StrongAttackCycle.UnFire();
                if (world.CurrentPlayer.FastAttackCycle.IsAtBegining)
                    world.CurrentPlayer.FastAttackCycle.UnFire();

                if (world.CurrentPlayer.SpinChargeAttackCycle.IsAtParoxism && !world.CurrentPlayer.FastAttackCycle.IsFired && !world.CurrentPlayer.StrongAttackCycle.IsFired)
                {
                    world.CurrentPlayer.SpinAttackCycle.Reset();
                    world.CurrentPlayer.SpinAttackCycle.Fire();
                }
                world.CurrentPlayer.SpinChargeAttackCycle.Reset();
            }


            world.CurrentPlayer.IsBlock = false;
            //Automatic Blocking
            if (world.CurrentPlayer.StrongAttackCycle.IsAtBegining)
            {
                if (world.CurrentPlayer.FastAttackCycle.IsAtBegining)
                {
                    if (!world.CurrentPlayer.SpinAttackCycle.IsFired)
                    {
                        if (world.CurrentPlayer.ReceivedAttackCycle.IsAtBegining)
                        {
                            if (!world.CurrentPlayer.SpinChargeAttackCycle.IsFired)
                            {
                                if (!userInput.IsPressJump)
                                {
                                    world.CurrentPlayer.IsBlock = true;
                                }
                            }
                        }
                    }
                }
            }



            //We animate the sprites using the AI
            foreach (AbstractHumanoid sprite in world.SpritePool)
                if (sprite != world.CurrentPlayer)
                    ai.Animate(sprite, world.Map, world.SpritePool, world.SharedConsciousness, timeDelta, rayTracer.Fov, random, world.CurrentPlayer);

            //We perform fighting logic
            battleManager.Update(world.SpritePool, world.SharedConsciousness, world.CurrentPlayer);

            //We perform damage logic
            bool isNeedRefreshHud;
            damageManager.Update(world.SpritePool, world.CurrentPlayer, world.Map, timeDelta, out isNeedRefreshHud);


            rayTracer.Trace(world.CurrentPlayer, world.Map);

            Physics.TryMakeRotate(world.CurrentPlayer, userInput.MouseMotionX);

            world.CurrentPlayer.TryMouseLook(userInput.MouseMotionY);

            userInput.MouseMotionX = 0;
            userInput.MouseMotionY = 0;

            gameViewer.Update(world, rayTracer);

            if (isNeedRefreshHud)
            {
                gameViewer.DirthenHud();
                world.Spawner.TryRespawn(world.SpritePool, world.Map);
            }
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
            else if (args.Button == MouseButton.MiddleButton)
                userInput.IsPressMouseButtonCenter = true;
        }

        public void OnMouseUp(object sender, MouseButtonEventArgs args)
        {
            if (args.Button == MouseButton.PrimaryButton)
                userInput.IsPressMouseButtonLeft = false;
            else if (args.Button == MouseButton.SecondaryButton)
                userInput.IsPressMouseButtonRight = false;
            else if (args.Button == MouseButton.MiddleButton)
                userInput.IsPressMouseButtonCenter = false;
        }

        public void OnMusicFinished(object sender, MusicFinishedEventArgs args)
        {
            gameViewer.SoundManager.PlayRandomMusic();
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