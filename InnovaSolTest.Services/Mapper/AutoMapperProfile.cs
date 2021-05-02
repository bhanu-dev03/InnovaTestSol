using AutoMapper;
using InnovaSolTest.Models.Entities;
using InnovaSolTest.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnovaSolTest.Services.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
