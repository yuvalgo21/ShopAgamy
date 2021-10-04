using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopAgamy
{
    class Program
    {

        public static CustomerQueue qOutside = new CustomerQueue();
        public static List<CashRegister> allCashRegisters = new List<CashRegister>();
        public static List<Worker> allWorkers = new List<Worker>();
        static void Main()
        {
            Console.WriteLine("Welcome to AgamShop");
            int choise;
            do
            {
                // for 2-5 you need to strat at building the shop. press 8 for building;
                Console.WriteLine("For managing the queue outside please press 1\r\n" +
                    "For managing the cash register please press 2\r\n" +
                    "For inform Corona patient press 3\r\n" +
                    "For details of all cash register please press 4\r\n" +
                    "For start/stop working please press 5\r\n" +
                    "For end press 9");

                var choiseAsString = Console.ReadLine();
                while (!int.TryParse(choiseAsString, out choise))
                {
                    Console.WriteLine("Invalid input, please enter a number");
                    choiseAsString = Console.ReadLine();
                }
                choise = int.Parse(choiseAsString);
                switch (choise)
                {
                    case 1:
                        OutQueueManagement();
                        break;
                    case 2:
                        OutQueueManagement();
                        break;
                    case 3:
                        CoronaInform();
                        break;
                    case 4:
                        CashRegisterDetails();
                        break;
                    case 5:
                        CashierWorkShift();
                        break;
                    case 8:
                        BuildShop();
                        break;
                }
            }

            while (choise != 9);
            
        }

        // function that find the shortest queue.
        public static CashRegister FindSortestCashRegister(List<CashRegister> allLines)
        {
            CashRegister shortestCashRegister = allLines.First();
            foreach (CashRegister cashRegister in allLines)
            {
                if (shortestCashRegister.Line.getLength() > cashRegister.Line.getLength())
                {
                    shortestCashRegister = cashRegister;
                }
            }
            Console.WriteLine("Go to cash register " + shortestCashRegister.CashRegisterNumber);
            return shortestCashRegister;
        }

        // function that build the cash register in the shop.
        public static void BuildShop()
        {

            Console.WriteLine("We will strat of building the shop");
            Console.WriteLine("Please enter how many cash registers there is in the shop");
            var cashRegistersAsString = Console.ReadLine();
            int cashRegisters;
            while (!int.TryParse(cashRegistersAsString, out cashRegisters))
            {
                Console.WriteLine("Invalid input, please enter a number");
                cashRegistersAsString = Console.ReadLine();
            }
            cashRegisters = int.Parse(cashRegistersAsString);

            for (int i = 1; i <= cashRegisters; i++)
            {
                CustomerQueue tmp = new CustomerQueue();
                var w = Worker.createWorker();
                if (w != null)
                {
                    CashRegister cashRegister = new CashRegister(i, tmp, w);
                    allCashRegisters.Add(cashRegister);
                    cashRegister.allCeshirs(cashRegister.Cashier);
                    Console.WriteLine("You will work on cash register " + i);
                }
                else
                    i--;
                
            }


        }


        // function for worker to start or stop shift.
        public static void CashierWorkShift()
        {
            Console.WriteLine("For start working press 1, for finsh press 2.\nFor go back to the menu press 0");
            var workerChoiseAsString = Console.ReadLine();
            int workerChoise;
            while (!int.TryParse(workerChoiseAsString, out workerChoise))
            {
                Console.WriteLine("Invalid input, please enter a number");
                workerChoiseAsString = Console.ReadLine();
            }
            workerChoise = int.Parse(workerChoiseAsString);
            if (workerChoise == 0)
                return;
            bool isWorker = false;
            Console.WriteLine("Enter your full name");
            string workerName = Console.ReadLine();
            if (workerChoise == 1)
            {
                foreach (Worker w in allWorkers)
                {
                    if (workerName == w.FullName)
                    {
                        w.startWorking();
                        isWorker = true;
                    }
                        
                    

                }
            }
            if (workerChoise == 2)
            {
                foreach (Worker w in allWorkers)
                {
                    if (workerName == w.FullName)
                    {
                        w.endWorking();
                        isWorker = true;
                    }
                        
                }
            }
            if (!isWorker)
                Console.WriteLine("Please enter exact name as in your registration form");

        }

        // function for printing details of cash register.
        public static void CashRegisterDetails()
        {
            foreach (CashRegister cashRegister in allCashRegisters)
            {
                Console.WriteLine("In cash register number " + cashRegister.CashRegisterNumber + " the cashiers was:");
                cashRegister.PrintallCesheirs();

            }
        }

        // function for inform a covid patient.
        public static void CoronaInform()
        {
            Console.WriteLine("please enter your full name");
            string positiveCustomer = Console.ReadLine();
            Console.WriteLine("please enter the numer of the cash register that serve you");
            var positiveCashRegisterNumberAsString = Console.ReadLine();
            int positiveCashRegisterNumber;
            while (!int.TryParse(positiveCashRegisterNumberAsString, out positiveCashRegisterNumber))
            {
                Console.WriteLine("Invalid input, please enter a number");
                positiveCashRegisterNumberAsString = Console.ReadLine();
            }
            positiveCashRegisterNumber = int.Parse(positiveCashRegisterNumberAsString);

            foreach (CashRegister cashRegister in allCashRegisters)
            {
                if (cashRegister.CashRegisterNumber == positiveCashRegisterNumber)
                {
                    Worker w = cashRegister.Cashier;
                    foreach (Customer c in w.getMyCustomers())
                    {
                        if (positiveCustomer == c.FullName)
                            break;
                        Console.WriteLine(c.FullName + " I am sorry you need to get into isolation ");
                        c.IsIsolated = true;
                    }
                }
            }
        }

        // function for managing the cash register.
        public static void CashRegisterManaging()
        {
            Console.WriteLine("For printing documentation please enter cash register number \n (for getting back to menu prees 0) ");
            var cashRegisternumberAsString = Console.ReadLine();
            int cashRegisternumber;
            while (!int.TryParse(cashRegisternumberAsString, out cashRegisternumber))
            {
                Console.WriteLine("Invalid input, please enter a number");
                cashRegisternumberAsString = Console.ReadLine();
            }
            cashRegisternumber = int.Parse(cashRegisternumberAsString);
            if (cashRegisternumber != 0)
            {
                foreach (CashRegister cashRegister in allCashRegisters)
                {
                    if (cashRegister.CashRegisterNumber == cashRegisternumber)
                    {
                        cashRegister.Documentation();
                        cashRegister.PrintallCesheirs();
                    }
                }
            }

        }

        // function for managing the the queue outside/
        public static void OutQueueManagement()
        {
            Char answer;
            do
            {
                Console.WriteLine("For add someone to the queue please enter A.\n" +
                    "For enter people to the shop please enter E.\n" +
                    "For print the names of the people who wait please enter P.\n" +
                    "For back to menu please enter S ");
                answer = Console.ReadLine().ToUpper()[0];
                while (answer != 'A' && answer != 'P' && answer != 'E' && answer != 'S')
                {
                    Console.WriteLine("Invalid input, please try again");
                    answer = Console.ReadLine().ToUpper()[0];
                }
                if (answer == 'A')
                {
                    Person p = Person.cratePerson();
                    if (p != null && p.BodyTemp < 38)
                    {
                        Customer c = Customer.CreateCustomer(p);
                        if (c != null)
                        {
                            qOutside.AddCustomer(c);
                            continue;

                        }
                        else
                        {
                            Console.WriteLine("Sorry, you can't enter the shop");
                            continue;
                        }
                    }
                    else
                    {
                        if (p.BodyTemp >= 38)
                        {
                            Console.WriteLine("Sorry, you can't enter the shop");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, somthing go worng please try again");
                            continue;

                        }
                    }

                }
                if (answer == 'E')
                {
                    Console.WriteLine("How many people to you want to enter?");
                    var nunumberOfPasString = Console.ReadLine();
                    int numberOfP;
                    while (!int.TryParse(nunumberOfPasString, out numberOfP))
                    {
                        Console.WriteLine("Invalid input, please enter a number");
                        nunumberOfPasString = Console.ReadLine();
                    }
                    numberOfP = int.Parse(nunumberOfPasString);
                    for (int i = 0; i < numberOfP; ++i)
                    {
                        Customer firstCustomer = qOutside.GetFirstCustomer();
                        Console.WriteLine("Hi " + firstCustomer.FullName + " you can enter the shop now :)");
                        // Sopping time
                        // Sopping time
                        CashRegister shortestQueue = FindSortestCashRegister(allCashRegisters);
                        shortestQueue.AddCustomer(firstCustomer);
                    }

                }
                if (answer == 'P')
                {
                    Console.WriteLine("The names of the people that on the queue are:");
                    qOutside.printAllCustomer();

                }



            }
            while (answer != 'S');

        }

    }
}



