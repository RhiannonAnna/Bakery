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
                throw exc;
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
        public static void InsertEmployee(Employee employee)
        {
            var command = new InsertEmployeeCommand(employee);
            handleCommand(command);
        }
        #endregion



        #region TypeEmploymentContract
        public static void DeleteTypeEmploymentContract(int ID)
        {
            var command = new DeleteTypeEmploymentContractCommand(ID);
            handleCommand(command);
        }
        public static void UpdateTypeEmploymentContract(TypeEmploymentContract typeEmploymentContract)
        {
            var command = new UpdateTypeEmploymentContractCommand(typeEmploymentContract);
            handleCommand(command);
        }
        public static void InsertTypeEmploymentContract(TypeEmploymentContract typeEmploymentContract)  //tuuuuuuuuuuuuuuuuuuuuu
        {
            var command = new InsertTypeEmploymentContractCommand(typeEmploymentContract);
            handleCommand(command);            
        }
        #endregion


        #region Product
        public static void DeleteProduct(int ID)
        {
            var command = new DeleteProductCommand(ID);
            handleCommand(command);
        }
        public static void UpdateProduct(Product product)
        {
            var command = new UpdateProductCommand(product);
            handleCommand(command);
        }
        public static void InsertProduct(Product product)
        {
            var command = new InsertProductCommand(product);
            handleCommand(command);

        }
        #endregion

        #region BakeryPoint
        public static void DeleteBakeryPoint(int ID)
        {
            var command = new DeleteBakeryPointCommand(ID);
            handleCommand(command);
        }
        public static void UpdateBakeryPoint(BakeryPoint bakeryPoint)
        {
            var command = new UpdateBakeryPointCommand(bakeryPoint);
            handleCommand(command);
        }
        public static void InsertBakeryPoint(BakeryPoint bakeryPoint)
        {
            var command = new InsertBakeryPointCommand(bakeryPoint);
            handleCommand(command);
        }
        #endregion

        #region Car
        public static void DeleteCar(int ID)
        {
            var command = new DeleteCarCommand(ID);
            handleCommand(command);
        }
        public static void UpdateCar(Car car)
        {
            var command = new UpdateCarCommand(car);
            handleCommand(command);
        }
        public static void InsertCar(Car car)
        {
            var command = new InsertCarCommand(car);
            handleCommand(command);
        }
        #endregion



        #region Stove
        public static void DeleteStove(int ID)
        {
            var command = new DeleteStoveCommand(ID);
            handleCommand(command);
        }
        public static void UpdateStove(Stove stove)
        {
            var command = new UpdateStoveCommand(stove);
            handleCommand(command);
        }
        public static void InsertStove(Stove stove)
        {
            var command = new InsertStoveCommand(stove);
            handleCommand(command);
        }
        #endregion
    }
}
