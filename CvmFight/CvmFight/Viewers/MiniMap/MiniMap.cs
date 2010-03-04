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
        private const double precision = 0.025;
        #endregion

        #region Fields and parts
        private Surface mainSurface;

        private Point[,] pointGrid;

        private SpritePrimitiveCache circleCache = new SpritePrimitiveCache();

        private SpritePrimitiveCache angleLineCache = new SpritePrimitiveCache();

        private AbstractMap currentMap = null;

        private Surface mapSurface = null;

        private int screenWidth = 1024;

        private int screenHeight = 768;

        private bool isFullScreen;
        #endregion

        #region Constructor
        public MiniMap(int screenWidth, int screenHeight, bool isFullScreen)
        {
            this.isFullScreen = isFullScreen;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            mainSurface = new Surface(screenWidth, screenHeight);
            mainSurface = Video.SetVideoMode(screenWidth, screenHeight, true, false, isFullScreen, true);
            
            pointGrid = new Point[screenWidth, screenHeight];
            for (int x = 0; x < screenWidth; x++)
                for (int y = 0; y < screenHeight; y++)
                    pointGrid[x, y] = new Point(x, y);
        }
        #endregion

        #region Public Methods
        public override void Update(World world, RayTracer rayTracer)
        {
            mainSurface.Blit(GetOrCreateMapSurface(world.Map));
            foreach (AbstractSprite sprite in world.SpritePool)
                    DrawSprite(sprite, Optics.IsSpriteViewable(world.CurrentPlayer, sprite, world.Map, rayTracer.Fov));

            DrawRayTracer(world.Map, rayTracer);

            mainSurface.Update();
        }
        #endregion

        #region Private Methods
        private Surface GetOrCreateMapSurface(AbstractMap map)
        {
            if (this.currentMap != map)
            {
                this.currentMap = map;
                mapSurface = null;
            }

            if (mapSurface != null)
                return mapSurface;

            int pixelWidth = (int)Math.Ceiling((double)map.Width / precision);
            int pixelHeight = (int)Math.Ceiling((double)map.Height / precision);

            mapSurface = new Surface(pixelWidth, pixelHeight);

            int pixelLocationX = 0;
            for (double mapLocationX = 0; mapLocationX < map.Width; mapLocationX += precision)
            {
                int pixelLocationY = 0;
                for (double mapLocationY = 0; mapLocationY < map.Width; mapLocationY += precision)
                {
                    if (map.GetMatterTypeAt(mapLocationX, mapLocationY) != null)
                        mapSurface.Draw(pointGrid[pixelLocationX, pixelLocationY], Color.Gray);
                    else
                        mapSurface.Draw(pointGrid[pixelLocationX, pixelLocationY], Color.Black);
                    pixelLocationY++;
                }
                pixelLocationX++;
            }

            return mapSurface;
        }

        private void DrawSprite(AbstractSprite sprite, bool isViewable)
        {
            DrawSpriteBounds(sprite, isViewable);
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


            mainSurface.Draw(angleLine, Color.White);
        }

        private void DrawSpriteBounds(AbstractSprite sprite, bool isViewable)
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
                mainSurface.Draw(circle, Color.MediumBlue);
            else if (sprite is AbstractFighter)
            {
                if (isViewable)
                {
                    mainSurface.Draw(circle, Color.Magenta);
                }
                else
                {
                    mainSurface.Draw(circle, Color.Orange);
                }
            }
            else
                mainSurface.Draw(circle, Color.Green);
        }

        private void DrawRayTracer(AbstractMap map, RayTracer rayTracer)
        {
            int positionX;
            int positionY;
            foreach (RayTracerPoint rayTracerPoint in rayTracer)
            {
                positionX = (int)(rayTracerPoint.X / precision);
                positionY = (int)(rayTracerPoint.Y / precision);
                mainSurface.Draw(pointGrid[positionX, positionY], Color.White);
            }
        }
        #endregion
    }
}
