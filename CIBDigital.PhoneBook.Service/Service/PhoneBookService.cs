using CIBDigital.PhoneBook.Component;
using CIBDigital.PhoneBook.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIBDigital.PhoneBook.Service
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IPhoneBookComponent _phoneBookComponent;
        public PhoneBookService(IPhoneBookComponent phoneBookComponent)
        {
            _phoneBookComponent = phoneBookComponent;
        }

        public async Task<List<PhoneBookModel>> Get()
        {
            return await _phoneBookComponent.Get().ConfigureAwait(false);
        }
        
        public async Task<bool> Add(PhoneBookModel model)
        {
            return await _phoneBookComponent.Add(model).ConfigureAwait(false);
        }
    }
}
