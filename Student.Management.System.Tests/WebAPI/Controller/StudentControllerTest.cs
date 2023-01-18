using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Student.Management.System.Application.Services;
using Student.Management.System.Domain.Dtos.Student;
using Student.Management.System.Domain.Entities;
using Student.Management.System.WebAPI.Controllers;
using Xunit;

namespace Student.Management.System.Tests.WebAPI.Controller
{
    public class StudentControllerTest
    {
        private readonly Mock<IStudentService> _mockService;
        private readonly StudentController _controller;

        public StudentControllerTest()
        {
            _mockService = new Mock<IStudentService>();
            _controller = new StudentController(_mockService.Object);
        }

        [Fact]
        public async void ShouldReturnListOfAllStudentsWhenCalled()
        {
            var test = new List<GetStudentDto> {new GetStudentDto(), new GetStudentDto() };

            _mockService.Setup( service =>  service.GetAllStudents())
               .ReturnsAsync((test));
   
            var result = await  _controller.GetAll();
            var actual = (result.Result as OkObjectResult);
            var okResult = Assert.IsType<OkObjectResult>(actual);
            var students = Assert.IsType<List<GetStudentDto>>(okResult.Value);
            Assert.Equal(2, students.Count);
    
            Assert.NotNull(actual);
            Assert.Equal(200, actual.StatusCode);

        }

        [Fact]
        public async void ShouldDeleteStudentWhenIdIsGiven()
        {
             var id = 1;
             var test = new List<GetStudentDto> {new GetStudentDto(), new GetStudentDto() };
            _mockService.Setup(s => s.RemoveStudent(id));

            await _controller.RemoveStudent(id);
            _mockService.Verify(s => s.RemoveStudent(id), Times.Once);
        }
        [Fact]
        public async void ShouldDeleteMultipleStudentWhenIdsAreGiven(){
            string ids = "1,2,3";
            var test = new List<GetStudentDto> {new GetStudentDto(), new GetStudentDto(), new GetStudentDto() };
            _mockService.Setup(s => s.RemoveMultipleStudents(ids));

             await _controller.RemoveMultipleStudents(ids);
            _mockService.Verify(s => s.RemoveMultipleStudents(ids), Times.Once);

        }

        //  [Fact]
        // public async void ShouldAddNewStudentWhenCalled(){

        //     var studentList = new List<StudentDetails>();

        //     var studentTest = new AddStudentDto{
        //         FirstName = "Test Name",
        //         MiddleName="Test Name",
        //         LastName="Test Name",
        //         DateOfBirth= new DateTime(2000,10,10),
        //         SubjectId = 1
        //     };
        //     //  AddStudentDto studentDto=new AddStudentDto();
        //     // _mockService.Setup(r => r.AddStudent(It.IsAny<AddStudentDto>())).Callback<AddStudentDto>(x => studentDto = x);
        //     // Task<ActionResult<List<GetStudentDto>>> task = _controller.AddStudent(studentTest);

        //     _mockService.Setup(x => x.AddStudent(studentTest)).Returns(studentList.Add(studentTest));

        // }

    }  
       
}