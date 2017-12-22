﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: /Random
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Models.Customer { Name="Joe Doe"},
                new Models.Customer { Name="Freddy Porter"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var movies = new List<Movie>
            { 
                 new Movie {Name = "Shrek!" },
                 new Movie {Name = "Tanggled" }
            };
            

            return View(movies);
        }

        public ActionResult Edit(int id)
        {
            return Content("Id= " + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("pageIndex ={0}&sortBY={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year:int:min(1900)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }

}