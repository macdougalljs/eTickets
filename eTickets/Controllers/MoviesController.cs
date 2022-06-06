using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
       // private readonly AppDbContext _context;
       private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);   // this will be the property that's included
          
            return View(allMovies);
        }

        //GET: Movies/Details/1

        public async Task<IActionResult> Details(int id)
        {
        var movieDetail = await _service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }

    }
}
