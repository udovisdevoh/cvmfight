﻿using System;
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

        private SpritePrimitiveCache circleCache = new SpritePrimitiveCache();

        private SpritePrimitiveCache angleLineCache = new SpritePrimitiveCache();
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
            DrawSpriteBounds(sprite);
            DrawSpriteAngle(sprite);
        }

        private void DrawSpriteAngle(AbstractSprite sprite)
        {
            int pixelLocationX = (int)(sprite.PositionX / precision);
            int pixelLocationY = (int)(sprite.PositionY / precision);

            double realEndingLocationX = sprite.PositionX + Math.Cos(sprite.AngleRadian) * sprite.Diameter;
            double realEndingLocationY = sprite.PositionY + Math.Sin(sprite.AngleRadian) * sprite.Diameter;

            short pixelEndingLocationX = (short)(realEndingLocationX / precision);
            short pixelEndingLocationY = (short)(realEndingLocationY / precision);

            IPrimitive primitive;
            Line angleLine;

            if (angleLineCache.TryGetValue(sprite, out primitive))
            {
                angleLine = (Line)primitive;
            }
            else
            {
                angleLine = new Line();
            }

            angleLine.XPosition1 = (short)pixelLocationX;
            angleLine.YPosition1 = (short)pixelLocationY;


            angleLine.XPosition2 = pixelEndingLocationX;
            angleLine.YPosition2 = pixelEndingLocationY;


            surface.Draw(angleLine, Color.White);
        }

        private void DrawSpriteBounds(AbstractSprite sprite)
        {
            int pixelLocationX = (int)(sprite.PositionX / precision);
            int pixelLocationY = (int)(sprite.PositionY / precision);
            int radius = (int)(sprite.Radius / precision);

            IPrimitive primitive;
            Circle circle;

            if (circleCache.TryGetValue(sprite, out primitive))
            {
                circle = (Circle)primitive;
            }
            else
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
