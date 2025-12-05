using AutoMapper;
using Serilog;

public class MenuService : IMenuService
{
    private readonly IMenuRepository _menuRepository;
    private readonly Serilog.ILogger _logger;
    private readonly IMapper _mapper;

    public MenuService(IMenuRepository menuRepository, IMapper mapper)
    {
        _menuRepository = menuRepository;
        _mapper = mapper;

        _logger = Log.ForContext<MenuService>();
    }

    public async Task<Result<IEnumerable<MenuResponse>>> GetAllMenusAsync()
    {
        var menus = await _menuRepository.GetAllAsync();

        _logger.Information("[SERVICE] Get all menus");

        var menusResponse = _mapper.Map<IEnumerable<MenuResponse>>(menus);

        return Result<IEnumerable<MenuResponse>>.Ok(menusResponse);
    }

    public async Task<Result<MenuResponse>> GetMenuByIdAsync(string id)
    {
        Guid.TryParse(id.ToString(), out Guid idMenu);

        var menu = await _menuRepository.GetByIdAsync(idMenu);

        _logger.Information("[SERVICE] Get a menu with id: {id}", id);

        var menuResponse = _mapper.Map<MenuResponse>(menu);

        return Result<MenuResponse>.Ok(menuResponse);
    }

    public async Task<Result<MenuResponse>> CreateMenuAsync(MenuRequest request)
    {
        var addMenu = _mapper.Map<Menu>(request);

        var result = await _menuRepository.AddAsync(addMenu);

        _logger.Information("[SERVICE] Create a menu with id: {id}", addMenu.Id);

        var menuResponse = _mapper.Map<MenuResponse>(result);

        return Result<MenuResponse>.Ok(menuResponse);
    }

    public async Task<Result<MenuResponse>> UpdateMenuAsync(string id, MenuRequest request)
    {
        Guid.TryParse(id.ToString(), out Guid idMenu);

        var updateMenu = _mapper.Map<Menu>(request);

        var result = await _menuRepository.UpdateAsync(idMenu, updateMenu);

        _logger.Information("[SERVICE] Update a menu with id: {id}", id);

        var menuResponse = _mapper.Map<MenuResponse>(result);

        return Result<MenuResponse>.Ok(menuResponse);
    }

    public async Task<Result<bool>> DeleteMenuAsync(string id)
    {
        Guid.TryParse(id.ToString(), out Guid idMenu);

        var result = await _menuRepository.DeleteAsync(idMenu);

        _logger.Information("[SERVICE] Delete a menu with id: {id}", id);

        return Result<bool>.Ok(result);
    }

    public async Task<Result<decimal>> GetTotalStockValueAsync()
    {
        _logger.Information("[SERVICE] Get total stock value menus");

        var menus = await _menuRepository.GetAllAsync();
        decimal total = menus.Sum(menu => menu.Price * menu.Stock);

        return Result<decimal>.Ok(total);
    }
}
