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
        _logger.Information("[SERVICE] Get all Menu(s)");

        try
        {
            var menus = await _menuRepository.GetAllAsync();
            if (!menus.Any())
            {
                _logger.Warning("[SERVICE] Menu(s) is empty");
                return Result<IEnumerable<MenuResponse>>.Failed("Menu(s) is empty!");
            }

            var menusResponse = _mapper.Map<IEnumerable<MenuResponse>>(menus);

            return Result<IEnumerable<MenuResponse>>.Ok(menusResponse);
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to get all Menu(s): {message}", ex.Message);
            return Result<IEnumerable<MenuResponse>>.Failed("Failed to get all Menu(s)");
        }
    }

    public async Task<Result<MenuResponse>> GetMenuByIdAsync(string id)
    {
        _logger.Information("[SERVICE] Get a menu with Menu ID: {id}", id);

        try
        {
            if(!Guid.TryParse(id.ToString(), out Guid idMenu))
            {
                _logger.Error("[SERVICE] Invalid ID Menu: {id}", id);
                return Result<MenuResponse>.Failed("Invalid ID Menu");
            }

            var menu = await _menuRepository.GetByIdAsync(idMenu);
            if (menu == null)
            {
                _logger.Warning("[SERVICE] Menu not found");
                return Result<MenuResponse>.Failed("Menu not found");
            }

            var menuResponse = _mapper.Map<MenuResponse>(menu);

            return Result<MenuResponse>.Ok(menuResponse);   
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to get menu by ID: {message}", ex.Message);
            return Result<MenuResponse>.Failed("Failed to get menu");
        }
    }

    public async Task<Result<MenuResponse>> CreateMenuAsync(CreateMenuRequest request)
    {
        _logger.Information("[SERVICE] Create a menu");

        try
        {    
            var newMenu = _mapper.Map<Menu>(request);

            newMenu.IsDeleted = false;
            newMenu.CreatedAt = DateTime.UtcNow;
            newMenu.UpdatedAt = DateTime.UtcNow;

            var result = await _menuRepository.AddAsync(newMenu);

            var menuResponse = _mapper.Map<MenuResponse>(result);

            return Result<MenuResponse>.Ok(menuResponse);
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to create Menu: {message}", ex.Message);
            return Result<MenuResponse>.Failed("Failed to create menu");
        }
    }

    public async Task<Result<MenuResponse>> UpdateMenuAsync(string id, UpdateMenuRequest request)
    {
        _logger.Information("[SERVICE] Update a menu with id: {id}", id);

        try
        {    
            if(!Guid.TryParse(id.ToString(), out Guid idMenu))
            {
                return Result<MenuResponse>.Failed("Invalid ID Menu");
            }

            var existingMenu = await _menuRepository.GetByIdAsync(idMenu);
            if (existingMenu == null)
            {
                return Result<MenuResponse>.Failed("Menu not found");
            }

            _mapper.Map(request, existingMenu);

            existingMenu.UpdatedAt = DateTime.UtcNow;

            var result = await _menuRepository.UpdateAsync(existingMenu);

            var menuResponse = _mapper.Map<MenuResponse>(result);

            return Result<MenuResponse>.Ok(menuResponse);
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to update Menu: {message}", ex.Message);
            return Result<MenuResponse>.Failed("Failed to update menu");
        }
    }

    public async Task<Result<MenuResponse>> DeleteMenuAsync(string id)
    {
        _logger.Information("[SERVICE] Delete a menu with id: {id}", id);

        try
        {
            if(!Guid.TryParse(id.ToString(), out Guid idMenu))
            {
                return Result<MenuResponse>.Failed("Invalid ID Menu");
            }

            var existingMenu = await _menuRepository.GetByIdAsync(idMenu);
            if (existingMenu == null)
            {
                return Result<MenuResponse>.Failed("Menu not found");
            }
            else if (existingMenu.IsDeleted)
            {
                return Result<MenuResponse>.Failed($"Menu '{existingMenu.Name}' already deleted");
            }

            existingMenu.IsDeleted = true;
            existingMenu.UpdatedAt = DateTime.UtcNow;

            var result = await _menuRepository.UpdateAsync(existingMenu);

            var menuResponse = _mapper.Map<MenuResponse>(result);

            return Result<MenuResponse>.Ok(menuResponse);
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to delete Menu: {message}", ex.Message);
            return Result<MenuResponse>.Failed("Failed to delete menu");
        }
    }

    public async Task<Result<decimal>> GetTotalStockValueAsync()
    {
        _logger.Information("[SERVICE] Get Total Value by stock Menu(s)");

        try
        {    
            var menus = await _menuRepository.GetAllAsync();
            if (!menus.Any())
            {
                _logger.Warning("[SERVICE] Menu(s) not found");
                return Result<decimal>.Failed("Menu(s) not found");
            }
            decimal total = menus.Sum(menu => menu.Price * menu.Stock);

            return Result<decimal>.Ok(total);
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to get Total Value by Stock: {message}", ex.Message);
            return Result<decimal>.Failed("Failed to get total value by stock");
        }
    }
}
