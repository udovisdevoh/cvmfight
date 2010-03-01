﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    /// <summary>
    /// Represents an abstract map for the game
    /// </summary>
    abstract class AbstractMap
    {
        /// <summary>
        /// Returns what kind of matter is present at x,y
        /// Can be null if region space is empty
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>Can be null if it's empty, returns what matter type is at specified location</returns>
        public abstract AbstractMatterType GetMatterTypeAt(double x, double y);

        /// <summary>
        /// Map's width
        /// </summary>
        public abstract int Width
        {
            get;
        }

        /// <summary>
        /// Map's height
        /// </summary>
        public abstract int Height
        {
            get;
        }
    }
}