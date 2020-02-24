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
            employee.IsMen = dataFromDatabase.HasColumn(Employee.IsMenDatabaseColumnName) ? (bool)dataFromDatabase[Employee.IsMenDatabaseColumnName] : false;
            employee.StartTimeEmployment = dataFromDatabase.HasColumn(Employee.StartTimeEmploymentColumnName) ? DateTime.Parse(dataFromDatabase[Employee.StartTimeEmploymentColumnName].ToString()) : new DateTime();
            employee.TypeIdEmploymentContract = dataFromDatabase.HasColumn(Employee.TypeIdEmploymentContractColumnName) ? Convert.ToInt32(dataFromDatabase[Employee.TypeIdEmploymentContractColumnName]) : 0;

            return employee;
        }

        public static TypeEmploymentContract GetSingleTypeEmploymentContract(SqlDataReader dataFromDatabase)
        {
            TypeEmploymentContract typeEmploymentContract = new TypeEmploymentContract();

            typeEmploymentContract.Id = dataFromDatabase.HasColumn(TypeEmploymentContract.IdDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[TypeEmploymentContract.IdDatabaseColumnName]) : 0;
            typeEmploymentContract.Name = dataFromDatabase.HasColumn(TypeEmploymentContract.NameDatabaseColumnName) ? dataFromDatabase[TypeEmploymentContract.NameDatabaseColumnName].ToString() : "Default";

            return typeEmploymentContract;
        }
        public static Product GetSingleProduct(SqlDataReader dataFromDatabase)
        {
            Product product = new Product();

            product.Id = dataFromDatabase.HasColumn(Product.IdDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[Product.IdDatabaseColumnName]) : 0;
            product.Name = dataFromDatabase.HasColumn(Product.NameDatabaseColumnName) ? dataFromDatabase[Product.NameDatabaseColumnName].ToString() : "Default";
            product.Price = dataFromDatabase.HasColumn(Product.PriceDatabaseColumnName) ? decimal.Parse(dataFromDatabase[Product.PriceDatabaseColumnName].ToString()) : 0;
            product.Weight = dataFromDatabase.HasColumn(Product.WeightDatabaseColumnName) ? decimal.Parse(dataFromDatabase[Product.WeightDatabaseColumnName].ToString()) : 0;
            product.Description = dataFromDatabase.HasColumn(Product.DescriptionDatabaseColumnName) ? dataFromDatabase[Product.DescriptionDatabaseColumnName].ToString() : "Default";
            product.Quantity = dataFromDatabase.HasColumn(Product.QuantityDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[Product.QuantityDatabaseColumnName]) : 0;


            return product;
        }

        public static BakeryPoint GetSingleBakeryPoint(SqlDataReader dataFromDatabase)
        {
            BakeryPoint bakeryPoint = new BakeryPoint();

            bakeryPoint.Id = dataFromDatabase.HasColumn(BakeryPoint.IdDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[BakeryPoint.IdDatabaseColumnName]) : 0;
            bakeryPoint.City = dataFromDatabase.HasColumn(BakeryPoint.CityDatabaseColumnName) ? dataFromDatabase[BakeryPoint.CityDatabaseColumnName].ToString() : "Default";
            bakeryPoint.Description = dataFromDatabase.HasColumn(BakeryPoint.DescriptionDatabaseColumnName) ? dataFromDatabase[BakeryPoint.DescriptionDatabaseColumnName].ToString() : "Default";
            bakeryPoint.Address = dataFromDatabase.HasColumn(BakeryPoint.AddressDatabaseColumnName) ? dataFromDatabase[BakeryPoint.AddressDatabaseColumnName].ToString() : "Default";

            return bakeryPoint;
        }
        public static Car GetSingleCar(SqlDataReader dataFromDatabase)
        {
            Car car = new Car();

            car.Id = dataFromDatabase.HasColumn(Car.IdDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[Car.IdDatabaseColumnName]) : 0;
            car.Description = dataFromDatabase.HasColumn(Car.DescriptionDatabaseColumnName) ? dataFromDatabase[Car.DescriptionDatabaseColumnName].ToString() : "Default";
            car.Type = dataFromDatabase.HasColumn(Car.TypeDatabaseColumnName) ? dataFromDatabase[Car.TypeDatabaseColumnName].ToString() : "Default";
            car.Registration = dataFromDatabase.HasColumn(Car.RegistrationDatabaseColumnName) ? dataFromDatabase[Car.RegistrationDatabaseColumnName].ToString() : "Default";

            return car;
        }
        public static Stove GetSingleStove(SqlDataReader dataFromDatabase)
        {
            Stove stove = new Stove();

            stove.Id = dataFromDatabase.HasColumn(Stove.IdDatabaseColumnName) ? Convert.ToInt32(dataFromDatabase[Stove.IdDatabaseColumnName]) : 0;
            stove.Type = dataFromDatabase.HasColumn(Stove.TypeDatabaseColumnName) ? dataFromDatabase[Stove.TypeDatabaseColumnName].ToString() : "Default";

            return stove;
        }
    }
}
