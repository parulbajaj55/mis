using System.Linq;
using AutoMapper;
using Dapper;
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
            private readonly DapperContext _dapperContext;
        public StudentRepository(DataContext context, IMapper mapper,DapperContext dapperContext)
        {
            _context = context;
            _mapper = mapper;
            _dapperContext=dapperContext;
        }

        public async Task<GetStudentDto> GetStudentById(int id)
        {
            var query = "SELECT * FROM students s where s.id = " + id;
             using (var connection = _dapperContext.CreateConnection())
            {
                var studentList = await connection.QueryAsync<StudentDetails>(query);
                var student =studentList.ToList().First();
                var result = _mapper.Map<GetStudentDto>(student);
                return result;
            }
        }


        public async Task<GetStudentDto> AddStudent(AddStudentDto newStudent)
        {
            var student = _mapper.Map<StudentDetails> (newStudent);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetStudentDto>(student);

        }

        public async Task<IEnumerable<GetStudentDto>> GetAllStudents()
        {
            // var students = await _context.Students.ToListAsync();
            // return students;
            //return context.Students.Include("Subject").ToList();

            var dbStudents = await _context.Students.Select(s => new StudentDetails{
                FirstName = s.FirstName,
                MiddleName = s.MiddleName, 
                LastName = s.LastName, 
                DateOfBirth = s.DateOfBirth,
                Id = s.Id,
                SubjectId = s.SubjectId,
                Subject = new Subject{SubjectName = s.Subject.SubjectName, SubjectId = s.Subject.SubjectId}
            }).ToListAsync();

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

        public async Task<GetStudentDto> UpdateStudent(UpdateStudentDto updatedStudent)
        {
            var response = new GetStudentDto();
            try {
                var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == updatedStudent.Id);
                if(student is null){
                    throw new Exception($"Student with Id '{updatedStudent.Id}' not found.");
                }

                student.FirstName = updatedStudent.FirstName;
                student.LastName = updatedStudent.LastName;
                student.MiddleName = updatedStudent.MiddleName;
                student.DateOfBirth = updatedStudent.DateOfBirth;
                student.SubjectId = updatedStudent.SubjectId;
                //student.Subject = updatedStudent.Subject;
                await _context.SaveChangesAsync();

                // var abc = from StudentDetails student1 in _context.Students  
                //         where student1.Id == updatedStudent.Id  
                //         select new StudentDetails{
                //             FirstName = student.FirstName,
                //             MiddleName = student.MiddleName, 
                //             LastName = student.LastName, 
                //             DateOfBirth = student.DateOfBirth,
                //             SubjectId = student.SubjectId,
                //             Subject = new Subject{SubjectName = student.Subject.SubjectName, 
                //             SubjectId = student.Subject.SubjectId}};
                Console.WriteLine("id od student " + updatedStudent.Id);
                var dbStudent =  _context.Students.Where(s => s.Id == updatedStudent.Id).Select(s
                => new StudentDetails{
                FirstName = student.FirstName,
                MiddleName = student.MiddleName, 
                LastName = student.LastName, 
                DateOfBirth = student.DateOfBirth,
                SubjectId = student.SubjectId,
                Subject = new Subject{SubjectName = student.Subject.SubjectName, SubjectId = student.Subject.SubjectId}
            })
            ;
                response =  _mapper.Map<GetStudentDto>(student);
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
            return response;
        }
    }
}