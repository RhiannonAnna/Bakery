using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Entities
{
    public class Stove
    {
        #region properties
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        #endregion
        #region Database columns' names 
        public static string IdDatabaseColumnName = "Id";
        public static string TypeDatabaseColumnName = "Type";
        public static string DescriptionDatabaseColumnName = "Description";

        #endregion
        #region constructors
        public Stove()
        {

        }
        #endregion
    }
}
