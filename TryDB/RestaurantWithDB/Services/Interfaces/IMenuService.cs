public interface IMenuService
{
    Task<ResultReponse<IEnumerable<Menu>>> GetAllMenusAsync();
    Task<ResultReponse<Menu?>> GetMenuByIdAsync(string id);
    Task<ResultReponse<Menu>> CreateMenuAsync(MenuRequest request);
    Task<ResultReponse<Menu?>> UpdateMenuAsync(string id, MenuRequest request);
    Task<ResultReponse<bool>> DeleteMenuAsync(string id);

    Task<ResultReponse<decimal>> GetTotalStockValueAsync();
}