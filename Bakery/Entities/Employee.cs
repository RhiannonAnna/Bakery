using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Entities
{
    public class Employee
    {
        #region properties
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime StartTimeEmployment { get; set; }
        public int TypeIdEmploymentContract { get; set; }
        #endregion
        #region Database columns' names 
        public static string IdDatabaseColumnName = "Id";
        public static string AgeDatabaseColumnName = "Age";
        public static string NameDatabaseColumnName = "Name";
        public static string GenderDatabaseColumnName = "Gender";
        public static string StartTimeEmploymentColumnName = "StartTimeEmployment";
        public static string TypeIdEmploymentContractColumnName = "TypeIdEmploymentContract";
        #endregion
        #region constructors
        public Employee()
        {

        }
        #endregion
    }
}
