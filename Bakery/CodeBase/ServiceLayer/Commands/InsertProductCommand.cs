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
    public class InsertProductCommand : ICommand
    {
        private Product product;
        public InsertProductCommand(Product product)
        {
            this.product = product;
        }
        public void Execute()
        {
            string sqlQuery = "INSERT INTO [Products] (Name, Price, Weight, Description, Quantity ) VALUES (@Name, @Price, @Weight, @Description, @Quantity)";
            using (SqlConnection sqlConn = new SqlConnection(MainRepository.ConnectionString))
            {
                if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
                sqlComm.CommandType = CommandType.Text;

                sqlComm.Parameters.Add("@" + Product.NameDatabaseColumnName, SqlDbType.NVarChar).Value = product.Name;
                sqlComm.Parameters.Add("@" + Product.PriceDatabaseColumnName, SqlDbType.Int).Value = product.Price;
                sqlComm.Parameters.Add("@" + Product.WeightDatabaseColumnName, SqlDbType.Int).Value = product.Weight;
                sqlComm.Parameters.Add("@" + Product.DescriptionDatabaseColumnName, SqlDbType.NVarChar).Value = product.Description;
                sqlComm.Parameters.Add("@" + Product.QuantityDatabaseColumnName, SqlDbType.Int).Value = product.Quantity;

                sqlComm.ExecuteNonQuery();                
            }
        }
    }
}
