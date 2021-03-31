using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journal.Models
{
    public class Group : BaseModel
    {
        [Required(ErrorMessage = "Введите Группу")]
        [Display(Name = "Группа")]
        public string Name { get; set; }
        public int? TeacherId { get; set; }
        [Required(ErrorMessage = "Введите Преподавателя")]
        [Display(Name = "Преподаватель")]
        public Teacher Teacher { get; set; }
        public IEnumerable <Student> Students { get; set; }
    }
}
