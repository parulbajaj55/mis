using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student.Management.System.Application.Services;
using Student.Management.System.Domain.Dtos.Student;
using Student.Management.System.Domain.Entities;

// GetAllStudents() - done
// AddStudent(Student) -done
// UpdateStudentDetails(Student)
// RemoveStudent(Id)
// RemoveStudents(Ids)
// FilterStudent(SubjectId)

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
        public async Task<ActionResult<List<GetStudentDto>>> GetAll(){
            return Ok(await _studentService.GetAllStudents());
        }

        [HttpPost]
        public async Task<ActionResult<List<GetStudentDto>>> AddStudent(AddStudentDto newStudent){
            return Ok(await _studentService.AddStudent(newStudent));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<GetStudentDto>>> RemoveStudent(int id){
            return Ok(await _studentService.RemoveStudent(id));
        }
        
       [HttpDelete]
        public async Task<ActionResult<List<GetStudentDto>>> RemoveMultipleStudents([FromQuery] string ids){

            return Ok(await _studentService.RemoveMultipleStudents(ids));
        }

        [HttpPut]
        public async Task<ActionResult<List<GetStudentDto>>> UpdateStudent(UpdateStudentDto updatedStudent){
            var response = await _studentService.UpdateStudent(updatedStudent);
            if(response is null){
                return NotFound(response);
            }
            return Ok(response);
        }

        
    }
}