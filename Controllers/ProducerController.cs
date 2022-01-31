using Etheater.Data;
using Etheater.Data.Services;
using Etheater.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerServices _Context;
        public ProducerController( IProducerServices context)
        {
            _Context = context;
        }
        public async Task<IActionResult> Index()
        {
            var AllProducer = await _Context.GetAllAsync();

            return View(AllProducer);
        }
         public async Task<IActionResult> Details(int Id)
        {
            var ProducerDetail = await _Context.GetByIdAsync(Id);
            if (ProducerDetail == null)
            {
                return View("NotFound");
            }
            return View(ProducerDetail);
        }


        //Add New Controller
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);


            }
            await _Context.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }




        //Update Producer
        //UPDATE FUNCT
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureUrl,Bio")] Producer producer)
        {

            if (!ModelState.IsValid)
            {
                return View(producer);


            }
            await _Context.UpdateAsync( producer);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {

            var ProducerDetailID = await _Context.GetByIdAsync(id);
            if (ProducerDetailID == null)
            {
                return View("NotFound");
            }
            else
                return View(ProducerDetailID);
        }







        //Delete Producer
        public async Task<IActionResult> Delete(int id)
        {
            var ProducerDetails = await _Context.GetByIdAsync(id);
            if (ProducerDetails == null) return View("NotFound");
            return View(ProducerDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _Context.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _Context.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
