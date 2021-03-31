using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.Models
{
    public class Class : BaseModel
    {
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Предмет")]
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        public SubjectTypes SubjectType;
        public IEnumerable<Journal> Journals { get; set; }
    }
}
