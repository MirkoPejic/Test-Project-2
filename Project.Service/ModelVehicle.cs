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
    public class ModelVehicle : ModelAbstract
    {
        string connectionString = ConfigurationManager.ConnectionStrings["VehiclesDBEntities"].ConnectionString;
        public override List<VehicleModel> GetAllModels()
        {
            List<VehicleModel> vehicleModels = new List<VehicleModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllModels", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    VehicleModel vehicleModel = new VehicleModel();
                    vehicleModel.Id = Convert.ToInt32(rdr["Id"]);
                    vehicleModel.MakeId = Convert.ToInt32(rdr["MakeId"]);
                    vehicleModel.ModelName = rdr["ModelName"].ToString();
                    vehicleModel.ModelAbbreviation = rdr["ModelAbbreviation"].ToString();


                    vehicleModels.Add(vehicleModel);
                }
            }
            return vehicleModels;
        }
    }
}
