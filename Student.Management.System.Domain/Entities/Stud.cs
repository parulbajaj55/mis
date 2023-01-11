using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Management.System.Domain.Entities
{
    public class Stud
    {
        public int Id  { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(3)]
        public string? MiddleName { get; set; } 

        public DateTime DateOfBirth { get; set; }
        public int SubjectId { get; set; }
        public Subject? FavouriteSubject { get; set; } 

    }
}