using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Student.Management.System.Application.Ports.Out;
using Student.Management.System.Domain.Dtos.Student;
using Student.Management.System.Infrastructure.Data;

namespace Student.Management.System.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DataContext _context;

            private readonly IMapper _mapper;
        public SubjectRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<GetStudentDto>> FilterStudents(int subjectId)
        {
            //var students = _context.Students.Where(s => s.SubjectId == subjectId).ToList();
            var students = _context.Subjects.Where(s => s.SubjectId == subjectId).Include("Students")
            .Select(s => s.Students).First();
            //return students;
            
            return students.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
        }
    }
}