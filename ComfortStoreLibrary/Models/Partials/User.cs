using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComfortStoreLibrary.Models
{
    public partial class User
    {
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName} {MiddleName}";
            }
        }
    }
}
