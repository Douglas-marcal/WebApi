using WebApi.Models;
using AutoMapper;

namespace WebApi.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Post, PostDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
    }
}
