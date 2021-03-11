using System.Collections.Generic;

namespace Journal.Models
{
    public class Group : BaseModel
    {
        public string Name { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable <Student> Students { get; set; }
    }
}
