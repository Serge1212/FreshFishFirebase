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
    public class VehiclesHelper
    {

        //отримання всіх даних працівників з серверу
        public async Task<List<Vehicles>> GetAllVehiclesAsync()
        {
            return (await Globals.Client
                .Child("vehicles")
                .OnceAsync<Vehicles>()).Select(item => new Vehicles
                {
                    Id = item.Object.Id,
                    Model = item.Object.Model,
                    Mark = item.Object.Mark,
                    ManufactureDate = item.Object.ManufactureDate,
                    Mileage = item.Object.Mileage,
                    FuelConsumption = item.Object.FuelConsumption
                }).ToList();
        }

        //додавання нового працівника
        public async Task AddVehicles(Vehicles vehicles)
        {

            await Globals.Client
                .Child("vehicles/")
                .PostAsync(new Vehicles()
                {
                    Id = GetRandomId(),
                    Model = vehicles.Model,
                    Mark = vehicles.Mark,
                    ManufactureDate = vehicles.ManufactureDate,
                    Mileage = vehicles.Mileage,
                    FuelConsumption = vehicles.FuelConsumption
                });
        }

        //отримання конкретного працівника за айді
        public async Task<Vehicles> GetVehicle(string id)
        {
            var allVehicles = await GetAllVehiclesAsync();
            await Globals.Client
                .Child("vehicles")
                .OnceAsync<Vehicles>();

            return allVehicles.Where(w => w.Id == id).FirstOrDefault();
        }


        public async Task UpdateVehicle(string id, Vehicles vehicles)
        {
            var toUpdateVehicle = (await Globals.Client
               .Child("vehicles")
               .OnceAsync<Vehicles>()).Where(a => a.Object.Id == id).FirstOrDefault();

            await Globals.Client
                .Child("vehicles")
                .Child(toUpdateVehicle.Key)
                .PutAsync(vehicles);
        }

        public async Task DeleteVehicle(string id)
        {
            var toDeleteVehicle = (await Globals.Client
                .Child("vehicles")
                .OnceAsync<Vehicles>()).Where(v => v.Object.Id == id).FirstOrDefault();
            await Globals.Client.Child("vehicles").Child(toDeleteVehicle.Key).DeleteAsync();
        }



        #region Random ID FOR VEHICLES
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
                "v";

        }
        #endregion
    }
}