using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Student.Management.System.Application.Services;
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

        // [Fact]
        // public void ShouldReturnListOfAllStudentsWhenCalled()
        // {

        //      Task<IEnumerable<StudentDetails>> var = new Task<List<StudentDetails>> {new StudentDetails(), new StudentDetails() };

        //     _mockService.Setup(service => service.GetAllStudents())
        //         .Returns( new Task<IEnumerable<StudentDetails>>() {new StudentDetails(), new StudentDetails() });

        //     var result = _controller.GetAll();

        //     var okResult = Assert.IsType<OkObjectResult>(result);

        //     var students = Assert.IsType<List<StudentDetails>>(okResult.Value);
        //     Assert.Equal(2, students.Count);
        // }

        
        // [Fact]
        // public void ShouldReturnListOfAllStudentsWhenCalled2()
        // {
        //     Task<IEnumerable<StudentDetails>> var = new Task<List<StudentDetails>> {new StudentDetails(), new StudentDetails() };
        //      _mockService.Setup(service => service.GetAllStudents())
        //         .ReturnsAsync(new List<StudentDetails>() { new StudentDetails(), new StudentDetails() });

        //     var result = _controller.GetAll();

        //     var okResult = Assert.IsType<OkObjectResult>(result);

        //     var students = Assert.IsType<List<StudentDetails>>(okResult.Value);
        //     Assert.Equal(2, students.Count);
        // }
    }
}