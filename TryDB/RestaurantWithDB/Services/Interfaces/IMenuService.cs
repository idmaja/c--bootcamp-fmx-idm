public interface IMenuService
{
    Task<Result<IEnumerable<MenuResponse>>> GetAllMenusAsync();
    Task<Result<MenuResponse>> GetMenuByIdAsync(string id);
    Task<Result<MenuResponse>> CreateMenuAsync(CreateMenuRequest request);
    Task<Result<MenuResponse>> UpdateMenuAsync(string id, UpdateMenuRequest request);
    Task<Result<MenuResponse>> DeleteMenuAsync(string id);

    Task<Result<decimal>> GetTotalStockValueAsync();
}