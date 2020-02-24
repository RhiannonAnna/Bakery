using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Entities;
using Bakery.CodeBase.ServiceLayer;

namespace Bakery.CodeBase.DataLayer.Queries
{
    public class GetBakeryPointQuery : IQuery<BakeryPoint>
    {
        private int ID;
        public GetBakeryPointQuery(int ID)
        {
            this.ID = ID;
        }
        public BakeryPoint Execute()
        {
            string sqlQuery = "SELECT * FROM [Bakeries] WHERE Id=@Id";
            BakeryPoint bakeryPoint = new BakeryPoint();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                sqlComm.Parameters.Add("@" + BakeryPoint.IdDatabaseColumnName, SqlDbType.Int).Value = ID;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        bakeryPoint = MainService.GetSingleBakeryPoint(r);
                    }
                }
            }
            return bakeryPoint;
        }
    }
}

