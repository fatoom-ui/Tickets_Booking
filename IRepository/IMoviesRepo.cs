using Ecommerce_mvc.Models;
using Ecommerce_mvc.Models.ViewModel;

namespace Ecommerce_mvc.IRepository
{
    public interface IMoviesRepo:IGenricRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM movie);
    }
}
