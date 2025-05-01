using Ecommerce_mvc.Data;
using Ecommerce_mvc.Models;

namespace Ecommerce_mvc.IRepository.Repository
{
    public class ProducersRepo : GenricRepository<Producer>, IProducersRepo
    {
        public ProducersRepo(AppDbContext context) : base(context)
        {
        }

      
    }
}
