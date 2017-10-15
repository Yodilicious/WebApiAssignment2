namespace Assignment2Music.Api.ViewModels
{
    using System;

    public class ReviewViewModel
    {
        public long RecordId { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewedOn { get; set; }

        public long ArtistId { get; set; }
        public string ArtistName { get; set; }

        public long TrackId { get; set; }
        public string TrackName { get; set; }
    }
}
