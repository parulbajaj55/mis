using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student.Management.System.Application.Ports.In;
using Student.Management.System.Domain.Dtos.Student;

namespace Student.Management.System.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<GetStudentDto>>> FilterStudents(int subjectId){
            return Ok(await _subjectService.FilterStudents(subjectId));
        }
    }
}