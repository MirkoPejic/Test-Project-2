using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Project.DAL;

namespace Project.Service
{
    public class Maker
    {
        public IEnumerable<VehicleMake> VehicleMaker
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["VehiclesDBEntities"].ConnectionString;
                List<VehicleMake> vehicleManufacturer = new List<VehicleMake>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllVehicleMaker", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VehicleMake vehicleMake = new VehicleMake();
                        vehicleMake.Id = Convert.ToInt32(rdr["Id"]);
                        vehicleMake.VehicleName = rdr["VehicleName"].ToString();
                        vehicleMake.VehicleAbbreviation = rdr["VehicleAbbreviation"].ToString();

                        vehicleManufacturer.Add(vehicleMake);
                    }
                }
                return vehicleManufacturer;
            }
        }
    }
}