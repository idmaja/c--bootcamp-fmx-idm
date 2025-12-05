using AutoMapper;
using Microsoft.AspNetCore.Identity;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<RegisterRequest, IdentityUser>()
            .ForMember(destination => destination.Id, options => options.MapFrom(source => Guid.NewGuid()))
            .ForMember(destination => destination.UserName, options => options.MapFrom(source => source.Username))
            .ForMember(destination => destination.Email, options => options.MapFrom(source => source.Email))
            .ForMember(destination => destination.NormalizedUserName, options => options.MapFrom(source => source.Username!.ToUpper()))
            .ForMember(destination => destination.NormalizedEmail, options => options.MapFrom(source => source.Email!.ToUpper()));
        
        // CreateMap<IdentityUser, AuthResponse>();
    }
}