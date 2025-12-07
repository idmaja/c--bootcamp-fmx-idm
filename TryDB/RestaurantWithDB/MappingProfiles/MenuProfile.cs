using AutoMapper;

public class MenuProfile : Profile
{
    public MenuProfile()
    {
        CreateMap<CreateMenuRequest, Menu>()
            .ForAllMembers(option => option.Condition((source, destination, sourceMember) => sourceMember != null));
        
        CreateMap<UpdateMenuRequest, Menu>()
            .ForMember(destination => destination.Id, options => options.Ignore()) 
            .ForMember(destination => destination.CreatedAt, options => options.Ignore())
            .ForMember(destination => destination.UpdatedAt, options => options.Ignore())
            .ForMember(destination => destination.Stock, options => options.Ignore())
            .ForMember(destination => destination.Restaurant, options => options.Ignore())
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Menu, MenuResponse>()
            .ForMember(destination => destination.Id, options => options.MapFrom(source => source.Id.ToString().ToUpper()))
            .ForMember(destination => destination.RestaurantId, options => options.MapFrom(source => source.RestaurantId.ToString().ToUpper()));
    }
}