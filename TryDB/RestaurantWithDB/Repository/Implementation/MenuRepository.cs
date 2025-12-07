using Microsoft.EntityFrameworkCore;
using Serilog;

public class MenuRepository : IMenuRepository
{
    private readonly RestaurantDbContext _context;

    private readonly Serilog.ILogger _logger;

    public MenuRepository(RestaurantDbContext context)
    {
        _context = context;
        _logger = Log.ForContext<MenuRepository>();
    }

    public async Task<IEnumerable<Menu>> GetAllAsync()
    {
        _logger.Information("[REPO] Get all menus");

        return await _context.Menus.ToListAsync();
    }

    public async Task<Menu?> GetByIdAsync(Guid id)
    {
        _logger.Information("[REPO] Get a menu by id: {id}", id);

        return await _context.Menus.FindAsync(id);
    }

    public async Task<Menu> AddAsync(Menu menu)
    {
        _logger.Information("[REPO] Create a menu with id: {id}", menu.Id);

        _context.Menus.Add(menu);

        await _context.SaveChangesAsync();

        return menu;
    }

    public async Task<Menu?> UpdateAsync(Menu menu)
    {
        _logger.Information("[REPO] Update a menu with id: {id}", menu.Id);

        _context.Menus.Update(menu);

        await _context.SaveChangesAsync();

        return menu;
    }
}
