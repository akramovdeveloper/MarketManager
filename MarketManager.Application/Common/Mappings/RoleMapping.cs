using AutoMapper;
using MarketManager.Application.Common.Models;
using MarketManager.Domain.Entities.Identity;

namespace MarketManager.Application.Common.Mappings;
public class RoleMapping : Profile
{
    public RoleMapping()
    {
        CreateMap<Role, RoleGetDto>().ReverseMap();
    }
}
