using System;

namespace Journal.Models
{
    public class Journal : BaseModel
    {
        public DateTime Date { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        //public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int StudentId { get; set; }
        public Student Stundent { get; set; }
        public bool Presence { get; set; } = true;
        public int Mark { get; set; }
    }   
}
