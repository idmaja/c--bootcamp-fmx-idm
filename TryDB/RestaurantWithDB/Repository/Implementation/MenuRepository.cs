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

    public async Task<Menu?> UpdateAsync(Guid id, Menu menu)
    {
        _logger.Information("[REPO] Update a menu with id: {id}", id);

        var existingMenu = await _context.Menus.FindAsync(id);

        if (existingMenu == null)
        {
            return null;
        }

        existingMenu.Name = menu.Name ?? existingMenu.Name;
        existingMenu.Description = menu.Description ?? existingMenu.Description;
        existingMenu.Stock = menu.Stock != default ? menu.Stock : existingMenu.Stock;
        existingMenu.IsActive = menu.IsActive;
        existingMenu.IsDeleted = menu.IsDeleted;
        existingMenu.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();

        return menu;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        _logger.Information("[REPO] Soft Delete a menu with id: {id}", id);

        var menu = await _context.Menus.FindAsync(id);
        if (menu != null)
        {
            /// HARD DELETE
            // _context.Menus.Remove(menu);

            /// SOFT DELETE
            menu.IsDeleted = true; 
            await _context.SaveChangesAsync();
        }

        return true;
    }
}
