using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.Models
{
    public class Subject : BaseModel
    {
        public string Name { get; set; }
        public int PracticeHours { get; set; }
        public int LaboratoryHours { get; set; }
        public int TheoryHours { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}
