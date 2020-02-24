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
    public class InsertStoveCommand : ICommand
    {
        private Stove stove;
        public InsertStoveCommand(Stove stove)
        {
            this.stove = stove;
        }
        public void Execute()
        {
            string sqlQuery = "INSERT INTO [Stoves] (Type, Description) VALUES (@Type, @Description)";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;

                sqlComm.Parameters.Add("@" + Stove.TypeDatabaseColumnName, SqlDbType.NVarChar).Value = stove.Type;
                sqlComm.Parameters.Add("@" + Stove.DescriptionDatabaseColumnName, SqlDbType.NVarChar).Value = stove.Description;

                sqlComm.ExecuteNonQuery();
            }
        }
    }
}
