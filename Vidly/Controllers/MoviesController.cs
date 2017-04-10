using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //by convention make a private instance of ApplicationDbContext in the controller
        private ApplicationDbContext _context;
        
        //make a constructor that calls a new instance of _context
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //need to override the base class Dispose method
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //mvcaction4 code snippet to make default action result
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        //mvcaction4 code snippet to create this ActionResult
        //need to add System.Data.Entity at top and use Include to eager load Genre
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            //return http error if no movie is found
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

//        //old method that would return hard coded movies. Used before adding the database and calling _context
//        private IEnumerable<Movie> GetMovies()
//        {
//            return new List<Movie>
//            {
//                new Movie {Id = 1, Name = "Rambo" },
//                new Movie {Id = 2, Name = "Predator" }
//            };
//
//        }

        // GET: Movies/Random will return Shrek!
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            return View(movie);
        }
    }
}