using Accounting.Application.Common;
using Accounting.Application.Responses;
using Accounting.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Application.Mappers
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, LoginUserCommand>().ReverseMap();
        }
    }
}
