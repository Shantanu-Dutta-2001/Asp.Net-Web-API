using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CollegeAPI_CRUD.Controllers;
using CollegeAPI_CRUD.Data;

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

            //config for different property name 
            // CreateMap<StudentDTO, Student>().ReverseMap().ForMember(n => n.StudentName, opt => opt.MapFrom(x => x.Name));

            //config for ignoring some property
            // CreateMap<StudentDTO, Student>().ReverseMap().ForMember(n => n.StudentName, opt => opt.Ignore());
        }
    }
}