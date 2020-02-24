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
    public class UpdateProductCommand : ICommand
    {
        private Product product;
        public UpdateProductCommand(Product product)
        {
            this.product = product;
        }
        public void Execute()
        {
            string sqlQuery = "UPDATE [Products] SET Name = @Name, Price = @Price, Weight = @Weight, Description = @Description, Quantity = @Quantity WHERE Id = @Id";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                sqlComm.Parameters.Add("@" + Product.IdDatabaseColumnName, SqlDbType.Int).Value = product.Id;
                sqlComm.Parameters.Add("@" + Product.NameDatabaseColumnName, SqlDbType.NVarChar).Value = product.Name;
                sqlComm.Parameters.Add("@" + Product.PriceDatabaseColumnName, SqlDbType.Int).Value = product.Price;
                sqlComm.Parameters.Add("@" + Product.WeightDatabaseColumnName, SqlDbType.Int).Value = product.Weight;
                sqlComm.Parameters.Add("@" + Product.DescriptionDatabaseColumnName, SqlDbType.NVarChar).Value = product.Name;
                sqlComm.Parameters.Add("@" + Product.QuantityDatabaseColumnName, SqlDbType.Int).Value = product.Quantity;

                sqlComm.ExecuteNonQuery();
            }
        }
    }
}
