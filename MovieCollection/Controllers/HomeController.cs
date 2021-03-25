using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using Microsoft.EntityFrameworkCore;
using MovieCollection.Models.ViewModels;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private MovieDbContext _context { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MovieDbContext ctx)
        {
            _logger = logger;
            _context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Display MyPodcasts View
        public IActionResult MyPodcasts()
        {
            return View("MyPodcasts");
        }

        // Display MovieList View
        public IActionResult MovieList()
        {
            return View(new MovieListViewModel{
                Movies = _context.Movies
            });
        }

        // Display Movie Form
        [HttpGet]
        public IActionResult MovieSubmit()
        {
            return View();
        }

        // Add a movie to the database
        [HttpPost]
        public IActionResult MovieSubmit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return View("Confirmation", movie);
            }
            return View();
        }

        // Display EditMovie view with MovieId as the parameter
        [HttpGet]
        public IActionResult EditMovie(int MovieId)
        {
            return View("EditMovie", _context.Movies.Find(MovieId));
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(movie).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return View("MovieList", new MovieListViewModel
            {
                Movies = _context.Movies
            });
        }

        // Delete movie according to the Movie Id
        [HttpPost]
        public IActionResult DeleteMovie(int MovieId)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Remove(_context.Movies.Find(MovieId));
                _context.SaveChanges();
            }
            return View("MovieList", new MovieListViewModel
            {
                Movies = _context.Movies
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
