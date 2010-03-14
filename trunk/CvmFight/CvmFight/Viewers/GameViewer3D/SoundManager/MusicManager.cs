using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Audio;

namespace CvmFight
{
    class MusicManager
    {
        #region Fields
        private Random random;

        private List<Music> musicList;
        #endregion

        #region Constructor
        public MusicManager(Random random)
        {
            this.random = random;
        }
        #endregion

        #region Public Methods
        public void PlayRandomMusic()
        {
            musicList = new List<Music>();
            musicList.Add(new Music("Assets/Musics/iCanFeelItHey.ogg"));
            musicList.Add(new Music("Assets/Musics/WaveBuilder - Made in indonesia.ogg"));
            musicList.Add(new Music("Assets/Musics/WaveBuilder - Epic JediHads.ogg"));
            musicList.Add(new Music("Assets/Musics/WaveBuilder - Gypsy Orion.ogg"));

            Music music = musicList[random.Next(musicList.Count)];

            music.Play(true);
        }
        #endregion
    }
}
