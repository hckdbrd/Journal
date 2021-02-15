using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.Models
{
    public class Class: BaseModel
    {
        public Subject Subject { get; set; }
        public SubjectTypes SubjectType;
    }
}
