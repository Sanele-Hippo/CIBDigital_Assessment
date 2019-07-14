using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIBDigital.PhoneBook.Component
{
    public interface ISqlRepository
    {
        Task<object> Insert(object param, string storedProc);

        Task<List<T>> Get<T>(string storedProc); 
    }
}
