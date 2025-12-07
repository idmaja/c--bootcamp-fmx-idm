using AutoMapper;
using Microsoft.AspNetCore.Identity;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<RegisterRequest, IdentityUser>()
            .ForMember(destination => destination.Id, options => options.Ignore()) 
            .ForMember(destination => destination.SecurityStamp, options => options.Ignore())
            .ForMember(destination => destination.PasswordHash, options => options.Ignore())
            .ForMember(destination => destination.UserName, options => options.MapFrom(source => source.Username))
            .ForMember(destination => destination.Email, options => options.MapFrom(source => source.Email));
        
        // CreateMap<IdentityUser, AuthResponse>();
    }
}