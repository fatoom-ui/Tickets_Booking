using Ecommerce_mvc.Models;

namespace Ecommerce_mvc.IRepository
{
    public interface IActorsRepo : IGenricRepository<Actor>
    {
        Task UpdateAsync(int id, Actor actor);
        //IEnumerable<Actor> GetAll();
        //Actor GetById(int id);
        //void Add(Actor actor);
        //Actor Update(int id, Actor newActor);
        //void Delete(int id);

    }
}
