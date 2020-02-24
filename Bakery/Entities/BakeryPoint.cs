using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Entities
{
    public class BakeryPoint
    {
        #region properties
        public int Id { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        #endregion
        #region Database columns' names 
        public static string IdDatabaseColumnName = "Id";
        public static string CityDatabaseColumnName = "City";
        public static string DescriptionDatabaseColumnName = "Description";
        public static string AddressDatabaseColumnName = "Address";

        #endregion
        #region constructors
        public BakeryPoint()
        {

        }
        #endregion
    }
}
