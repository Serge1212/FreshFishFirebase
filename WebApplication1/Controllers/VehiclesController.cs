using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VehiclesController : Controller
    {
        VehiclesHelper Helper = new VehiclesHelper();
        public VehiclesController(VehiclesHelper helper)
        {
            Helper = helper;
        }

        public async Task<IActionResult> Vehicles()
        {
            return View(await Helper.GetAllVehiclesAsync());
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await Helper.GetVehicle(id);
            if (vehicles == null)
            {
                return NotFound();
            }
            return View(vehicles);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Vehicles vehicles)
        {
            if (ModelState.IsValid)
            {
                await Helper.AddVehicles(vehicles);
                return RedirectToAction(nameof(Vehicles));
            }
            return View(vehicles);
        }

        // GET: ProductsController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await Helper.GetVehicle(id);
            if (vehicles == null)
            {
                return NotFound();
            }
            return View(vehicles);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, Vehicles vehicles)
        {
            if (id != vehicles.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await Helper.UpdateVehicle(id, vehicles);
                return RedirectToAction(nameof(Vehicles));
            }
            else
            {
                return View(vehicles);
            }
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await Helper.GetVehicle(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var product = Helper.GetVehicle(id);

                if (product == null)
                {
                    return NotFound();
                }

                await Helper.DeleteVehicle(id);

                return RedirectToAction(nameof(Vehicles));
            }
            catch
            {
                return View();
            }
        }
    }
}
