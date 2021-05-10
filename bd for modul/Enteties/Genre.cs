using System;
using System.Collections.Generic;
using System.Text;

namespace bd_for_modul.Enteties
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Title { get; set; }

        public virtual List<Song> Songs { get; set; } = new List<Song>();
    }
}
