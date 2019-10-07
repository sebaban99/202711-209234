using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Account
    {
        public string Phone { get; set; }
        public object Balance { get; set; }

        private const int DEFAULT_BALANCE = 0;

        public Account(string aPhone)
        {
            this.Phone = aPhone;
            this.Balance = DEFAULT_BALANCE;
        }
    }
}
