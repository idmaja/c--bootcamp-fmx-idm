using AutoMapper;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<CreateRestaurantRequest, Restaurant>()
            .ForAllMembers(option => option.Condition((source, destination, sourceMember) => sourceMember != null));
        
        CreateMap<UpdateRestaurantRequest, Restaurant>()
            .ForMember(destination => destination.Id, options => options.Ignore()) 
            .ForMember(destination => destination.Owner, options => options.Ignore())
            .ForMember(destination => destination.Menus, options => options.Ignore())
            .ForMember(destination => destination.CreatedAt, options => options.Ignore())
            .ForMember(destination => destination.UpdatedAt, options => options.Ignore())
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Restaurant, RestaurantResponse>()
            .ForMember(destination => destination.Id, options => options.MapFrom(source => source.Id.ToString().ToUpper()));
    }
}