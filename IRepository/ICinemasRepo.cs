using Ecommerce_mvc.Models;

namespace Ecommerce_mvc.IRepository
{
    public interface ICinemasRepo : IGenricRepository<Cinema>
    {
        void Update(Cinema cinema);
    }
}
