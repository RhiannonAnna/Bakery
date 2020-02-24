using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Entities;
using Bakery.CodeBase.ServiceLayer;

namespace Bakery.CodeBase.DataLayer.Queries
{
    public class GetProductQuery : IQuery<Product>
    {
        private int ID;
        public GetProductQuery(int ID)
        {
            this.ID = ID;
        }
        public Product Execute()
        {
            string sqlQuery = "SELECT * FROM [Product] WHERE Id=@Id";
            Product product = new Product();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                sqlComm.Parameters.Add("@" + Product.IdDatabaseColumnName, SqlDbType.Int).Value = ID;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        product = MainService.GetSingleProduct(r);
                    }
                }
            }
            return product;
        }
    }
}
