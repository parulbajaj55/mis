using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Management.System.Application.Ports.Out;
using Student.Management.System.Domain.Entities;

namespace Student.Management.System.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentDetails>> GetAllStudents()
        {
            return await _studentRepository.GetAllStudents();
        }
    }
}