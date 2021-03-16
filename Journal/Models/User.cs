using System.ComponentModel.DataAnnotations;

namespace Journal.Models
{
    public class User : BaseModel
    {
        [Required (ErrorMessage = "Введите Имя" )]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required (ErrorMessage = "Введите Фамилию")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
    }
}
