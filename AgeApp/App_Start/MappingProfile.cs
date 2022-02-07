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

            //Domain to Dto

            Mapper.CreateMap<Voter, CustomerDto>();
            Mapper.CreateMap<Ballot, BallotDto>();



            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Voter>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<BallotDto, Ballot>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }

    }
}