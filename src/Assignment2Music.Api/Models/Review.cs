using System;

namespace Assignment2Music.Api.Models
{
    public class Review : BaseModel
    {
        public string ReviewText { get; set; }
        public DateTime ReviewedOn { get; set; }

        public long ArtistId { get; set; }
        public Artist Artist { get; set; }

        public long TrackId { get; set; }
        public Track Track { get; set; }
    }
}
