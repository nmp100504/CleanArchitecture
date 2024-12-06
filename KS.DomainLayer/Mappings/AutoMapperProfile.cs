using AutoMapper;
using KS.DomainLayer.Dtos;
using KS.InfrastructureLayer.Entities;

namespace KS.DomainLayer.Mappings;

public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>()
               .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));
            CreateMap<Role, RoleDto>().ReverseMap();
        }

}
