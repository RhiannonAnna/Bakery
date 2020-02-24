using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Entities;
using Bakery.CodeBase.ServiceLayer;

namespace Bakery.CodeBase.DataLayer.Queries
{
    public class GetCarQuery : IQuery<Car>
    {
        private int ID;
        public GetCarQuery(int ID)
        {
            this.ID = ID;
        }
        public Car Execute()
        {
            string sqlQuery = "SELECT * FROM [Cars] WHERE Id=@Id";
            Car car = new Car();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                sqlComm.Parameters.Add("@" + Car.IdDatabaseColumnName, SqlDbType.Int).Value = ID;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        car = MainService.GetSingleCar(r);
                    }
                }
            }
            return car;
        }
    }
}
