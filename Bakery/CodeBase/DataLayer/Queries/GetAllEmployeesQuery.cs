using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Entities;
using Bakery.CodeBase.ServiceLayer;
using System.Data.SqlClient;

namespace Bakery.CodeBase.DataLayer.Queries
{
    public class GetAllEmployeesQuery : IQuery<List<Employee>>
    {
        public List<Employee> Execute()
        {
            string sqlQuery = "SELECT * FROM [Employee]";
            List<Employee> employee = new List<Employee>();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        employee.Add(MainService.GetSingleEmployee(r));
                    }
                }
            }
            return employee;
        }
    }
}
