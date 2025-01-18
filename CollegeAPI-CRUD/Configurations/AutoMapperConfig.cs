using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace CollegeAPI_CRUD.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Way 1: to create mapping fot to and fro
            // CreateMap<Student, StudentDTO>();
            // CreateMap<StudentDTO, Student>();

            // Way 2: Map to and fro at once using reverseMap
            // CreateMap<StudentDTO, Student>().ReverseMap();
        }
    }
}