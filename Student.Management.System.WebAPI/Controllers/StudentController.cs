using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student.Management.System.Application.Services;
using Student.Management.System.Domain.Entities;

namespace Student.Management.System.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // [HttpGet("GetAll")]
        // public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(){
        //     return Ok(await _characterService.GetAllCharacters());
        // }
        
        [HttpGet]
        public async Task<ActionResult<List<StudentDetails>>> GetAll(){
            return Ok(await _studentService.GetAllStudents());
        }
    }
}