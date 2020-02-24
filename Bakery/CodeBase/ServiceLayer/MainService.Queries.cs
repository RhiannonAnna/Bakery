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
                Console.WriteLine(exc);
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

        #region TypeEmploymentContract
        public static List<TypeEmploymentContract> GetAllTypeEmploymentContract()
        {
            var query = new GetAllTypesEmploymentContractsQuery();
            return handleQuery(query);
        }
        public static TypeEmploymentContract GetTypeEmploymentContract(int ID)
        {
            var query = new GetTypeEmploymentContractQuery(ID);
            return handleQuery(query);
        }
        #endregion

        #region Product
        public static List<Product> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            return handleQuery(query);
        }
        public static Product GetProduct(int ID)
        {
            var query = new GetProductQuery(ID);
            return handleQuery(query);
        }
        #endregion

        #region BakeryPoint
        public static List<BakeryPoint> GetAllBakeryPoint()
        {
            var query = new GetAllBakeryPointsQuery();
            return handleQuery(query);
        }
        public static BakeryPoint GetBakeryPoint(int ID)
        {
            var query = new GetBakeryPointQuery(ID);
            return handleQuery(query);
        }
        #endregion

        #region Car
        public static List<Car> GetAllCars()
        {
            var query = new GetAllCarsQuery();
            return handleQuery(query);
        }
        public static Car GetCar(int ID)
        {
            var query = new GetCarQuery(ID);
            return handleQuery(query);
        }
        #endregion

        #region Stove
        public static List<Stove> GetAllStoves()
        {
            var query = new GetAllStovesQuery();
            return handleQuery(query);
        }
        public static Stove GetStove(int ID)
        {
            var query = new GetStoveQuery(ID);
            return handleQuery(query);
        }
        #endregion
    }
}
