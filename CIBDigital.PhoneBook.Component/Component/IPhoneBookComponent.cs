using CIBDigital.PhoneBook.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIBDigital.PhoneBook.Component
{
    public interface IPhoneBookComponent
    {
        Task<List<PhoneBookModel>> Get();
        Task<bool> Add(PhoneBookModel model);
    }
}
