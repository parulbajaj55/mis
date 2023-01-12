using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Management.System.Domain.Entities
{
    public class Subject
    {
        public int SubjectId  { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public ICollection<StudentDetails> Students {get; set;}
    
    }
}