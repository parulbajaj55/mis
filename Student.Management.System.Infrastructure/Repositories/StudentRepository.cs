using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student.Management.System.Application.Ports.Out;
using Student.Management.System.Domain.Entities;
using Student.Management.System.Infrastructure.Data;

namespace Student.Management.System.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentDetails>> GetAllStudents()
        {
            // var students = await _context.Students.ToListAsync();
            // return students;
            //return context.Students.Include("Subject").ToList();

            return _context.Students.Select(s => new StudentDetails{
                FirstName = s.FirstName,
                MiddleName = s.MiddleName, 
                LastName = s.LastName, 
                DateOfBirth = s.DateOfBirth,
                Id = s.Id,
                SubjectId = s.SubjectId,
                Subject = new Subject{SubjectName = s.Subject.SubjectName, SubjectId = s.Subject.SubjectId}
            }).ToList();
        }

    }
}