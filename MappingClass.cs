using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace TrainingProject
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class UserDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
