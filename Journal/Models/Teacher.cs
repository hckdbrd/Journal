using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journal.Models

{
    public class Teacher : User
    {
        [Required(ErrorMessage = "Введите Научную Степень")]
        [Display(Name = "Научная Степень")]
        public string ScienceDegree { get; set; }
        //public IEnumerable<Journal> Journals { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<TeacherJournal> TeachersJournals { get; set; }
    }
}
