using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Entities;
using Bakery.CodeBase.ServiceLayer;

namespace Bakery.CodeBase.DataLayer.Queries
{
    public class GetEmployeeQuery : IQuery<Employee>
    {
        private int ID;
        public GetEmployeeQuery(int ID)
        {
            this.ID = ID;
        }
        public Employee Execute()
        {
            string sqlQuery = "SELECT * FROM [Employee] WHERE Id=@Id";
            Employee employee = new Employee();
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                sqlComm.Parameters.Add("@" + Employee.IdDatabaseColumnName, SqlDbType.Int).Value = ID;
                using (SqlDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        employee = MainService.GetSingleEmployee(r);
                    }
                }
            }
            return employee;
        }
    }
}
