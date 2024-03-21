namespace ClassLibrary
{
    public class NewMusic : Music   
    {
        public string Genre { get; set; }

        public NewMusic(string title, string artist, int year, string genre)
                :base(title, artist, year)
        { 
           Genre = genre;
        }
    }

}
