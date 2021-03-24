using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JoelHiltonsMovieCollectionEdit.Models;
using Microsoft.EntityFrameworkCore;

namespace JoelHiltonsMovieCollectionEdit.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;

        private MovieDBContext context { get; set; }

        public HomeController(MovieDBContext cxt)
        {
            context = cxt;
        }

        // Action for Index page
        public IActionResult Index()
        {
            return View();
        }

        // Action for MyPodcasts page
        public IActionResult MyPodcasts()
        {
            return View();
        }

        // Get action for MovieForm page
        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        // Post action for MovieForm page
        [HttpPost]
        public IActionResult MovieForm(Movies movie)
        {
            //Add movie to database and saves changes
            context.Movies.Add(movie);
            context.SaveChanges();
            return View("Confirmation", movie);
        }

        // Get action for Edit page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Brings in data from movie selected to edit
            var movie = context.Movies.Where(s => s.MovieID == id).FirstOrDefault();
            return View(movie);
        }

        // Post action for Edit page
        [HttpPost]
        public IActionResult Edit(Movies movie)
        {
            //Finds movie object in database
            var mov = context.Movies.Where(s => s.MovieID == movie.MovieID).FirstOrDefault();
            context.Movies.Remove(mov); //Removes original object from database
            context.Movies.Add(movie); //Adds new object in-place of old object
            context.SaveChanges();

            return RedirectToAction("MovieList", context.Movies);
        }

        // Action for Delete
        public IActionResult Delete(int id)
        {
            //Finds movie object in database
            var movie = context.Movies.Where(s => s.MovieID == id).FirstOrDefault();
            string confirm = "You deleted " + movie.Title;
            ViewBag.ConfirmDelete = confirm;
            context.Movies.Remove(movie);
            context.SaveChanges();
            return View("MovieList", context.Movies);
        }

        
        public IActionResult MovieList()
        {
            return View(context.Movies);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
