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
            .ForMember(destination => destination.Name, options => options.Condition(src => src.Name != null))
            .ForMember(destination => destination.Description, options => options.Condition(src => src.Description != null))
            .ForMember(destination => destination.Price, options => options.Condition(src => src.Price != null))
            .ForMember(destination => destination.IsActive, options => options.Condition(src => src.IsActive != null))
            .ForMember(destination => destination.IsDeleted, options => options.Condition(src => src.IsDeleted != null));

        CreateMap<Menu, MenuResponse>();
    }
}