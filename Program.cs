using System;

namespace OOP // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Elias", 10000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}");

            account.MakeWithdrawal(120, DateTime.Now, "Hammock");
            account.MakeWithdrawal(50, DateTime.Now, "Xbox Game");

            Console.WriteLine(account.GetAccountHistory());




            ////Tjekker for negative tal
            //try
            //{
            //    account.MakeWithdrawal(75000, DateTime.Now, "Attept to overdraw");
            //}
            //catch (InvalidOperationException e)
            //{
            //    Console.WriteLine("Exception caught trying to overdraw");
            //    Console.WriteLine(e.ToString());
            //}

            ////Tester om balancen skal være positiv
            //try
            //{
            //    var invalidAccount = new BankAccount("invalid", -55);
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine("Exception caught creating account with negative balance");
            //    Console.WriteLine(e.ToString());
            //}
        }
    }
}