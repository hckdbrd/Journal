using System;

namespace Journal.Models
{
    public class Student : User
    {
        public DateTime YearOfEntry { get; set; }
        public Specialization Specialization { get; set; }
        public Group Group { get; set; }
    }
}
