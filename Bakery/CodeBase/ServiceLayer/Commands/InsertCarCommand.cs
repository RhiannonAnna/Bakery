using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Bakery.CodeBase.DataLayer;
using Bakery.Entities;

namespace Bakery.CodeBase.ServiceLayer.Commands
{
    public class InsertCarCommand : ICommand
    {
        private Car car;
        public InsertCarCommand(Car car)
        {
            this.car = car;
        }
        public void Execute()
        {
            string sqlQuery = "INSERT INTO [Cars] (Type, Description, Registration) VALUES (@Type, @Description, @Registration)";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;

                sqlComm.Parameters.Add("@" + Car.TypeDatabaseColumnName, SqlDbType.NVarChar).Value = car.Type;
                sqlComm.Parameters.Add("@" + Car.DescriptionDatabaseColumnName, SqlDbType.NVarChar).Value = car.Description;
                sqlComm.Parameters.Add("@" + Car.RegistrationDatabaseColumnName, SqlDbType.NVarChar).Value = car.Registration;
                
                sqlComm.ExecuteNonQuery();
                
            }
        }
    }
}
