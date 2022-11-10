using INCREDIBLE_TECH__LTD_.Models;

namespace INCREDIBLE_TECH__LTD_.Data.Services
{
    public interface IOrdersService
    {

        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
