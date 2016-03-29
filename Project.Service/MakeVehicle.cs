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
    public class MakeVehicle : MakeAbstract
    {
        private VehiclesDBEntities db = new VehiclesDBEntities();

        public IQueryable<VehicleMake> SortOrder(string sortOrder)
        {
            var vehicleMakes = from vMakers in db.VehicleMakes
                               select vMakers;
            switch (sortOrder)
            {
                case "name_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(v => v.VehicleName);
                    break;
                case "abbreviation":
                    vehicleMakes = vehicleMakes.OrderBy(v => v.VehicleAbbreviation);
                    break;
                case "abbreviation_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(v => v.VehicleAbbreviation);
                    break;
                default:
                    vehicleMakes = vehicleMakes.OrderBy(v => v.VehicleName);
                    break;
            }

            return vehicleMakes;
        }
    }
}
