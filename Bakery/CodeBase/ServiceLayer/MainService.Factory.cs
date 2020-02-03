using Bakery.CodeBase.ServiceLayer.Tools;
using Bakery.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.CodeBase.ServiceLayer
{
    public static partial class MainService
    {
        public static Employee GetSingleEmployee(SqlDataReader dataFromDatabase)
        {
            Employee employee = new Employee();

            employee.Id = dataFromDatabase.HasColumn(Employee.IdDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[Employee.IdDatabaseColumnName]) : 0;
            employee.Age = dataFromDatabase.HasColumn(Employee.AgeDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[Employee.AgeDatabaseColumnName]) : 0;
            employee.Name = dataFromDatabase.HasColumn(Employee.NameDatabaseColumnName) ? dataFromDatabase[Employee.NameDatabaseColumnName].ToString() : "Default";
            employee.Gender = dataFromDatabase.HasColumn(Employee.GenderDatabaseColumnName) ? (bool)dataFromDatabase[Employee.GenderDatabaseColumnName] : false;
            employee.StartTimeEmployment = dataFromDatabase.HasColumn(Employee.StartTimeEmploymentColumnName) ? DateTime.Parse(dataFromDatabase[Employee.StartTimeEmploymentColumnName].ToString()) : new DateTime();
            employee.TypeIdEmploymentContract = dataFromDatabase.HasColumn(Employee.TypeIdEmploymentContractColumnName) ? Convert.ToInt32(dataFromDatabase[Employee.TypeIdEmploymentContractColumnName]) : 0;

            return employee;
        }
    }
}
