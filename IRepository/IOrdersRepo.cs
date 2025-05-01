using Ecommerce_mvc.Models;

namespace Ecommerce_mvc.IRepository
{
    public interface IOrdersRepo
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRple);
    }
}
