using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.Models
{
    public class Subject : BaseModel
    {
        [Display(Name = "Предмет")]
        public string Name { get; set; }
        [Display(Name = "Часы Практик")]
        public int PracticeHours { get; set; }
        [Display(Name = "Часы Лабораторных")]
        public int LaboratoryHours { get; set; }
        [Display(Name = "Часы Лекций")]
        public int TheoryHours { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}
