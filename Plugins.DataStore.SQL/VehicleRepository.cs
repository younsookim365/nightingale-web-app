/* Group:      8
   References: Liu, F (2021) Full C# Project: Supermarket Management System | ASP.NET Core Blazor, EF Core, SQL Server, Identity source code (Version 16) [Source code]. https://www.youtube.com/watch?v=DWrH7br4DsM&t=140s

 */

using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly MarketContext db;

        public VehicleRepository(MarketContext db)
        {
            this.db = db;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            db.Vehicles.Add(vehicle);
            db.SaveChanges();
        }

        public void DeleteVehicle(int vehicleId)
        {
            var vehicle = db.Vehicles.Find(vehicleId);
            if (vehicle == null) return;

            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return db.Vehicles.ToList();
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return db.Vehicles.Find(vehicleId);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            var cat = db.Vehicles.Find(vehicle.VehicleId);
            cat.Type = vehicle.Type;
            cat.NumberPlate = vehicle.NumberPlate;
            db.SaveChanges();
        }
    }
}
