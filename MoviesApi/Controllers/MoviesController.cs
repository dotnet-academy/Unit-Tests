using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService movieService_;

        public MoviesController(IMovieService movieService)
        {
            movieService_ = movieService;
        }

        // GET api/movies
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var movies = await movieService_.GetAllAsync();

            return Ok(movies);
        }

        // GET api/movies/1?code=12abc
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id, string code)
        {
            var movie = await movieService_.GetAsync(id, code);

            if (movie == null) {
                return NotFound(movie);
            }

            return Ok(movie);
        }
    }
}
