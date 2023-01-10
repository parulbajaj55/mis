using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Management.System.Domain.Entities
{
    public class Stud
    {
        public int Id  { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }
        public Subject? FavSubject { get; set; } 

    }
}