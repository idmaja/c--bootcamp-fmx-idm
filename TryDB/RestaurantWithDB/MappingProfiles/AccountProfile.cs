using AutoMapper;
using Microsoft.AspNetCore.Identity;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<CreateAccountRequest, IdentityUser>()
            .ForMember(destination => destination.Id, options => options.Ignore())
            .ForMember(destination => destination.SecurityStamp, options => options.Ignore()) 
            .ForMember(destination => destination.PasswordHash, options => options.Ignore())
            .ForMember(destination => destination.UserName, options => options.MapFrom(source => source.Username)) 
            .ForMember(destination => destination.Email, options => options.MapFrom(source => source.EmailAddress)) 
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<UpdateAccountRequest, IdentityUser>()
            .ForMember(destination => destination.Id, options => options.Ignore()) 
            .ForMember(destination => destination.SecurityStamp, options => options.Ignore()) 
            .ForMember(destination => destination.PasswordHash, options => options.Ignore()) 
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<IdentityUser, AccountResponse>()
            .ForMember(destination => destination.Roles, options => options.Ignore())
            .ForMember(destination => destination.AccountId, options => options.MapFrom(source => source.Id))
            .ForMember(destination => destination.EmailAddress, options => options.MapFrom(source => source.Email));
    }
}