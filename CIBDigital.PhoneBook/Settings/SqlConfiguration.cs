using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIBDigital.PhoneBook.Settings
{
    public class SqlConfiguration :ISqlConfiguration
    {
        public string ConnectionString { get; set; }
    }
}
