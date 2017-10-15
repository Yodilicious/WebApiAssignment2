using System;
using System.Collections.Generic;

namespace Assignment2Music.Api.Models
{
    public class Track : BaseModel
    {
        public string TrackName { get; set; }
        public int TrackLength { get; set; }
        public DateTime PostedOn { get; set; }

        public long GenreId { get; set; }
        public Genre Genre { get; set; }

        public long ArtistId { get; set; }
        public Artist Artist { get; set; }

        public IList<Review> Reviews { get; set; }
    }
}
