using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Music
    {
        public string Title { get; set; }

        public string Artist { get; set; }

        public int Date { get; set; }

        public Music(string title, string artist, int date)
        {
            Title = title;
            Artist = artist;
            Date = date;
        }

    }
}
