using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SongManager
    {
        private List<Song> songs;

        public SongManager()
        {
            songs = new List<Song>();
        }

        public void Add(Song song)
        {
            songs.Add(song);
        }

        public Song[] GetArray()
        {
            return songs.ToArray();
        }

        public bool Remove(Song song)
        {
            return songs.Remove(song);
        }

        public void UpdateSong(Song newSong, Song oldSong)
        {
            int index = songs.FindIndex(sng => sng == oldSong);
            if (index != -1)
            {
                songs[index] = newSong;
            }
            else
            {
                Console.WriteLine("Something went wrong when updating the song");
            }
        }
    }
}
