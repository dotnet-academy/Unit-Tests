using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Models;

namespace Domain.Interfaces
{
    public interface IMovieService
    {
        Task<IList<Movie>> GetAllAsync();

        Task<Movie> GetAsync(int id, string code = null);

        Task<bool> AddAsync(Movie movie);
    }
}
