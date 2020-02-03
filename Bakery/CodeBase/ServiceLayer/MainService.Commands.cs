using Bakery.CodeBase.ServiceLayer.Commands;
using Bakery.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.CodeBase.ServiceLayer
{
    public static partial class MainService
    {
        #region handleCommand
        public static void handleCommand(ICommand command)
        {
            try
            {
                command.Execute();
            }
            catch (Exception exc)
            {
                //ToDo: implement NLog
            }
        }
        #endregion
        #region Employee
        public static void DeleteEmployee(int ID)
        {
            var command = new DeleteEmployeeCommand(ID);
            handleCommand(command);
        }
        public static void UpdateEmployee(Employee employee)
        {
            var command = new UpdateEmployeeCommand(employee);
            handleCommand(command);
        }
        public static int InsertEmployee(Employee employee)
        {
            var command = new InsertEmployeeCommand(employee);
            handleCommand(command);
            return InsertEmployeeCommand.InsertedID;
        }
        #endregion
    }
}
