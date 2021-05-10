using System;
using System.Collections.Generic;
using System.Text;

namespace bd_for_modul.Enteties
{
        public class Song
    {
        public int SongId { get; set; }
        public string SongTitle { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleasedDate { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual List<Artist> Artists { get; set; } = new List<Artist>();
    }
}
