using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ATM_Savage_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //(1)Create Account(2)Login"
            Console.Title = "ATM Lab";
            //Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            var newATM = new ATM();
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("      Welcome to the Grand Circus ATM           ");
                Console.WriteLine($"What would you like to do?");
                Console.WriteLine("(1). Creat a New Account");
                Console.WriteLine("(2). Loging to your Account");
                Console.WriteLine("***************");
                Console.WriteLine("ENTER YOUR CHOICE : ");
                int usersInputer = int.Parse(Console.ReadLine());
                
                if (usersInputer == 1)
                {
                    Console.WriteLine($"Please enter your user login and password.");
                    var userName = Console.ReadLine();
                    var userPassword = Console.ReadLine();
                    newATM.Register(userName, userPassword);
                }
                else
                {
                    Console.WriteLine($"Please enter your user login and password.");
                    var userName = Console.ReadLine();
                    var userPassword = Console.ReadLine();
                    newATM.Login(userName, userPassword);
                }
            }
            
            
            Console.WriteLine($"Please enter the option you would like:");

            Console.WriteLine("(1) Deposit");
            Console.WriteLine("(2) Withdraw");
            Console.WriteLine("(3) Check Balance");
            Console.WriteLine("(4) Logout");
            int.TryParse(Console.ReadLine(), out int userSelection);
            switch (userSelection)
            {
                case 1:
                    Console.WriteLine("Please enter the amount you want  to deposit.");
                    int.TryParse(Console.ReadLine(), out int depositAmount);
                    newATM.Deposit(depositAmount);
                    Console.WriteLine($"Your deposit of ${depositAmount} was successful!");
                    break;
                case 2:
                    Console.Write("How much money would you like to withdraw:");
                    int.TryParse(Console.ReadLine(), out int withdrawAmount);
                    newATM.Withdraw(withdrawAmount);
                    Console.WriteLine($"Your withdraw of ${withdrawAmount} was successful!");
                    break;
                case 3:
                    newATM.CheckBalance();
                    break;
                case 4:
                    newATM.Logout();
                    break;
                default:
                    Console.WriteLine("Adios Amig@! ");
                    break;
            }
        }
    }

    class ATM
    {
        public ATM()
        {
            var ListOfAccounts = new List<Account>();
            Accounts = ListOfAccounts;
        }
        public List<Account> Accounts { get; set; }
        public Account CurrentAccount { get; set; }
        public void Register(string name, string password)
        {
            Console.WriteLine("Registering.....");
            var account = new Account(name, password);
            Accounts.Add(account);
            CurrentAccount = account;
        }
        public void Login(string name, string password)
        {
            if (CurrentAccount == null)
            {
                foreach (var account in Accounts)
                {
                    if (account.Name == name && account.Password == password)
                    {
                        Console.WriteLine("Logging in....");
                        CurrentAccount = account;
                    }
                }
            }
        }
        public void Logout()
        {
            CurrentAccount = null;
        }
        public void CheckBalance()
        {
            Console.WriteLine(CurrentAccount.Balance);
        }
        public void Deposit(int deposit)
        {
            var newBalance = deposit + CurrentAccount.Balance;
            CurrentAccount.Balance = newBalance;
        }
        public void Withdraw(int withdraw)
        {
            var newBalance = withdraw - CurrentAccount.Balance;
            CurrentAccount.Balance = newBalance;
        }
    }
    public class Account
    {
        public Account(string name, string password, int balance)
        {
            var _name = name;
            Name = _name;

            var _password = password;
            Password = _password;

            var _balance = balance;
            Balance = _balance;
        }
        public Account(string name, string password)
        {
            Name = name;
            Password = password;
           
           
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
    }
}