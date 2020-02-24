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
    public class DeleteStoveCommand : ICommand
    {
        private int ID;
        public DeleteStoveCommand(int ID)
        {
            this.ID = ID;
        }
        public void Execute()
        {
            string sqlQuery = "DELETE FROM [Stoves] WHERE Id=@Id";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                sqlComm.Parameters.Add("@" + Stove.IdDatabaseColumnName, SqlDbType.Int).Value = ID;
                sqlComm.ExecuteNonQuery();
            }

        }
    }
}
