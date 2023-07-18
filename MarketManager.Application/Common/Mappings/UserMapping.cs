using AutoMapper;
using MarketManager.Application.UseCases.Users.Response;
using MarketManager.Domain.Entities.Identity;

namespace MarketManager.Application.Common.Mappings;
public class UserMapping :Profile
{
    public UserMapping()
    {
        CreateMap<UserResponse,User>().ReverseMap();
    }
}
