using Ecommerce_mvc.Data;
using Ecommerce_mvc.Models;

namespace Ecommerce_mvc.IRepository.Repository
{
    public class CinemasRepo : GenricRepository<Cinema>, ICinemasRepo
    {
        public CinemasRepo(AppDbContext context) : base(context)
        {
        }

        public void Update(Cinema cinema)
        {
            throw new NotImplementedException();
        }
    }
}
