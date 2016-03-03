using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL;

namespace Project.Service
{
    interface IMaker
    {
        // Take all vehicle maker
        List<VehicleMake> GetAllMaker();
        // Add the vehicle manufacturer
        void AddVehicleMake(VehicleMake vehicleMake);
    }
}
