using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Management.System.Domain.Dtos.Student;

namespace Student.Management.System.Application.Ports.In
{
    public interface ISubjectService
    {
        public Task<ICollection<GetStudentDto>> FilterStudents(int subjectId);
    }
}