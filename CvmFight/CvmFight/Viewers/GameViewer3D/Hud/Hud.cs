using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Primitives;

namespace CvmFight
{
    class Hud
    {
        #region Fields
        private int screenWidth;

        private int screenHeight;

        private Font labelFont;

        private Font bigRed;

        private Surface health = null;

        private Surface fragCount = null;

        private Surface ranking = null;

        private Surface healthLabel;

        private Surface fragLabel;

        private Surface rankingLabel;

        private Surface restFist;

        private Surface attackFist;

        private Surface restKick;

        private Surface midKick;

        private Surface attackKick;

        private Surface blockSurface;

        private Surface blockSuccessSurface;

        private int hudColumn1;

        private int hudColumn2;

        private int hudColumn3;

        private int hudRow1;

        private int hudRow2;

        private bool isEvenOddFrame = false;

        private bool isJumpCrouchAtAttackCycleStart;
        #endregion

        #region Constructor
        public Hud(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            labelFont = new Font("Assets/Fonts/doom.ttf", 20 * screenWidth / 1024);
            bigRed = new Font("Assets/Fonts/doom.ttf", 50 * screenWidth / 1024);

            hudColumn1 = 140 * screenWidth / 1024;
            hudColumn2 = 240 * screenWidth / 1024;
            hudColumn3 = 340 * screenWidth / 1024;
            hudRow1 = 65 * screenHeight / 768;
            hudRow2 = 80 * screenHeight / 768;


            healthLabel = labelFont.Render("health", System.Drawing.Color.White);
            fragLabel = labelFont.Render("frags", System.Drawing.Color.White);
            rankingLabel = labelFont.Render("rank", System.Drawing.Color.White);

            restFist = BuildRestFistSurface();
            attackFist = BuildAttackFistSurface();

            restKick = BuildRestKickSurface();
            midKick = BuildMidKickSurface();
            attackKick = BuildAttackKickSurface();
            blockSurface = BuildBlockSurface();
            blockSuccessSurface = BuildBlockSuccessSurface();
        }
        #endregion

        #region Private Methods
        private Surface BuildBlockSurface()
        {
            Surface surface = new Surface("Assets/Hud/block001.png");
            surface.Transparent = true;
            surface = surface.CreateScaledSurface((double)screenHeight / 4 / (double)surface.Height, true);
            return surface;
        }

        private Surface BuildBlockSuccessSurface()
        {
            Surface surface = new Surface("Assets/Hud/block002.png");
            surface.Transparent = true;
            surface = surface.CreateScaledSurface((double)screenHeight / 1.7 / (double)surface.Height, true);
            return surface;
        }

        private Surface BuildRestKickSurface()
        {
            Surface surface = new Surface("Assets/Hud/kick001.png");
            surface.Transparent = true;
            surface = surface.CreateScaledSurface((double)screenHeight / 3 / (double)surface.Height, true);
            return surface;
        }

        private Surface BuildMidKickSurface()
        {
            Surface surface = new Surface("Assets/Hud/kick002.png");
            surface.Transparent = true;
            surface = surface.CreateScaledSurface((double)screenHeight / 3 / (double)surface.Height, true);
            return surface;
        }

        private Surface BuildAttackKickSurface()
        {
            Surface surface = new Surface("Assets/Hud/kick003.png");
            surface.Transparent = true;
            surface = surface.CreateScaledSurface((double)screenHeight / 3 / (double)surface.Height, true);
            return surface;
        }

        private Surface BuildAttackFistSurface()
        {
            Surface surface = new Surface("Assets/Hud/punch002.png");
            surface.Transparent = true;
            surface = surface.CreateScaledSurface((double)screenHeight / 1.7 / (double)surface.Height,true);
            return surface;
        }

        private Surface BuildRestFistSurface()
        {
            Surface surface = new Surface("Assets/Hud/punch001.png");            
            surface.Transparent = true;
            surface = surface.CreateScaledSurface((double)screenHeight / 2.5 / (double)surface.Height,true);
            return surface;
        }
        #endregion

        #region Public Methods
        public void Update(AbstractHumanoid player, Surface surface)
        {
            isEvenOddFrame = !isEvenOddFrame;

            if (health == null)
                health = bigRed.Render(((int)(player.Health)).ToString(), System.Drawing.Color.Red);

            if (fragCount == null)
                fragCount = bigRed.Render(player.FragCount.ToString(), System.Drawing.Color.Red);

            if (ranking == null)
                ranking = bigRed.Render(player.Ranking.ToString(), System.Drawing.Color.Blue);

            int attackCycleState = Math.Max(player.StrongAttackCycle.GetCycleState(), player.FastAttackCycle.GetCycleState());


            if (attackCycleState == 0)
                isJumpCrouchAtAttackCycleStart = player.IsCrouch || player.PositionZ > 0;


            if (player.ReceivedAttackCycle.GetCycleState() == 0)
            {
                if (isJumpCrouchAtAttackCycleStart)
                {
                    if (player.SpinAttackCycle.IsFired)
                    {
                        surface.Blit(attackKick, PointLoader.GetPoint(screenWidth / 3, screenHeight - attackKick.Height));
                    }
                    else if (player.IsBlock)
                    {
                        if (player.BlockSuccessCycle.IsFired)
                        {
                            surface.Blit(blockSuccessSurface, PointLoader.GetPoint(screenWidth / 3, screenHeight - blockSuccessSurface.Height));
                        }
                        else
                        {
                            surface.Blit(blockSurface, PointLoader.GetPoint(screenWidth / 3, screenHeight - blockSurface.Height));
                        }
                    }
                    else if (attackCycleState == 0)
                    {
                        if (!player.SpinChargeAttackCycle.IsFired || isEvenOddFrame || player.SpinChargeAttackCycle.IsAtParoxism)
                            surface.Blit(restKick, PointLoader.GetPoint(screenWidth / 3, screenHeight - restKick.Height));
                    }
                    else if (attackCycleState == 1)
                    {
                        surface.Blit(midKick, PointLoader.GetPoint(screenWidth / 3, screenHeight - midKick.Height));
                    }
                    else if (attackCycleState == 2)
                    {
                        surface.Blit(attackKick, PointLoader.GetPoint(screenWidth / 3, screenHeight - attackKick.Height));
                    }
                }
                else
                {
                    if (player.SpinAttackCycle.IsFired)
                    {
                        surface.Blit(attackKick, PointLoader.GetPoint(screenWidth / 3, screenHeight - attackKick.Height));
                    }
                    else if (player.IsBlock)
                    {
                        if (player.BlockSuccessCycle.IsFired)
                        {
                            surface.Blit(blockSuccessSurface, PointLoader.GetPoint(screenWidth / 3, screenHeight - blockSuccessSurface.Height));
                        }
                        else
                        {
                            surface.Blit(blockSurface, PointLoader.GetPoint(screenWidth / 3, screenHeight - blockSurface.Height));
                        }
                    }
                    else if (attackCycleState == 0)
                    {
                        if (!player.SpinChargeAttackCycle.IsFired || isEvenOddFrame || player.SpinChargeAttackCycle.IsAtParoxism)
                            surface.Blit(restFist, PointLoader.GetPoint(0, screenHeight - restFist.Height));
                    }
                    else if (attackCycleState == 1)
                    {
                        surface.Blit(attackFist, PointLoader.GetPoint(0 - (screenWidth / 4), screenHeight - attackFist.Height * 3 / 4));
                    }
                    else if (attackCycleState == 2)
                    {
                        surface.Blit(attackFist, PointLoader.GetPoint(0, screenHeight - attackFist.Height));
                    }
                }
            }

            surface.Blit(healthLabel, PointLoader.GetPoint(screenWidth - hudColumn1, screenHeight - hudRow2));
            surface.Blit(health, PointLoader.GetPoint(screenWidth - hudColumn1, screenHeight - hudRow1));
            surface.Blit(fragLabel, PointLoader.GetPoint(screenWidth - hudColumn2, screenHeight - hudRow2));
            surface.Blit(fragCount, PointLoader.GetPoint(screenWidth - hudColumn2, screenHeight - hudRow1));
            surface.Blit(rankingLabel, PointLoader.GetPoint(screenWidth - hudColumn3, screenHeight - hudRow2));
            surface.Blit(ranking, PointLoader.GetPoint(screenWidth - hudColumn3, screenHeight - hudRow1));
        }

        public void Dirthen()
        {
            this.health = null;
            this.fragCount = null;
            this.ranking = null;
        }
        #endregion
    }
}
