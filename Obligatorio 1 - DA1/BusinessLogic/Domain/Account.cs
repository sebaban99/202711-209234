using BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Account
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public int Balance { get; set; }
        public string CountryTag { get; set; }

        public Account() { }

    }   
}