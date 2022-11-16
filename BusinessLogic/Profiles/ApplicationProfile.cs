using BusinessLogic.DTOs;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Profiles
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<TV, TVDto>()
                .ForMember(d => d.ColId, opt => opt.MapFrom(c => c.ColorId))
                .ForMember(d => d.ColName, opt => opt.MapFrom(c => c.Color.Name));
            
            CreateMap<TVDto, TV>()
                    .ForMember(d => d.ColorId, opt => opt.MapFrom(c => c.ColId));

            CreateMap<UserDto, IdentityUser>()
                    .ForMember(d => d.UserName, opt => opt.MapFrom(c => c.Email))
                    .ForMember(d => d.PasswordHash, opt => opt.Ignore())
                    .ForMember(d => d.Id, opt => opt.Ignore());

        }
    }
}
