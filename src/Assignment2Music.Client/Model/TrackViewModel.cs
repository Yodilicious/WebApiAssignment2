namespace Assignment2Music.Client.ViewModels
{
    using System;

    public class TrackViewModel
    {
        public long RecordId { get; set; }
        public string TrackName { get; set; }
        public int TrackLength { get; set; }
        public DateTime PostedOn { get; set; }
        public long GenreId { get; set; }
        public string GenreName { get; set; }
        public long ArtistId { get; set; }
        public string ArtistName { get; set; }
    }
}
