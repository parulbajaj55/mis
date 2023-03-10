using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Management.System.Domain.Dtos.Student;
using Student.Management.System.Domain.Entities;

namespace Student.Management.System.Application.Ports.Out
{
    public interface IStudentRepository
    {
        public Task<GetStudentDto> AddStudent(AddStudentDto newStudent);
        public Task<IEnumerable<GetStudentDto>> GetAllStudents();
        public Task<IEnumerable<GetStudentDto>> RemoveStudent(int id);
        public Task<GetStudentDto> UpdateStudent(UpdateStudentDto updatedStudent);

         public Task<GetStudentDto> GetStudentById(int id);
    }
}