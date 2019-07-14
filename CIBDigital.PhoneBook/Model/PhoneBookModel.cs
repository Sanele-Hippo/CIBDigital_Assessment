using System;
using System.Collections.Generic;
using System.Text;

namespace CIBDigital.PhoneBook.Model
{
    public class PhoneBookModel
    {
        public string Initial { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }

        public PhoneBookModel(string initial,string name, string phoneNumber)
        {
            Initial = initial;
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
