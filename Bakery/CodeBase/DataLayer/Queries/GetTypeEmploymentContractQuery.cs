using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Entities;
using Bakery.CodeBase.ServiceLayer;

namespace Bakery.CodeBase.DataLayer.Queries
{
    public class GetTypeEmploymentContractQuery : IQuery<TypeEmploymentContract>
    {
        private int ID;
        public GetTypeEmploymentContractQuery(int ID)
        {
            this.ID = ID;
        }
        public TypeEmploymentContract Execute()
        {
            string sqlQuery = "SELECT * FROM [TypeEmploymentContract] WHERE Id=@Id";
            TypeEmploymentContract typeEmploymentContract = new TypeEmploymentContract();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                sqlComm.Parameters.Add("@" + TypeEmploymentContract.IdDatabaseColumnName, SqlDbType.Int).Value = ID;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        typeEmploymentContract = MainService.GetSingleTypeEmploymentContract(r);
                    }
                }
            }
            return typeEmploymentContract;
        }
    }
}
