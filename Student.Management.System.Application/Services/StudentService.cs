using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Student.Management.System.Application.Ports.Out;
using Student.Management.System.Domain.Dtos.Student;
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

         public async Task<IEnumerable<GetStudentDto>> AddStudent(AddStudentDto newStudent)
        {
            return await _studentRepository.AddStudent(newStudent);
        }

        public async Task<IEnumerable<GetStudentDto>> GetAllStudents()
        {
            return await _studentRepository.GetAllStudents();
        }

        public async Task<IEnumerable<GetStudentDto>> RemoveStudent(int id)
        {
            
            return await _studentRepository.RemoveStudent(id);
        }

        public  async Task<IEnumerable<GetStudentDto>> RemoveMultipleStudents(string ids)
        {
            List<string > studentIds = ids.Split(',').ToList();
            
            IEnumerable<GetStudentDto> studentList = new List<GetStudentDto>();
            foreach (string id in studentIds)
            {
                studentList = await RemoveStudent(int.Parse(id));
            }
            return studentList;
        }

        public async Task<GetStudentDto> UpdateStudent(UpdateStudentDto updatedStudent)
        {
            return await _studentRepository.UpdateStudent(updatedStudent);
        }

        public async Task<GetStudentDto> GetStudentById(int id)
        {
            return await _studentRepository.GetStudentById(id);
        }
    }
}