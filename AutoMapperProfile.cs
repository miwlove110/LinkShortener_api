using AutoMapper;
using LinkShortener.DTOs;
using LinkShortener.DTOs.ShortLink;
using LinkShortener.Models;
using LinkShortener.Models.ShortLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<User, UserDto>();
            // CreateMap<Role, RoleDto>()
            //     .ForMember(x => x.RoleName, x => x.MapFrom(x => x.Name));
            // CreateMap<RoleDtoAdd, Role>()
            //     .ForMember(x => x.Name, x => x.MapFrom(x => x.RoleName)); ;
             CreateMap<ShortLink, GetShortLinkDto>();
        }
    }
}