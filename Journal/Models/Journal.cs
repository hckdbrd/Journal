using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journal.Models
{
    public class Journal : BaseModel
    {
        //[DataType(DataType.Date)]
        //[Required(ErrorMessage = "Введите Дату Поступления")]
        //[Display(Name = "Год Поступления")]
        //public DateTime YearOfEntry { get; set; }

        //[Display(Name = "Специальность")]
        //public Specialization Specialization { get; set; }

        public DateTime Date { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        //public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int StudentId { get; set; }
        public Student Stundent { get; set; }
        public bool Presence { get; set; } = true;
        public int Mark { get; set; }
        public IEnumerable<TeacherJournal> TeachersJournals { get; set; }
    }   
}
