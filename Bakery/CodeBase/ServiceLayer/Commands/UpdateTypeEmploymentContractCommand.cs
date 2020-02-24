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
    public class UpdateTypeEmploymentContractCommand : ICommand
    {
        private TypeEmploymentContract typeEmploymentContract;
        public UpdateTypeEmploymentContractCommand(TypeEmploymentContract typeEmploymentContract)
        {
            this.typeEmploymentContract = typeEmploymentContract;
        }
        public void Execute()
        {
            string sqlQuery = "UPDATE [TypeEmploymentContracts] SET Name = @Name WHERE Id = @Id";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                sqlComm.Parameters.Add("@" + TypeEmploymentContract.IdDatabaseColumnName, SqlDbType.Int).Value = typeEmploymentContract.Id;
                sqlComm.Parameters.Add("@" + TypeEmploymentContract.NameDatabaseColumnName, SqlDbType.NVarChar).Value = typeEmploymentContract.Name;
                sqlComm.ExecuteNonQuery();
            }
        }
    }
}
