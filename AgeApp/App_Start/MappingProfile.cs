using AgeApp.Dtos;
using AgeApp.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeApp.App_Start {
    public class MappingProfile : Profile{

        public MappingProfile()
        {
            Mapper.CreateMap<Voter, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Voter>();
        }

    }
}