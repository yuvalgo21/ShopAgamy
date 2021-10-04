using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAgamy
{
    // building queue of customers.
    class CustomerQueue
    {
        private Queue<Customer> _customerQueue;

        public CustomerQueue()
        {
            _customerQueue = new Queue<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            _customerQueue.Enqueue(customer);
            Console.WriteLine("Thank you :) ");
        }
        public Customer GetFirstCustomer()
        {
            Customer _firstCustomer;
            _firstCustomer = _customerQueue.Dequeue();
            return _firstCustomer;
        }
        public int getLength()
        {
            return _customerQueue.Count();
        }
        public void printAllCustomer()
        {
            foreach (Customer customer in _customerQueue)
            {
                Console.WriteLine(customer.FullName);
            }
        }
    }
}

