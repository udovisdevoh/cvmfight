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

        private Font smallGray = new Font("Assets/Fonts/doom.ttf", 20);

        private Font bigRed = new Font("Assets/Fonts/doom.ttf", 50);

        private Surface health = null;

        private Surface fragCount = null;

        private Surface healthLabel;

        private Surface fragLabel;
        #endregion

        #region Constructor
        public Hud(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            healthLabel = smallGray.Render("health", System.Drawing.Color.Gray);
            fragLabel = smallGray.Render("frags", System.Drawing.Color.Gray);
        }
        #endregion

        #region Public Methods
        public void Update(AbstractFighter player, Surface surface)
        {
            if (health == null)
                health = bigRed.Render(player.Health.ToString(), System.Drawing.Color.Red);
            
            if (fragCount == null)
                fragCount = bigRed.Render(player.FragCount.ToString(), System.Drawing.Color.Red);

            surface.Blit(healthLabel, PointLoader.GetPoint(screenWidth - 140, screenHeight - 80));
            surface.Blit(health, PointLoader.GetPoint(screenWidth - 140, screenHeight - 65));
            surface.Blit(fragLabel, PointLoader.GetPoint(screenWidth - 240, screenHeight - 80));
            surface.Blit(fragCount, PointLoader.GetPoint(screenWidth - 240, screenHeight - 65));
        }

        public void Dirthen()
        {
            #warning Dirthen must be called when player's stats change
            this.health = null;
            this.fragCount = null;
        }
        #endregion
    }
}
