using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Primitives;

namespace CvmFight
{
    class MiniMap : AbstractGameViewer
    {
        #region Constants
        private double precision = 0.025;

        private int screenWidth = 1024;

        private int screenHeight = 768;
        #endregion

        #region Fields and parts
        private Surface surface;

        private Random random = new Random();

        private Point[,] pointGrid;

        private CircleCache circleCache = new CircleCache();
        #endregion

        #region Constructor
        public MiniMap()
        {
            surface = new Surface(screenWidth, screenHeight);
            surface = Video.SetVideoMode(screenWidth, screenHeight);
            pointGrid = new Point[screenWidth, screenHeight];

            for (int x = 0; x < screenWidth; x++)
                for (int y = 0; y < screenHeight; y++)
                    pointGrid[x, y] = new Point(x, y);
        }
        #endregion

        #region Public Methods
        public override void Update(World world)
        {
            DrawMap(world.Map);
            foreach (AbstractSprite sprite in world.SpritePool)
                DrawSprite(sprite);
            surface.Update();
        }
        #endregion

        #region Private Methods
        private void DrawMap(AbstractMap map)
        {
            int pixelLocationX = 0;
            for (double mapLocationX = 0; mapLocationX < map.Width; mapLocationX += precision)
            {
                int pixelLocationY = 0;
                for (double mapLocationY = 0; mapLocationY < map.Width; mapLocationY += precision)
                {
                    if (map.GetMatterTypeAt(mapLocationX, mapLocationY) != null)
                        surface.Draw(pointGrid[pixelLocationX, pixelLocationY], Color.Gray);
                    pixelLocationY++;
                }
                pixelLocationX++;
            }
        }

        private void DrawSprite(AbstractSprite sprite)
        {
            int pixelLocationX = (int)(sprite.PositionX / precision);
            int pixelLocationY = (int)(sprite.PositionY / precision);
            int radius = (int)(sprite.Radius / precision);

            Circle circle;

            if (!circleCache.TryGetValue(sprite, out circle))
            {
                circle = new Circle((short)pixelLocationX, (short)pixelLocationY, (short)radius);
                circleCache.Add(sprite, circle);
            }

            circle.PositionX = (short)pixelLocationX;
            circle.PositionY = (short)pixelLocationY;

            if (sprite is Player)
                surface.Draw(circle, Color.Blue);
            else if (sprite is AbstractFighter)
                surface.Draw(circle, Color.Red);
            else
                surface.Draw(circle, Color.Green);
        }
        #endregion
    }
}
