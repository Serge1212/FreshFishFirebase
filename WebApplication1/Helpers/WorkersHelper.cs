using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class WorkersHelper
    {

        //отримання всіх даних працівників з серверу
        public async Task<List<Worker>> GetAllWorkersAsync()
        {
            return (await Globals.Client
                .Child("workers")
                .OnceAsync<Worker>()).Select(item => new Worker
                {
                    Id = item.Object.Id,
                    Name = item.Object.Name,
                    Surname = item.Object.Surname,
                    Patronymic = item.Object.Patronymic,
                    Position = item.Object.Position,
                    Salary = item.Object.Salary,
                    PhoneNumber = item.Object.PhoneNumber,
                    Address = item.Object.Address,
                    AdditionInfo = item.Object.AdditionInfo
                }).ToList();
        }

        //додавання нового працівника
        public async Task AddWorker(Worker worker)
        {

            await Globals.Client
                .Child("workers/")
                .PostAsync(new Worker()
                {
                    Id = GetRandomId(),//отримуємо нове згенероване айді
                    Name = worker.Name,
                    Surname = worker.Surname,
                    Patronymic = worker.Patronymic,
                    Position = worker.Position,
                    Salary = worker.Salary,
                    PhoneNumber = worker.PhoneNumber,
                    Address = worker.Address,
                    AdditionInfo = worker.AdditionInfo
                });
        }

        //отримання конкретного працівника за айді
        public async Task<Worker> GetWorker(string ID)
        {
            var allWorkers = await GetAllWorkersAsync();
            await Globals.Client
                .Child("workers")
                .OnceAsync<Worker>();

            return allWorkers.Where(w => w.Id == ID).FirstOrDefault();
        }

        //оновлення даних конкретного працівника
        public async Task UpdateWorker(string id, Worker worker)
        {
            var toUpdateProduct = (await Globals.Client
               .Child("workers")
               .OnceAsync<Worker>()).Where(a => a.Object.Id == id).FirstOrDefault();

            await Globals.Client
                .Child("workers")
                .Child(toUpdateProduct.Key)
                .PutAsync(worker);
        }
        //видалення конкретного працівника за айді
        public async Task DeleteWorker(string ID)
        {
            var toDeleteWorker = (await Globals.Client
                .Child("workers")
                .OnceAsync<Worker>()).Where(w => w.Object.Id == ID).FirstOrDefault();
            await Globals.Client.Child("workers").Child(toDeleteWorker.Key).DeleteAsync();
        }


        //генерування нового айді
        #region Random ID FOR WORKERS
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
                "w";

        }
        #endregion
    }
}
