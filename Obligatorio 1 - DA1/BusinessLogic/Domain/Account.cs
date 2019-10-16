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
        public string Phone { get; set; }
        public int Balance { get; set; }

        private const int DEFAULT_BALANCE = 0;

        public Account()
        {
            this.Balance = DEFAULT_BALANCE;
        }

        public void DecreaseBalance(int aNumber)
        {
            int decreasedBalance = this.Balance - aNumber;
            if (decreasedBalance < 0)
            {
                throw new BusinessException("Saldo insuficiente");
            }
            else
            {
                this.Balance = decreasedBalance;
            }
        }

        public void IncreaseBalance(int balanceAddition)
        {
            if (balanceAddition <= 0)
            {
                throw new BusinessException("Ingresar entero mayor a cero");
            }
            else
            {
                this.Balance += balanceAddition;
            }
        }
    }
}