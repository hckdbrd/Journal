using System;

namespace Journal.Models
{
    public class Journal : BaseModel
    {
        public DateTime Date { get; set; }
        public Class Class { get; set; }
        public Teacher Teacher { get; set; }
        public Student Stundent { get; set; }
        public bool Presence { get; set; } = true;
        public int Mark { get; set; }
    }
}
