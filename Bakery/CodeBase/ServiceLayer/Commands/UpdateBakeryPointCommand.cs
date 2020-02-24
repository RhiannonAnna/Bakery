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
    public class UpdateBakeryPointCommand : ICommand
    {
        private BakeryPoint bakeryPoint;
        public UpdateBakeryPointCommand(BakeryPoint bakeryPoint)
        {
            this.bakeryPoint = bakeryPoint;
        }
        public void Execute()
        {
            string sqlQuery = "UPDATE [Bakeries] SET City = @City, Description = @Description, Address = @Address WHERE Id = @Id";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                sqlComm.Parameters.Add("@" + BakeryPoint.IdDatabaseColumnName, SqlDbType.Int).Value = bakeryPoint.Id;
                sqlComm.Parameters.Add("@" + BakeryPoint.CityDatabaseColumnName, SqlDbType.NVarChar).Value = bakeryPoint.City;
                sqlComm.Parameters.Add("@" + BakeryPoint.DescriptionDatabaseColumnName, SqlDbType.NVarChar).Value = bakeryPoint.Description;
                sqlComm.Parameters.Add("@" + BakeryPoint.AddressDatabaseColumnName, SqlDbType.NVarChar).Value = bakeryPoint.Address;
                sqlComm.ExecuteNonQuery();
            }
        }
    }
}
