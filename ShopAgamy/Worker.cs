using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAgamy
{
    // building worker.
    class Worker : Customer
    {

        private Stack<Customer> _allMyCustomers;
        private List<String> _shifts;
        private string _startShift;
        private string _endShift;


        private Worker(Customer c) : base(c)
        {

            _allMyCustomers = new Stack<Customer>();
            _shifts = new List<string>();
        }

        public static Worker createWorker()
        {
            Console.WriteLine("New Worker registration:\n");
            var newWorker = Customer.CreateCustomer(Person.cratePerson());
            if (newWorker != null)
            {
                return new Worker(newWorker);
            }

            else
            {
                Console.WriteLine("Sorry, you can't get in to the store and you been fined buy 80 minutes of work\n");
                return null;
            }

        }

        // return all the customers that the worker served.
        public Stack<Customer> getMyCustomers()
        {
            return _allMyCustomers;
        }

        public void addCustomer(Customer c)
        {
            _allMyCustomers.Push(c);
        }

        public void startWorking()
        {
            _startShift = DateTimeOffset.Now.ToString("g");


        }
        public void endWorking()
        {
            _endShift = DateTimeOffset.Now.ToString("g");
            string workShift = "Strat Time: " + _startShift + "\nEnd time: " + _endShift;
            _shifts.Add(workShift);
            Console.WriteLine(workShift);
        }





    }
}

