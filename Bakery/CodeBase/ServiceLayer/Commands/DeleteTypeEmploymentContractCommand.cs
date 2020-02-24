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
    public class DeleteTypeEmploymentContractCommand : ICommand
    {
        private int Id;
        public DeleteTypeEmploymentContractCommand(int Id)
        {
            this.Id = Id;
        }
        public void Execute()
        {
            string sqlQuery = "DELETE FROM [TypeEmploymentContracts] WHERE Id=@Id";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                sqlComm.Parameters.Add("@" + TypeEmploymentContract.IdDatabaseColumnName, SqlDbType.TinyInt).Value = Id;
                sqlComm.ExecuteNonQuery();
            }
        }
    }
}
