using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission5.Models;

namespace Mission5.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext movie { get; set; }

        public HomeController(MovieContext someName)
        {
            movie = someName;
        }

        // Display Index page as showing DB's movie data along with categories  
        public IActionResult Index()
        {
            var movieList = movie.Responses
                .Include(x => x.Category)
                .ToList();
            return View(movieList);
        }

        // Display Podcast page
        public IActionResult Podcast()
        {
            return View();
        }

        // When adding a new movie, get categories through ViewBag
        // Viewbag helps bring data from another model when there is already a model used in the cshtml
        [HttpGet]
        public IActionResult NewMovie()
        {
            ViewBag.Categories = movie.Categories.ToList();
            return View();
        }

        // Submit a new movie to DB
        [HttpPost]
        public IActionResult NewMovie(ApplicationResponse ar)
        {
            // Set this variable as true to indicate that I am on this page to add data.
            ViewBag.New = true;

            // Model validating
            if (ModelState.IsValid)
            {
                // When there is the same title in the movie database, block adding a new item
                if (movie.Responses.Any(a => a.Title.Equals(ar.Title)))
                {
                    return View("Failure", ar);
                }
                // if not, go ahead and add the data
                movie.Add(ar);
                movie.SaveChanges();
                return View("Confirmation", ar);
            }

            ViewBag.Categories = movie.Categories.ToList();
            return View();
        }

        // Edit a moive (GET)
        [HttpGet]
        public IActionResult Edit(int recordId)
        {
            // set this variable as false to indicate I am on Editing
            ViewBag.New = false;
            // get data from category model to display them on a cshtml
            ViewBag.Categories = movie.Categories.ToList();

            // find a specific movie by its id
            var application = movie.Responses.Single(x => x.MovieId == recordId);
            return View("NewMovie", application);
        }

        // Edit a moive (POST)
        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        {
            // model validation
            if (ModelState.IsValid)
            {
                // edit a specific model
                movie.Update(ar);
                movie.SaveChanges();

                // show them in the index page
                return RedirectToAction("Index");
            }
            // if the model is not validated, get data from category model and show NewMoive cshtml
            ViewBag.Categories = movie.Categories.ToList();
            return View("NewMovie", ar);
        }

        // Delete
        public IActionResult Delete(int recordId)
        {
            // find a movie from DB by its id
            var record = movie.Responses.Single(x => x.MovieId == recordId);
            movie.Responses.Remove(record);
            movie.SaveChanges();

            var movieList = movie.Responses
                .Include(x => x.Category)
                .ToList();

            return RedirectToAction("Index", movieList);
        }
    }
}