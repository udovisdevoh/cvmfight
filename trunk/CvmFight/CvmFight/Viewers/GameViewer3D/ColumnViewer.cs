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
    class ColumnViewer
    {
        #region Constants
        private double heightDistanceRatio = 2;
        #endregion

        #region Fields and parts
        private int columnCount;

        private int columnWidthPixel;

        private int screenWidth;

        private int screenHeight;

        private Rectangle[] rectangleCache;
        #endregion

        #region Constructor
        public ColumnViewer(int screenWidth, int screenHeight, int columnCount)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.columnCount = columnCount;
            this.columnWidthPixel = screenWidth / columnCount;

            this.rectangleCache = new Rectangle[columnCount];
            for (int i = 0; i < columnCount; i++)
            {
                this.rectangleCache[i] = new Rectangle();
                this.rectangleCache[i].Width = columnWidthPixel;
            }
        }
        #endregion

        #region Public Methods
        public void Update(AbstractSprite currentPlayer, RayTracer rayTracer, Surface surface)
        {
            int columnXLeftMargin = 0;
            for (int columnId = 0; columnId < columnCount; columnId++)
            {
                double straightDistance = Optics.GetStraightDistance(currentPlayer, rayTracer[columnId]);
                double columnHeight = Optics.GetColumnHeight(straightDistance, screenHeight, heightDistanceRatio);
                double topMargin = Optics.GetColumnTopMargin(screenHeight, columnHeight, currentPlayer.PositionZ, currentPlayer.IsCrouch);

                Rectangle rectangle = rectangleCache[columnId];
                rectangle.X = columnXLeftMargin;
                rectangle.Y = (int)topMargin;
                rectangle.Height = (int)columnHeight;

                columnXLeftMargin += columnWidthPixel;

                int brightness = (int)Math.Round(columnHeight / screenHeight * 255);
                brightness = Math.Max(0, brightness);
                brightness = Math.Min(255, brightness);

                surface.Fill(rectangle, Color.FromArgb(255,brightness,brightness,brightness));
            }
        }
        #endregion
    }
}
