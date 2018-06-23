using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Domain.Context;
using Domain.Interfaces;
using Domain.Models;


namespace Domain.Services
{
    public class MovieService : IMovieService
    {
        private readonly MoviesContext context_;
        private readonly IPricingService pricing_;

        public MovieService(MoviesContext context, IPricingService pricing)
        {
            context_ = context;
            pricing_ = pricing;
        }

        public async Task<bool> AddAsync(Movie movie)
        {
            if (movie == null) {
                return false;
            }

            context_.Add(movie);

            await context_.SaveChangesAsync();

            return true;
        }

        public async Task<IList<Movie>> GetAllAsync()
        {
            var movies = await context_.Movie.ToListAsync();

            return movies;
        }

        public async Task<Movie> GetAsync(int id, string code = null)
        {
            var movie = await context_.Movie
                .SingleOrDefaultAsync(m => m.MovieId == id);

            if (movie == null) {
                return null;
            }

            var discount = pricing_.DiscountPercentage(code);

            movie.Price -= movie.Price * (discount / 100);

            return movie;
        }
    }
}
