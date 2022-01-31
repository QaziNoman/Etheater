using Etheater.Data;
using Etheater.Data.Services;
using Etheater.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaServices _Context;
        public CinemaController(ICinemaServices context)
        {
            _Context = context;
  
        }
        public async Task<IActionResult> Index()
        {
            var AllCinema = await _Context.GetAllAsync();

            return View(AllCinema);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("logo,Name,Name")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);


            }
            await _Context.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var CinemaDetails= await _Context.GetByIdAsync(id);
            
            if (CinemaDetails == null) return View("NotFound");
            return View(CinemaDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CinemaDetails = await _Context.GetByIdAsync(id);
            if (CinemaDetails == null) return View("NotFound");

            await _Context.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Details(int id)
        {

            var CinemaDetailID = await _Context.GetByIdAsync(id);
            if (CinemaDetailID == null)
            {
                return View("NotFound");
            }
            else
                return View(CinemaDetailID);
        }


        /*  [HttpPost]
          public async Task<IActionResult> Edit(int id, [Bind("logo,Name,Descrition")] Cinema cinema)
          {

              if (!ModelState.IsValid)
              {
                  return View(cinema);


              }
              await _Context.UpdateAsync(id, cinema);
              return RedirectToAction(nameof(Index));
          }



          public async Task<IActionResult> Edit(int id)
          {

              var CinemaDetailID = await _Context.GetByIdAsync(id);
              if (CinemaDetailID == null)
              {
                  return View("NotFound");
              }
              else
                  return View(CinemaDetailID);
          }*/

        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _Context.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,logo,Name,Name")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await _Context.UpdateAsync( cinema);
            return RedirectToAction(nameof(Index));
        }








    }
}
