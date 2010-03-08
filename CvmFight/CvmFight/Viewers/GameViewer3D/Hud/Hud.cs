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

        private Font labelFont = new Font("Assets/Fonts/doom.ttf", 20);

        private Font bigRed = new Font("Assets/Fonts/doom.ttf", 50);

        private Surface health = null;

        private Surface fragCount = null;

        private Surface healthLabel;

        private Surface fragLabel;

        private Surface restFist;

        private Surface attackFist;

        private Surface restKick;

        private Surface midKick;

        private Surface attackKick;

        private Surface blockSurface;
        #endregion

        #region Constructor
        public Hud(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            healthLabel = labelFont.Render("health", System.Drawing.Color.White);
            fragLabel = labelFont.Render("frags", System.Drawing.Color.White);

            restFist = BuildRestFistSurface();
            attackFist = BuildAttackFistSurface();

            restKick = BuildRestKickSurface();
            midKick = BuildMidKickSurface();
            attackKick = BuildAttackKickSurface();
            blockSurface = BuildBlockSurface();
        }

        private Surface BuildBlockSurface()
        {
            Surface surface = new Surface("Assets/Hud/block001.png");
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
        public void Update(AbstractSprite player, Surface surface)
        {
            if (health == null)
                health = bigRed.Render(player.Health.ToString(), System.Drawing.Color.Red);

            if (fragCount == null)
                fragCount = bigRed.Render(player.FragCount.ToString(), System.Drawing.Color.Red);

            int attackCycleState = player.AttackCycle.GetCycleState();
            if (player.IsCrouch || player.PositionZ > 0)
            {
                if (player.IsBlock)
                {
                    surface.Blit(blockSurface, PointLoader.GetPoint(0, screenHeight - blockSurface.Height));
                }
                else if (attackCycleState == 0)
                {
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
                if (player.IsBlock)
                {
                    surface.Blit(blockSurface, PointLoader.GetPoint(0, screenHeight - blockSurface.Height));
                }
                else if (attackCycleState == 0)
                {
                    surface.Blit(restFist, PointLoader.GetPoint(0, screenHeight - restFist.Height));
                }
                else
                {
                    surface.Blit(attackFist, PointLoader.GetPoint(0, screenHeight - attackFist.Height));
                }
            }

            surface.Blit(healthLabel, PointLoader.GetPoint(screenWidth - 140, screenHeight - 80));
            surface.Blit(health, PointLoader.GetPoint(screenWidth - 140, screenHeight - 65));
            surface.Blit(fragLabel, PointLoader.GetPoint(screenWidth - 240, screenHeight - 80));
            surface.Blit(fragCount, PointLoader.GetPoint(screenWidth - 240, screenHeight - 65));
        }

        public void Dirthen()
        {
            this.health = null;
            this.fragCount = null;
        }
        #endregion
    }
}
