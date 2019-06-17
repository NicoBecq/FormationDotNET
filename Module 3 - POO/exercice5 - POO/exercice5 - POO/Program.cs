using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice5___POO
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount CompteLaManu = new BankAccount();
            // autre manière de set les attributs 
            //BankAccount CompteLaManu = new BankAccount
            //{
            //    owner = "LaManu",
            //    balance = 2000,
            //    devise = "euros"
            //};
            //CompteLaManu.owner = "LaManu";
            //CompteLaManu.balance = 2000;
            //CompteLaManu.devise = "euros";
            //CompteLaManu.Credit(19);
            //Console.WriteLine($"Le titulaire du compte est : {CompteLaManu.owner}\nLe solde du compte est de : {CompteLaManu.balance} {CompteLaManu.devise}.");
            Console.WriteLine("Bonjour!\nBienvenue dans la création de compte bancaire!\nSaisissez votre nom :");
            CompteLaManu.owner = Console.ReadLine();
            CompteLaManu.balance = 0;
            bool balanceIsGood = false;
            while (!balanceIsGood)
            {
                Console.WriteLine("Saisissez le solde du compte : ");
                if (double.TryParse(Console.ReadLine(), out double balance))
                {
                    CompteLaManu.balance = balance;
                    balanceIsGood = true;
                }
                else
                {
                    Console.WriteLine("Veuillez saisir un nombre.");
                }
            }
            Console.WriteLine("Informations enregistrées avec succès!");
            Console.ReadKey();
            bool prgRun = false;
            while (!prgRun)
            {
                Console.Clear();
                Console.WriteLine("Saisissez 1 si vous souhaitez créditer votre compte.\nSaisissez 2 pour débiter.");
                if (int.TryParse(Console.ReadLine(), out int userChoice) && (userChoice == 1 || userChoice == 2))
                {
                    bool creditIsGood = false;
                    while (!creditIsGood)
                    {
                        if (userChoice == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Saisissez le montant à créditer");
                            if (double.TryParse(Console.ReadLine(), out double credit))
                            {
                                CompteLaManu.Credit(credit);
                                creditIsGood = true;
                                Console.WriteLine($"Compté crédité.\nLe titulaire du compte est : {CompteLaManu.owner}\nLe solde du compte est de : {CompteLaManu.balance} {CompteLaManu.devise}.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Saisie non reconnue, veuillez saisir ");
                            }
                        }
                        else if (userChoice == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("Saisissez le montant à débiter");
                            if (double.TryParse(Console.ReadLine(), out double debit))
                            {
                                CompteLaManu.Debit(debit);
                                creditIsGood = true;
                                Console.WriteLine($"Compté débité.\nLe titulaire du compte est : {CompteLaManu.owner}\nLe solde du compte est de : {CompteLaManu.balance} {CompteLaManu.devise}.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Saisie non reconnue, veuillez saisir ");
                            }
                        }
                    }
                }
            }
        }
    }
}
