using Etheater.Data;
using Etheater.Data.Services;
using Etheater.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etheater.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorServices Services;

        public ActorsController(IActorServices _Services)
        {
            Services = _Services;
        }

        public async Task <IActionResult> Index()
        {
            var data =await Services.GetAllAsync();
            return View(data);
        }






        //UPDATE FUNCT
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureUrl,Bio")] Actor actor)
        {

            if (!ModelState.IsValid)
            {
                return View(actor);


            }
            await Services.UpdateAsync(   actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {

            var ActorDetailID = await Services.GetByIdAsync(id);
            if (ActorDetailID == null)
            {
                return View("NotFound");
            }
            else
                return View(ActorDetailID);
                }




        //Create FUNC
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create([Bind("FullName,ProfilePictureUrl,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
                

            }
           await Services.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }




        //Delete Fun

       

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await Services.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await Services.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await Services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }













        //Showing Detail
        public async Task<IActionResult> Detail(int id)
        {
            
         var ActorDetailID= await Services.GetByIdAsync(id);
            if (ActorDetailID == null)
            {
                return View("NotFound");
            }
            else
            return View(ActorDetailID);
        }
    }
}
