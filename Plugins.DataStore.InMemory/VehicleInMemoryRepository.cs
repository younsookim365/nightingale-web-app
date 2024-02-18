/* Group:      8
   References: Liu, F (2021) Full C# Project: Supermarket Management System | ASP.NET Core Blazor, EF Core, SQL Server, Identity source code (Version 16) [Source code]. https://www.youtube.com/watch?v=DWrH7br4DsM&t=140s

 */

using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class VehicleInMemoryRepository : IVehicleRepository
    {
        private List<Vehicle> vehicles;

        public VehicleInMemoryRepository()
        {
            // Default Vehicles
            vehicles = new List<Vehicle>()
            {
                new Vehicle { VehicleId = 1, Type = "JAC 2019", NumberPlate = "CAA 183761"},
                new Vehicle { VehicleId = 2, Type = "KIA", NumberPlate = "CAA 89312"},
                new Vehicle { VehicleId = 3, Type = "NISSAN / 7 Seater ", NumberPlate = "CAA 268430"}
            };

        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicles.Any(x => x.Type.Equals(vehicle.Type, StringComparison.OrdinalIgnoreCase))) return;

            if (vehicles != null && vehicles.Count > 0)
            {
                var maxId = vehicles.Max(x => x.VehicleId);
                vehicle.VehicleId = maxId + 1;
            }
            else
            {
                vehicle.VehicleId = 1;
            }


            vehicles.Add(vehicle);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            var vehicleToUpdate = GetVehicleById(vehicle.VehicleId);
            if (vehicleToUpdate != null)
            {
                vehicleToUpdate.Type = vehicle.Type;
                vehicleToUpdate.NumberPlate = vehicle.NumberPlate;
            }
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return vehicles;
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return vehicles?.FirstOrDefault(x => x.VehicleId == vehicleId);
        }

        public void DeleteVehicle(int vehicleId)
        {
            vehicles?.Remove(GetVehicleById(vehicleId));
        }
    }
}
