using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WorkerController : Controller
    {
        WorkersHelper Helper = new WorkersHelper();
        public WorkerController(WorkersHelper helper)
        {
            Helper = helper;
        }

        public async Task<IActionResult> Worker()
        {
            return View(await Helper.GetAllWorkersAsync());
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await Helper.GetWorker(id);
            if (worker == null)
            {
                return NotFound();
            }
            return View(worker);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Worker worker)
        {
            if (ModelState.IsValid)
            {
                await Helper.AddWorker(worker);
                return RedirectToAction(nameof(Worker));
            }
            return View(worker);
        }

        // GET: ProductsController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await Helper.GetWorker(id);
            if (worker == null)
            {
                return NotFound();
            }
            return View(worker);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, Worker worker)
        {
            if (id != worker.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await Helper.UpdateWorker(id, worker);
                return RedirectToAction(nameof(Worker));
            }
            else
            {
                return View(worker);
            }
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await Helper.GetWorker(id);
            if (worker == null)
            {
                return NotFound();
            }
            return View(worker);
        }

        // POST: ProductsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var worker = Helper.GetWorker(id);

                if (worker == null)
                {
                    return NotFound();
                }

                await Helper.DeleteWorker(id);

                return RedirectToAction(nameof(Worker));
            }
            catch
            {
                return View();
            }
        }
    }
}
