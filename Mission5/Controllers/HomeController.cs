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
        private readonly ILogger<HomeController> _logger;
        private MovieContext movie { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext someName)
        {
            _logger = logger;
            movie = someName;
        }

        public IActionResult Index()
        {
            var movieList = movie.Responses
                .Include(x => x.Category)
                .ToList();
            return View(movieList);
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            ViewBag.Categories = movie.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult NewMovie(ApplicationResponse ar)
        {
            ViewBag.New = true;
            if (ModelState.IsValid)
            {
                if (movie.Responses.Any(a => a.Title.Equals(ar.Title)))
                {
                    return View("Failure", ar);
                }
                movie.Add(ar);
                movie.SaveChanges();
                return View("Confirmation", ar);
            }
            ViewBag.Categories = movie.Categories.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int recordId)
        {
            ViewBag.New = false;
            ViewBag.Categories = movie.Categories.ToList();

            var application = movie.Responses.Single(x => x.MovieId == recordId);
            return View("NewMovie", application);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                movie.Update(ar);
                movie.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Categories = movie.Categories.ToList();
            return View("NewMovie", ar);
        }

        public IActionResult Delete(int recordId)
        {
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