using System.Collections.Generic;

namespace Journal.Models

{
    public class Teacher : User
    {
        public string ScienceDegree { get; set; }
        //public IEnumerable<Journal> Journals { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<TeacherJournal> TeachersJournals { get; set; }
    }
}
