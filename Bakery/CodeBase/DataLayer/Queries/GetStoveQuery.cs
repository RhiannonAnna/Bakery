using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Entities;
using Bakery.CodeBase.ServiceLayer;

namespace Bakery.CodeBase.DataLayer.Queries
{
    public class GetStoveQuery : IQuery<Stove>
    {
        private int ID;
        public GetStoveQuery(int ID)
        {
            this.ID = ID;
        }
        public Stove Execute()
        {
            string sqlQuery = "SELECT * FROM [Stoves] WHERE Id=@Id";
            Stove stove = new Stove();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                sqlComm.Parameters.Add("@" + Stove.IdDatabaseColumnName, SqlDbType.Int).Value = ID;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        stove = MainService.GetSingleStove(r);
                    }
                }
            }
            return stove;
        }
    }
}
