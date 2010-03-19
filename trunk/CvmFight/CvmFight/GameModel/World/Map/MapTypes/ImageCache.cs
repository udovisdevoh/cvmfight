using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CvmFight
{
    /// <summary>
    /// Represents image cache
    /// </summary>
    class ImageCache
    {
        #region Constants
        private const string fileSuffix = ".bin";
        #endregion

        #region Fields
        private string originalFileName;
        #endregion

        #region Constructor
        public ImageCache(string originalFileName)
        {
            this.originalFileName = originalFileName;
        }
        #endregion

        #region Public Methods
        public bool TryLoadMapCache(out AbstractMatterType[,] mapCache, int width, int height)
        {
            mapCache = null;
            FileInfo file = new FileInfo(originalFileName + fileSuffix);
            if (!file.Exists)
                return false;

            AbstractMatterType wall = new MatterTypeWall();
            mapCache = new AbstractMatterType[width, height];

            int x = 0;
            int y = 0;
            using (BinaryReader binaryReader = new BinaryReader(File.Open(originalFileName + fileSuffix, FileMode.Open)))
            {
                int position = 0;
                int length = (int)binaryReader.BaseStream.Length;

                while (position < length)
                {
                    bool value = binaryReader.ReadBoolean();

                    if (value)
                        mapCache[x, y] = wall;
                    else
                        mapCache[x, y] = null;

                    x++;
                    if (x == width)
                    {
                        x = 0;
                        y++;
                    }

                    position += sizeof(bool);
                }
            }

            return true;
        }

        public void SaveCache(AbstractMatterType[,] mapCache, int width, int height)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(originalFileName + fileSuffix, FileMode.Create)))
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        binaryWriter.Write(mapCache[x, y] != null);
                    }
                }
            }
        }
        #endregion
    }
}