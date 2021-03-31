using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Journal.Models
{
    public class Specialization : BaseModel
    {
        [Required(ErrorMessage = "Введите Специальность")]
        [Display(Name = "Специальность")]
        public string Name { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
