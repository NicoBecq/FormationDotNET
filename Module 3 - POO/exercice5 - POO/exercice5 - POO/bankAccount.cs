using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice5___POO
{
    class BankAccount
    {
        //déclaration des attributs de la class
        public string owner;
        public double balance;
        public string devise;
        //déclaration des méthodes crédit et débit, créditant ou débitant un amount a balance, et acceptant comme paramètres amount de type double
        public void Credit(double amount)
        {
            balance += amount;
        }
        public void Debit(double amount)
        {
            balance -= amount;
        }
    }
}
