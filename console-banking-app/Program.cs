using System;
using System.Collections.Generic;

namespace banking_app
{
    public class Instance

    {
        //Instantiate lists for storing data
        public List<User> Users = new List<User>();
        public List<Transaction> transactions = new List<Transaction>();

        public void accountMenu(User user)
        {
            void backToAccountMenu()
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();

                accountMenu(user);
            }
            string optionSelected = "";
            decimal amount;

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Account Menu");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Select an option to continue");
            Console.WriteLine("B : View Balance");
            Console.WriteLine("D : Deposit Funds");
            Console.WriteLine("W : withdrawal funds");
            Console.WriteLine("H : View account history");
            Console.WriteLine("logout : to logout");
            optionSelected = Console.ReadLine();

            //Switch for dispatching function based off of user input
            switch (optionSelected.ToLower())
            {
                case "b":
                    getBalance();
                    break;
                case "d":
                    depositFunds();
                    break;
                case "w":
                    withdrawalFunds();
                    break;
                case "h":
                    viewHistory();
                    break;
                case "logout":
                    logout();
                    break;
                default:
                    backToAccountMenu();
                    break;
            }

            void getBalance()
            {
                Console.WriteLine("Your current balance is: $" + user.balance);
                backToAccountMenu();
            }

            void depositFunds()
            {
                Console.WriteLine("How much would you like to deposit?");

                amount = Convert.ToDecimal(Console.ReadLine());
                user.balance += amount;

                Console.WriteLine("You new balance is: $ " + user.balance);

                //instantiate new transaction
                Transaction deposit = new Transaction();
                deposit.date = DateTime.Now;
                deposit.type = "deposit";
                deposit.amount = amount;

                //add transaction to transactions list
                transactions.Add(deposit);

                backToAccountMenu();
            }

            void withdrawalFunds()
            {
                Console.WriteLine("How much would you like to withdrawal?");

                amount = Convert.ToDecimal(Console.ReadLine());
                // check to make they have enough money
                if (user.balance > amount)
                {
                    user.balance -= amount;
                }
                else
                {
                    Console.WriteLine("(╯°□°)╯ insufficient funds!");
                }
                Console.WriteLine("You balance is:  $" + user.balance);

                //instantiate new transaction
                Transaction withdrawal = new Transaction();
                withdrawal.date = DateTime.Now;
                withdrawal.type = "withdrawal";
                withdrawal.amount = amount;

                //add transaction to transactions list
                transactions.Add(withdrawal);

                backToAccountMenu();

            }

            void viewHistory()
            {
                // loop through Transactions list and display each transaction
                for (int i = 0; i < transactions.Count; i++)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Date: " + transactions[i].date);
                    Console.WriteLine("Transaction type: " + transactions[i].type);
                    Console.WriteLine("Amount : $" + transactions[i].amount);
                }

                backToAccountMenu();
            }
            //clear user, console and return to main menu.
            void logout()
            {
                user = null;
                Console.Clear();
                MainMenu();
            }
        }

        public void MainMenu()
        {
            Console.Clear();

            string mainMenuOptionSelected = "";

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Main Menu");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("Select an option to continue...");
            Console.WriteLine("l : Log in");
            Console.WriteLine("r : Register");

            mainMenuOptionSelected = Console.ReadLine();

            if (mainMenuOptionSelected == "l")
            {
                Login();
            }
            if (mainMenuOptionSelected == "r")
            {
                signup();
            }
            else
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                MainMenu();
            }
        }

        public void Login()
        {
            User currentUser = new User();

            if (Users.Count < 1)
            {
                Console.WriteLine("(╯°□°)╯ Please create an account before logging in");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                MainMenu();
            }
            else
            {
                Console.Clear();
                string lUsername, lpin;

                Console.WriteLine("Login");
                Console.WriteLine("---------------------------------");

                Console.WriteLine("Enter your username");
                lUsername = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Enter your pin");
                lpin = Console.ReadLine();
                Console.Clear();

                // Look for username match in Users list
                currentUser = Users.Find(User => User.username == lUsername);

                //if match found
                if (currentUser != null)
                {
                    //check that pin matches
                    if (currentUser.pin == lpin)
                    {
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("You are logged in as " + lUsername);
                        Console.WriteLine("---------------------------------");

                        accountMenu(currentUser);

                    }
                    else
                    {
                        Console.WriteLine("(╯°□°)╯ Wrong pin number");
                        Console.ReadLine();
                        Console.WriteLine("Press any key to continue...");
                        MainMenu();
                    }
                }
                else
                {
                    Console.WriteLine("(╯°□°)╯ User not found");
                    Console.ReadLine();
                    Console.WriteLine("Press any key to continue...");
                    MainMenu();
                }

            }
        }

        public void signup()
        {
            Console.Clear();
            Console.WriteLine("Sign Up");
            Console.WriteLine("---------------------------------");

            User newUser = new User();

            Console.WriteLine("Select a username that you will use to log in");
            newUser.username = Console.ReadLine();

            Console.WriteLine("Please choose a pin");
            newUser.pin = Console.ReadLine();

            Console.WriteLine("Initial deposit ammount");
            string balance = Console.ReadLine();

            if (balance != null)
            {
                newUser.balance = Convert.ToDecimal(balance);
            }
            else
            {
                newUser.balance = 0;
            }

            if (newUser.username != null && newUser.pin != null)
            {
                Users.Add(newUser);
                Console.Clear();
                Console.WriteLine("Thanks for sigining up " + newUser.username + "!");
                Console.WriteLine("You will need to log in to access your account.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();

                MainMenu();
            }
            else
            {
                Console.WriteLine("(╯°□°)╯ Check your input and try again");
                signup();
            }

        }

    }

    public class Program
    {

        static void Main(string[] args)
        {

            Instance init = new Instance();

            Console.WriteLine("---------------------------------");
            Console.WriteLine("-------- Welcome ----------------");
            Console.WriteLine("-------- C# Bank App ------------");
            Console.WriteLine("-------- Author: Adam -----------");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            init.MainMenu();
        }
    }
}
