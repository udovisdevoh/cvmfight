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

        private Font healthFont = new Font("Assets/Fonts/doom.ttf", 50);
        #endregion

        #region Constructor
        public Hud(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }
        #endregion

        #region Public Methods
        public void Update(AbstractFighter player, Surface surface)
        {
            Surface health = healthFont.Render(player.Health.ToString(), System.Drawing.Color.Red);
            surface.Blit(health, PointLoader.GetPoint(screenWidth - 140, screenHeight - 65));
        }
        #endregion
    }
}
