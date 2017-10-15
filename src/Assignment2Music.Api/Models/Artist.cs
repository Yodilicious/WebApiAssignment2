using System.Collections.Generic;

namespace Assignment2Music.Api.Models
{
    public class Artist : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ArtistName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public IList<Track> Tracks { get; set; }
        public IList<Review> Reviews { get; set; }
    }
}