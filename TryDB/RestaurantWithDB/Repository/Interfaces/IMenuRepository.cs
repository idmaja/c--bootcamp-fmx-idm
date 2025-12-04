public interface IMenuRepository
{
    Task<IEnumerable<Menu>> GetAllAsync();
    Task<Menu?> GetByIdAsync(Guid id);
    Task<Menu> AddAsync(Menu menu);
    Task<Menu?> UpdateAsync(Guid id, Menu menu);
    Task<bool> DeleteAsync(Guid id);
}