using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Management.System.Domain.Entities;

namespace Student.Management.System.Application.Ports.Out
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<StudentDetails>> GetAllStudents();
    }
}