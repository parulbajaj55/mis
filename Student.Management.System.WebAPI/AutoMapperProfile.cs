using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Student.Management.System.Domain.Dtos.Student;
using Student.Management.System.Domain.Entities;

namespace Student.Management.System.Infrastructure
{
    public class AutoMapperProfile:Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<StudentDetails,GetStudentDto>();
            CreateMap<AddStudentDto,StudentDetails>();
            CreateMap<UpdateStudentDto,StudentDetails>();
          //  CreateMap<HashSet<StudentDetails>,GetStudentDto>();
        }
    }
}