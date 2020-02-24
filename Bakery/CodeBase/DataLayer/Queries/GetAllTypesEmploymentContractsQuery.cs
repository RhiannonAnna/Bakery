using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Entities;
using Bakery.CodeBase.ServiceLayer;
using System.Data.SqlClient;

namespace Bakery.CodeBase.DataLayer.Queries
{
    public class GetAllTypesEmploymentContractsQuery : IQuery<List<TypeEmploymentContract>>
    {
        public List<TypeEmploymentContract> Execute()
        {
            string sqlQuery = "SELECT * FROM [TypeEmploymentContracts]";
            List<TypeEmploymentContract> typeEmploymentContracts = new List<TypeEmploymentContract>();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        typeEmploymentContracts.Add(MainService.GetSingleTypeEmploymentContract(r));
                    }
                }
            }
            return typeEmploymentContracts;
        }
    }
}
