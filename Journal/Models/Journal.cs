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


        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int ClassId { get; set; }
        [Display(Name = "Занятие")]
        public Class Class { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int StudentId { get; set; }
        [Display(Name = "Студент")]
        public Student Student { get; set; }
        [Display(Name = "Присутствие")]
        public bool Presence { get; set; }
        [Display(Name = "Оценка")]
        public int Mark { get; set; }
        //public int[] Mark { get; } = { 1, 2, 3, 4, 5 };
        public IEnumerable<TeacherJournal> TeachersJournals { get; set; }
    }   
}
