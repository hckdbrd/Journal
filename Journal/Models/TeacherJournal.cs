using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.Models
{
    public class TeacherJournal
    {
        public int TeacherId { get; set; }
        public int JournalId { get; set; }

        public Teacher Teacher { get; set; }
        public Journal Journal { get; set; }
    }
}
