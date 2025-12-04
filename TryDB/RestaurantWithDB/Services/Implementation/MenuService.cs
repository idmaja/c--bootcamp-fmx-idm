using Serilog;

public class MenuService : IMenuService
{
    private readonly IMenuRepository _menuRepository;
    private readonly Serilog.ILogger _logger;

    public MenuService(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
        _logger = Log.ForContext<MenuService>();
    }

    public async Task<ResultReponse<IEnumerable<Menu>>> GetAllMenusAsync()
    {
        _logger.Information("[SERVICE] Get all menus");

        var menus = await _menuRepository.GetAllAsync();

        return ResultReponse<IEnumerable<Menu>>.Ok(menus);
    }

    public async Task<ResultReponse<Menu?>> GetMenuByIdAsync(string id)
    {
        _logger.Information("[SERVICE] Get a menu with id: {id}", id);

        Guid.TryParse(id.ToString(), out Guid idMenu);

        var menu = await _menuRepository.GetByIdAsync(idMenu);

        return ResultReponse<Menu?>.Ok(menu);
    }

    public async Task<ResultReponse<Menu>> CreateMenuAsync(MenuRequest request)
    {
        var menu = new Menu
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock,
            IsActive = request.IsActive,
            IsDeleted = request.IsDeleted,
        };

        _logger.Information("[SERVICE] Create a menu with id: {id}", menu.Id);

        await _menuRepository.AddAsync(menu);

        return ResultReponse<Menu>.Ok(menu);
    }

    public async Task<ResultReponse<Menu?>> UpdateMenuAsync(string id, MenuRequest request)
    {
        _logger.Information("[SERVICE] Update a menu with id: {id}", id);

        Guid.TryParse(id.ToString(), out Guid idMenu);

        var menu = new Menu
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock,
            IsActive = request.IsActive,
            IsDeleted = request.IsDeleted,
        };

        await _menuRepository.UpdateAsync(idMenu, menu);

        return ResultReponse<Menu?>.Ok(menu);
    }

    public async Task<ResultReponse<bool>> DeleteMenuAsync(string id)
    {
        _logger.Information("[SERVICE] Delete a menu with id: {id}", id);

        Guid.TryParse(id.ToString(), out Guid idMenu);

        await _menuRepository.DeleteAsync(idMenu);

        return ResultReponse<bool>.Ok(true);
    }

    public async Task<ResultReponse<decimal>> GetTotalStockValueAsync()
    {
        _logger.Information("[SERVICE] Get total stock value menus");

        var menus = await _menuRepository.GetAllAsync();
        decimal total = menus.Sum(menu => menu.Price * menu.Stock);

        return ResultReponse<decimal>.Ok(total);
    }
}
