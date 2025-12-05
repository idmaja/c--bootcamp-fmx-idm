using AutoMapper;

public class MenuProfile : Profile
{
    public MenuProfile()
    {
        CreateMap<MenuRequest, Menu>()
            .ForMember(destination => destination.Name, options => options.MapFrom(source => source.Name))
            .ForMember(destination => destination.Description, options => options.MapFrom(source => source.Description))
            .ForMember(destination => destination.Price, options => options.MapFrom(source => source.Price))
            .ForMember(destination => destination.Stock, options => options.MapFrom(source => source.Stock))
            .ForMember(destination => destination.IsActive, options => options.MapFrom(source => source.IsActive))
            .ForMember(destination => destination.IsDeleted, options => options.MapFrom(source => source.IsDeleted));

        CreateMap<Menu, MenuResponse>();
    }
}