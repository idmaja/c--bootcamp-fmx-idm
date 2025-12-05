public interface IMenuService
{
    Task<Result<IEnumerable<MenuResponse>>> GetAllMenusAsync();
    Task<Result<MenuResponse>> GetMenuByIdAsync(string id);
    Task<Result<MenuResponse>> CreateMenuAsync(MenuRequest request);
    Task<Result<MenuResponse>> UpdateMenuAsync(string id, MenuRequest request);
    Task<Result<bool>> DeleteMenuAsync(string id);

    Task<Result<decimal>> GetTotalStockValueAsync();
}