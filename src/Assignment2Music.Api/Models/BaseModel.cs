namespace Assignment2Music.Api.Models
{
    using System;

    public class BaseModel
    {
        public long RecordId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
