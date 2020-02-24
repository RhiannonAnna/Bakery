using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Entities;
using Bakery.CodeBase.ServiceLayer;
using System.Data.SqlClient;

namespace Bakery.CodeBase.DataLayer.Queries
{
    public class GetAllBakeryPointsQuery : IQuery<List<BakeryPoint>>
    {
        public List<BakeryPoint> Execute()
        {
            string sqlQuery = "SELECT * FROM [Bakeries]";
            List<BakeryPoint> bakeryPoints = new List<BakeryPoint>();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        bakeryPoints.Add(MainService.GetSingleBakeryPoint(r));
                    }
                }
            }
            return bakeryPoints;
        }
    }
}
