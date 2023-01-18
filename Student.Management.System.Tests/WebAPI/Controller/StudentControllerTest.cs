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

    }

       
}