using System.ComponentModel.DataAnnotations;

namespace Journal.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }

    }
}
