using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Entities
{
    public class Product
    {
    #region properties
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        #endregion
        #region Database columns' names 
        public static string IdDatabaseColumnName = "Id";
        public static string NameDatabaseColumnName = "Name";
        public static string PriceDatabaseColumnName = "Price";
        public static string WeightDatabaseColumnName = "Weight";
        public static string DescriptionDatabaseColumnName = "Description";
        public static string QuantityDatabaseColumnName = "Quantity";

        #endregion
        #region constructors
        public Product()
        {

        }
        #endregion
    }
}
