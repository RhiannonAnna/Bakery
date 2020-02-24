using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Entities
{
    public class TypeEmploymentContract
    {
        #region properties
        public int Id { get; set; }
        public string Name { get; set; }
        
        #endregion
        #region Database columns' names 
        public static string IdDatabaseColumnName = "Id";
        public static string NameDatabaseColumnName = "Name";

        #endregion
        #region constructors
        public TypeEmploymentContract()
        {

        }
        #endregion
    }
}
