using Ecommerce_mvc.Data;
using Ecommerce_mvc.Models;
using Ecommerce_mvc.Models.ViewModel;
using Ecommerce_mvc.Models.Enums;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce_mvc.IRepository.Repository
{
    public class MoviesRepo : GenricRepository<Movie>, IMoviesRepo
    {
        public MoviesRepo(AppDbContext context) : base(context)
        {
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newmovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                ImageURL = data.ImageURL,
                CinemaId = data.CinemaId,
                ProducerId = data.ProducerId,
                MovieCategory = data.MovieCategory



            };
            await _context.Movies.AddAsync(newmovie);
            await _context.SaveChangesAsync();
        }

        public async Task<NewMovieDropdownVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas=await _context.Cinemas.OrderBy(n=>n.Name).ToListAsync(),
                Producers=await _context.Producers.OrderBy(n=>n.FullName).ToListAsync()

            };
            return response;


        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var MovieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actor_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);
            return MovieDetails;


        }

        public async Task UpdateNewMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == data.Id);
            if(dbMovie !=null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.ProducerId = data.ProducerId;
                dbMovie.MovieCategory = data.MovieCategory;
                await _context.SaveChangesAsync();
            }
          
            var existingdbMovie =await  _context.Actor_Movies.Where(x => x.MovieId == data.Id).ToListAsync();
            _context.Actor_Movies.RemoveRange(existingdbMovie);
            await _context.SaveChangesAsync();
            foreach (var actorId in data.ActorsId)
            {
                var newActorMovie = new Actor_Movie()
                {
                    ActorId = data.Id,
                    MovieId = actorId
                };
                await _context.Actor_Movies.AddAsync(newActorMovie);
            }
                await _context.SaveChangesAsync();
            


        }

        public Task UpdateMovieAsync(NewMovieVM movie)
        {
            throw new NotImplementedException();
        }
    }
}
