using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Management.System.Domain.Dtos.Student
{
    public class AddStudentDto
    {

        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(3)]
        public string? MiddleName { get; set; } 

        public DateTime DateOfBirth { get; set; }

        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
    }
}