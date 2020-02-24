using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Entities;
using Bakery.CodeBase.ServiceLayer;
using System.Data.SqlClient;

namespace Bakery.CodeBase.DataLayer.Queries
{
    public class GetAllCarsQuery : IQuery<List<Car>>
    {
        public List<Car> Execute()
        {
            string sqlQuery = "SELECT * FROM [BakeryDb].[dbo].[Cars]";
            List<Car> cars = new List<Car>();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        cars.Add(MainService.GetSingleCar(r));
                    }
                }
            }
            return cars;
        }
    }
}
