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
        public static int InsertedID;
        public InsertEmployeeCommand(Employee employee)
        {
            this.employee = employee;
        }
        public void Execute()
        {
            string sqlQuery = "INSERT INTO [Employee] (Age, Name, Gender, StartTimeEmployment, TypeIdEmploymentContract) VALUES (@Age, @Name, @Gender, @StartTimeEmployment, @TypeIdEmploymentContract)";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;

                SqlParameter outputParam = sqlComm.Parameters.Add("@" + Employee.IdDatabaseColumnName, SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;

                sqlComm.Parameters.Add("@" + Employee.AgeDatabaseColumnName, SqlDbType.TinyInt).Value = employee.Age;
                sqlComm.Parameters.Add("@" + Employee.NameDatabaseColumnName, SqlDbType.NVarChar).Value = employee.Name;
                sqlComm.Parameters.Add("@" + Employee.GenderDatabaseColumnName, SqlDbType.Bit).Value = employee.Gender;
                sqlComm.Parameters.Add("@" + Employee.StartTimeEmploymentColumnName, SqlDbType.DateTime).Value = employee.StartTimeEmployment;
                sqlComm.Parameters.Add("@" + Employee.TypeIdEmploymentContractColumnName, SqlDbType.DateTime).Value = employee.TypeIdEmploymentContract;

                sqlComm.ExecuteNonQuery();
                InsertedID = Convert.ToInt32(outputParam.Value);
            }
        }
    }
}
