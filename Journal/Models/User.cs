using System.ComponentModel.DataAnnotations;

namespace Journal.Models
{
    public class User : BaseModel
    {
        [Required (ErrorMessage = "Введите Имя" )]
        public string FirstName { get; set; }
        [Required (ErrorMessage = "Введите Фамилию")]
        public string LastName { get; set; }
    }
}
