using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Entities
{
    public class Car
    {
        #region properties
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Registration { get; set; }
        #endregion

        #region Database columns' names 
        public static string IdDatabaseColumnName = "Id";
        public static string DescriptionDatabaseColumnName = "Description";
        public static string TypeDatabaseColumnName = "Type";
        public static string RegistrationDatabaseColumnName = "Registration";

        #endregion
        #region constructors
        public Car()
        {

        }
        #endregion
    }
}
