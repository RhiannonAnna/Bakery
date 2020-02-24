using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Entities;
using Bakery.CodeBase.ServiceLayer;
using System.Data.SqlClient;

namespace Bakery.CodeBase.DataLayer.Queries
{
    public class GetAllStovesQuery : IQuery<List<Stove>>
    {
        public List<Stove> Execute()
        {
            string sqlQuery = "SELECT * FROM [Stoves]";
            List<Stove> stoves = new List<Stove>();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        stoves.Add(MainService.GetSingleStove(r));
                    }
                }
            }
            return stoves;
        }
    }
}
