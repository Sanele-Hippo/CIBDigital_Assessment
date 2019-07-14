using CIBDigital.PhoneBook.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIBDigital.PhoneBook.Service
{
    public interface IPhoneBookService
    {
        Task<List<PhoneBookModel>> Get();
        Task<bool> Add(PhoneBookModel model);
    }
}
