using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Bakery.CodeBase.DataLayer;
using Bakery.Entities;

namespace Bakery.CodeBase.ServiceLayer.Commands
{
    public class InsertEmployeeCommand : ICommand
    {
        private Employee employee;
        public InsertEmployeeCommand(Employee employee)
        {
            this.employee = employee;
        }
        public void Execute()
        {
            string sqlQuery = "INSERT INTO [Employees] (Age, Name, IsMen, StartTimeEmployment, TypeIdEmploymentContract) VALUES (@Age, @Name, @IsMen, @StartTimeEmployment, @TypeIdEmploymentContract)";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                
                sqlComm.Parameters.Add("@" + Employee.AgeDatabaseColumnName, SqlDbType.TinyInt).Value = employee.Age;
                sqlComm.Parameters.Add("@" + Employee.NameDatabaseColumnName, SqlDbType.NVarChar).Value = employee.Name;
                sqlComm.Parameters.Add("@" + Employee.IsMenDatabaseColumnName, SqlDbType.Bit).Value = employee.IsMen;
                sqlComm.Parameters.Add("@" + Employee.StartTimeEmploymentColumnName, SqlDbType.DateTime).Value = employee.StartTimeEmployment;
                sqlComm.Parameters.Add("@" + Employee.TypeIdEmploymentContractColumnName, SqlDbType.TinyInt).Value = employee.TypeIdEmploymentContract;

                sqlComm.ExecuteNonQuery();
                
            }
        }
    }
}
