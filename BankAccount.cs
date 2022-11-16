using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class BankAccount
    {

        //Sådan ser vores bank konto ud, men vi har ikke lavet nogle bank konto endu
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { 
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int accountNumberSeed = 1234567890;

        //Her har jeg lavet en tom liste med Transactions
        private List<Transaction> allTransactions = new List<Transaction>();

        //Starter properties så de kan bruges til noget
        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;

            MakeDeposit(initialBalance, DateTime.Now, "initial Balance");

            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        //Handlinger der kan ske. Så nu er de ikke properties men metoder
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if(Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            //HEADER
            report.AppendLine("Date\t\t\t Amount\tNote");
            foreach (var item in allTransactions)
            {
                //ROWS
                report.AppendLine($"{item.Date}\t{item.Amount}\t{item.Notes}");   
            }
            return report.ToString();
        }
    }
}
