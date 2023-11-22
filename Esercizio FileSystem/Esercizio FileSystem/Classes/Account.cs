using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_FileSystem.Classes
{
    internal class Account
    {
        public int AccountID {  get; set; }
        public decimal Saldo { get; set; }

        public Account(int accountID, decimal saldo)
        {
            AccountID = accountID;
            Saldo = saldo;
        }

        public override string ToString()
        {
            return $"AccountID: {AccountID}, Balance:{Saldo}";
        }
    }
}
