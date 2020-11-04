using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class ProductsHelper
    {
        double sum;
        public async Task<List<Products>> GetAllProductsAsync()
        {
            return (await Globals.Client
                .Child("products")
                .OnceAsync<Products>()).Select(item => new Products
                {
                    Id = item.Object.Id,
                    ProductName = item.Object.ProductName,
                    Price = item.Object.Price,
                    Date = item.Object.Date,
                    Status = item.Object.Status,            
                }).ToList();
        }

        public async Task<Products> GetProduct(string ID)
        {
            var allProducts = await GetAllProductsAsync();
            await Globals.Client
                .Child("products/")
                .OnceAsync<Products>();

            return allProducts.Where(p => p.Id == ID).FirstOrDefault();
        }

        public async Task<double> GetPricesSumAsync()
        {
            var productsList = await GetAllProductsAsync();

            var prices = from p in productsList
                         where p.Status == "Yes"
                         select p.Price;

            sum = prices.Sum(v => Convert.ToDouble(v));

            return sum;
        }

        public async Task AddProduct(Products product)
        {
            await Globals.Client
                .Child("products")
                .PostAsync(new Products()
                {
                    Id = GetRandomId(),
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Date = product.Date,
                    Status = product.Status,
                });
        }

        public async Task UpdateProduct(string id, Products product)
        {
            var toUpdateProduct = (await Globals.Client
                .Child("products")
                .OnceAsync<Products>()).Where(a => a.Object.Id == id).FirstOrDefault();

            await Globals.Client
                .Child("products")
                .Child(toUpdateProduct.Key)
                .PutAsync(product);
        }
        public async Task DeleteProduct(string ID)
        {
            var toDeleteProduct = (await Globals.Client
                .Child("freshfish")
                .OnceAsync<Products>()).Where(a => a.Object.Id == ID).FirstOrDefault();
            await Globals.Client.Child("products").Child(toDeleteProduct.Key).DeleteAsync();
        }
        #region Random ID FOR PRODUCTS
        string GetRandomId()
        {
            Random rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string x = new string(Enumerable.Repeat(chars, 4)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
            const string nums = "123456789";
            string y = new string(Enumerable.Repeat(nums, 4)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());

            string sDate = DateTime.Now.ToString();
            DateTime value = (Convert.ToDateTime(sDate.ToString()));

            return x + y +
                value.Day.ToString() +
                value.Month.ToString() +
                value.Year.ToString() +
                value.Minute.ToString() +
                value.Hour.ToString() +
                value.Second.ToString() +
                "P";
        }
        #endregion
    }
}

