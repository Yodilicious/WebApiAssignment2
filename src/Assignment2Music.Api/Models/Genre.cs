namespace Assignment2Music.Api.Models
{
    using System.Collections.Generic;

    public class Genre : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<Track> Tracks { get; set; }
    }
}