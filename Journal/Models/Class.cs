using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.Models
{
    public class Class : BaseModel
    {
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        public SubjectTypes SubjectType;
        public IEnumerable<Journal> Journals { get; set; }
    }
}
