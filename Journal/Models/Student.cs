﻿using System;
using System.Collections.Generic;

namespace Journal.Models
{
    public class Student : User
    {
        public DateTime YearOfEntry { get; set; }
        public Specialization Specialization { get; set; }
        public int SpecializationId { get; set; }
        public int StudentId { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
        public IEnumerable<Journal> Journals { get; set; }
    }
}
