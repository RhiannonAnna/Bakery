using Bakery.CodeBase.DataLayer.Queries;
using Bakery.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.CodeBase.ServiceLayer
{
    public static partial class MainService
    {
        #region handleQuery
        public static T handleQuery<T>(IQuery<T> query)
        {
            try
            {
                return query.Execute();
            }
            catch (Exception exc)
            {
                //ToDo: implement NLog
                return default(T);
            }
        }
        #endregion

        #region Employee
        public static List<Employee> GetAllEmployees()
        {
            var query = new GetAllEmployeesQuery();
            return handleQuery(query);
        }
        public static Employee GetEmployee(int ID)
        {
            var query = new GetEmployeeQuery(ID);
            return handleQuery(query);
        }
        #endregion
    }
}
