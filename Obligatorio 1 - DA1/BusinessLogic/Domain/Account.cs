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