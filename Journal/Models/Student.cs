using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journal.Models
{
    public class Student : User
    {
        [DataType (DataType.Date)]
        [Required (ErrorMessage = "Введите Дату Поступления")]
        [Display (Name = "Год Поступления")]
        public DateTime YearOfEntry { get; set; }
        [Display (Name = "Специальность")]
        public Specialization Specialization { get; set; }
        public int SpecializationId { get; set; }
        //public int StudentId { get; set; }
        public int GroupId { get; set; }
        [Display(Name = "Группа")]
        public Group Group { get; set; }
        public IEnumerable<Journal> Journals { get; set; }
    }
}
