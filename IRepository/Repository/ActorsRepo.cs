using Ecommerce_mvc.Data;
using Ecommerce_mvc.Models;

namespace Ecommerce_mvc.IRepository.Repository
{
    public class ActorsRepo : GenricRepository<Actor>, IActorsRepo
    {
        //private readonly AppDbContext _context;
        public ActorsRepo(AppDbContext context) : base(context)
        {
            //_context = context;
        }

        public Task UpdateAsync(int id, Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
