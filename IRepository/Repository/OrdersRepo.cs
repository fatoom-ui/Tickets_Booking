using Ecommerce_mvc.Data;
using Ecommerce_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_mvc.IRepository.Repository
{
    public class OrdersRepo : IOrdersRepo
    {
        private readonly AppDbContext _context;
        public OrdersRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRple)
        {
            var orders =await _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Movie).Include(x => x.User).ToListAsync();
            if(userRple !="Admin")
            {
                orders =orders.Where(x => x.UserId == userId).ToList();

            }
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            foreach (var item in items)
            {
                var orderitem = new OrderItem()
                {
                    amount = item.Amount,
                    Price=item.Movie.Price,
                    MovieId=item.Movie.Id,
                    OrderId=order.Id


                };
                await _context.OrderItems.AddAsync(orderitem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
