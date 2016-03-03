﻿using System;
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
        string connectionString = ConfigurationManager.ConnectionStrings["VehiclesDBEntities"].ConnectionString;
        public override List<VehicleMake> GetAllMaker()
        {
            List<VehicleMake> vehicleManufacturer = new List<VehicleMake>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllMaker", con);
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
        public override void AddVehicleMake(VehicleMake vehicleMake)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddVehicleMake", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramVehicleName = new SqlParameter();
                paramVehicleName.ParameterName = "@VehicleName";
                paramVehicleName.Value = vehicleMake.VehicleName;
                cmd.Parameters.Add(paramVehicleName);

                SqlParameter paramVehicleAbbreviation = new SqlParameter();
                paramVehicleAbbreviation.ParameterName = "@VehicleAbbreviation";
                paramVehicleAbbreviation.Value = vehicleMake.VehicleAbbreviation;
                cmd.Parameters.Add(paramVehicleAbbreviation);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
