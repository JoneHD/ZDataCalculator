using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZData.LoanCalculator.Common.Dtos;
using ZData.LoanCalculator.Models.Entities.LoanTypes;

namespace ZData.LoanCalculator.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoanType, LoanTypeDto>();
        }
    }
}
