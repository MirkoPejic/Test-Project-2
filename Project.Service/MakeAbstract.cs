using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Project.DAL;


namespace Project.Service
{
    public abstract class MakeAbstract : IMaker
    {
        
        public abstract List<VehicleMake> GetAllMaker();
        public abstract void AddVehicleMake(VehicleMake vehicleMake);
        
    }
}
