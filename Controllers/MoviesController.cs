using Etheater.Data;
using Etheater.Data.Services;
using Etheater.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService Services;
        public MoviesController(IMovieService _Services)
        {
            Services = _Services;
        }
        public async Task<IActionResult> Index()
        {
            var AllMovies= await Services.GetAllAsync( n =>n.Cinema);

            return View(AllMovies) ;
        }
        public async Task<IActionResult>Details(int id)
        {
            var MovieDetail = await Services.GetMovieByIdAsync(id);
            return View (MovieDetail);
        }






        public async Task<IActionResult> Edit(int id)
        {

            var MovieDetail = await Services.NewMovieDropDownValue();
            var MovieData = await Services.GetMovieByIdAsync(id);

            if (MovieData == null)
            {
                return View("NotFound");
            }
            var response = new NewMovieVM()
            {
                Id = MovieData.Id,
                Name = MovieData.Name,
                Discription = MovieData.Description,
                StartDate=MovieData.StartDate,
                EndDate=MovieData.EndDate,
                Price = MovieData.Price,
                ImageUrl = MovieData.ImageUrl,
                MovieCategories = MovieData.MovieCategories,
                CinemaId = MovieData.CinemaId,
                ProducerId = MovieData.ProducerId,
                ActorIds = MovieData.Actor_Movies.Select(n => n.ActorId).ToList()
            };
            ViewBag.Cinemas = new SelectList(MovieDetail.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(MovieDetail.Producers, "Id", "Bio");
            ViewBag.Actors = new SelectList(MovieDetail.Actors, "Id", "FullName");
            return View(response);
        }

      public  async Task<ViewResult> FilterSearch(String searchString) {

            var AllMovie = await Services.GetAllAsync(n => n.Cinema);
            if (!String.IsNullOrEmpty(searchString))
            {
                var FilterResult = AllMovie.Where(n => n.Name.Contains(searchString) ).ToList();
                return View("Index", FilterResult);
            }
            return View("Index",AllMovie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewMovieVM movie)
        {

            if (id!= movie.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                var MovieData = await Services.NewMovieDropDownValue();
                ViewBag.Cinemas = new SelectList(MovieData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(MovieData.Producers, "Id", "Bio");
                ViewBag.Actors = new SelectList(MovieData.Actors, "Id", "FullName");
                return View(movie);
            }
            await Services.UpdateAsync(movie);
            return RedirectToAction(nameof(Index));
        }



























        public async Task<IActionResult> Create()
        {
            var MovieData = await Services.NewMovieDropDownValue();
            ViewBag.Cinemas = new SelectList(MovieData.Cinemas,"Id","Name");
            ViewBag.Producers = new SelectList(MovieData.Producers,"Id","Bio");
            ViewBag.Actors = new SelectList(MovieData.Actors,"Id","FullName");
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var MovieData = await Services.NewMovieDropDownValue();
                ViewBag.Cinemas = new SelectList(MovieData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(MovieData.Producers, "Id", "Bio");
                ViewBag.Actors = new SelectList(MovieData.Actors, "Id", "FullName");
                return View(movie);
            }
            await Services.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
