using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Student.Management.System.Application.Ports.Out;
using Student.Management.System.Domain.Dtos.Student;
using Student.Management.System.Domain.Entities;
using Student.Management.System.Infrastructure.Data;

namespace Student.Management.System.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

            private readonly IMapper _mapper;
        public StudentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetStudentDto>> AddStudent(AddStudentDto newStudent)
        {
            var student = _mapper.Map<StudentDetails> (newStudent);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return await GetAllStudents();

        }

        public async Task<IEnumerable<GetStudentDto>> GetAllStudents()
        {
            // var students = await _context.Students.ToListAsync();
            // return students;
            //return context.Students.Include("Subject").ToList();

            var dbStudents = _context.Students.Select(s => new StudentDetails{
                FirstName = s.FirstName,
                MiddleName = s.MiddleName, 
                LastName = s.LastName, 
                DateOfBirth = s.DateOfBirth,
                Id = s.Id,
                SubjectId = s.SubjectId,
                Subject = new Subject{SubjectName = s.Subject.SubjectName, SubjectId = s.Subject.SubjectId}
            }).ToList();

            return dbStudents.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
        }

        public async Task<IEnumerable<GetStudentDto>> RemoveStudent(int id)
        {
   
             var student = await _context.Students.FirstOrDefaultAsync(c => c.Id == id);

             if(student is null)
             throw new Exception($"Student with id '{id}' not found");

                _context.Students.Remove(student);
                await _context.Students.Select(s => _mapper.Map<GetStudentDto>(s)).ToListAsync();

                await _context.SaveChangesAsync();

            return await GetAllStudents();
            
            
        }
    }
}