using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Waves;

namespace CvmFight
{
    class WaveMap : AbstractMap
    {
        #region Parts
        /// <summary>
        /// Hard coded map used as seed for wave interference
        /// </summary>
        private HardCodedMap hardCodedMap = new HardCodedMap();

        /// <summary>
        /// To add interference on x axis
        /// </summary>
        private IWave waveX;

        /// <summary>
        /// To add interference on y axis
        /// </summary>
        private IWave waveY;

        /*
        /// <summary>
        /// Wave frequencies
        /// </summary>
        private double[] freq = new double[6];

        /// <summary>
        /// Wave amplutides
        /// </summary>
        private double[] amp = new double[6];

        /// <summary>
        /// Wave phases
        /// </summary>
        private double[] phase = new double[6];*/
        #endregion

        #region Constructors
        /// <summary>
        /// Create wave map
        /// </summary>
        /// <param name="random">random number generator</param>
        public WaveMap(Random random)
        {
            WaveBuilder wavePackBuilder = new WaveBuilder();
            waveX = wavePackBuilder.Build(3, random);
            waveY = wavePackBuilder.Build(3, random);

            /*freq[0] = random.NextDouble() * 0.8 + 0.8;
            freq[1] = random.NextDouble() * 0.8 + 0.8;
            freq[2] = random.NextDouble() * 0.2 + 0.1;
            freq[3] = random.NextDouble() * 0.2 + 0.1;
            freq[4] = random.NextDouble() * 0.01 + 0.01;
            freq[5] = random.NextDouble() * 0.01 + 0.01;

            for (int i = 0; i < 6; i++)
                amp[i] = random.NextDouble() * 3;

            for (int i = 0; i < 6; i++)
                phase[i] = random.NextDouble() * Math.PI * 2 - Math.PI;*/
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns matter type at specified coordinates, null if empty space
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>matter type at specified coordinates, null if empty space</returns>
        public override AbstractMatterType GetMatterTypeAt(double x, double y)
        {
            AbstractMatterType hardCodedMatterType = hardCodedMap.GetMatterTypeAt(x, y);
            if (hardCodedMatterType == null)
                return null;

            x += waveX.GetYValueAt(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
            y += waveY.GetYValueAt(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));


            //x += Math.Sin(x * freq[2] + phase[2]) * amp[2] + Math.Sin(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * freq[4] + phase[4]) * amp[4] + Math.Sin(y * freq[0] + phase[0]) * amp[0];
            //y += Math.Sin(y * freq[3] + phase[3]) * amp[3] + Math.Sin(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * freq[5] + phase[5]) * amp[5] - Math.Sin(x * freq[1] + phase[1]) * amp[1];


            while (x < 0)
                x += hardCodedMap.Width;
            while (x >= hardCodedMap.Width)
                x -= hardCodedMap.Width;
            while (y < 0)
                y += hardCodedMap.Height;
            while (y >= hardCodedMap.Height)
                y -= hardCodedMap.Height;

            return hardCodedMap.GetMatterTypeAt(x, y);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Map's width
        /// </summary>
        public override int Width
        {
            get { return hardCodedMap.Width; }
        }

        /// <summary>
        /// Map's height
        /// </summary>
        public override int Height
        {
            get { return hardCodedMap.Height; }
        }
        #endregion
    }
}