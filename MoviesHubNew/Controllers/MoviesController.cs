using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MoviesHubNew.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService_;

        public MoviesController(IMovieService movieService)
        {
            movieService_ = movieService;
        }

        // GET:
        public async Task<IActionResult> Index()
        {
            var movies = await movieService_.GetAllAsync();

            return View(movies);
        }

        // GET: Movies/Details/5?code=
        public async Task<IActionResult> Details(int? id, string code)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await movieService_.GetAsync(id.Value, code);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
    }
}
