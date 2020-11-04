using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        static ObservableCollection<Products> ProductsCollection = new ObservableCollection<Products>();
        ProductsHelper Helper = new ProductsHelper();
        public ProductController(ProductsHelper helper)
        {
            Helper = helper;
        }

        [HttpGet]
        public async Task<IActionResult> Product(string search)
        {
            ViewData["GetProductsDetails"] = search;
            var products = await Helper.GetAllProductsAsync();
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.ProductName.Contains(search)).ToList();
            }

            return View(products);
        }

        public async Task<IActionResult> Product()
        {
            return View(await Helper.GetAllProductsAsync());
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await Helper.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Products product)
        {
            if (ModelState.IsValid)
            {
                await Helper.AddProduct(product);
                return RedirectToAction(nameof(Product));
            }
            return View(product);
        }

        // GET: ProductsController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await Helper.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, Products product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await Helper.UpdateProduct(id, product);
                return RedirectToAction(nameof(Product));
            }
            else
            {
                return View(product);
            }
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await Helper.GetProduct(id);
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
                var product = Helper.GetProduct(id);

                if (product == null)
                {
                    return NotFound();
                }

                await Helper.DeleteProduct(id);

                return RedirectToAction(nameof(Product));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
