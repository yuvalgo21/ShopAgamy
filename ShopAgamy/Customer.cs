using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAgamy
{
    // building customer.
    class Customer : Person
    {
        private bool _havemask;
        private bool _isIsolated;
        private List<Product> _products;

        private Customer(Person p, bool havemask, bool isIsolated) : base(p)
        {
            Havemask = havemask;
            IsIsolated = isIsolated;
        }
        protected Customer(Customer c) : base((Person)c)
        {
            Havemask = c.Havemask;
            IsIsolated = c.IsIsolated;
        }

        public bool Havemask { get => _havemask; set => _havemask = value; }
        public bool IsIsolated { get => _isIsolated; set => _isIsolated = value; }
        internal List<Product> Products { get => _products; set => _products = value; }

        public static Customer CreateCustomer(Person p)
        {

            Console.WriteLine("Hi " + p.FullName + " do you hava mask? please Y for yes, N for No");
            char answer = Console.ReadLine().ToUpper()[0];
            while (answer != 'Y' && answer != 'N')
            {
                Console.WriteLine("Invalid input, do you hava mask? please Y for yes, N for No");
                answer = Console.ReadLine().ToUpper()[0];
            }
            if (answer == 'Y')
            {
                Console.WriteLine("Do you hava need to be isolate? please Y for yes, N for No");
                answer = Console.ReadLine().ToUpper()[0];
                while (answer != 'Y' && answer != 'N')
                {
                    Console.WriteLine("Invalid input, do you hava mask? please Y for yes, N for No");
                    answer = Console.ReadLine().ToUpper()[0];
                }
                if (answer == 'N')
                {
                    if (p.BodyTemp < 38.0)
                        return new Customer(p, true, true);
                }


            }
            return null;
        }

        //building a list of all the products that the customer bought 
        public List<Product> listOfProducts()
        {
            Console.WriteLine("How many products do you have");
            var numberOfPAsString = Console.ReadLine();
            int numberOfP;
            while (!int.TryParse(numberOfPAsString, out numberOfP))
            {
                Console.WriteLine("Invalid input, please enter a number");
                numberOfPAsString = Console.ReadLine();
            }
            numberOfP = int.Parse(numberOfPAsString);

            List<Product> listOfProducts = new List<Product>();
            for (int i = 1; i <= numberOfP; i++)
            {
                Product p = Product.CreateProductMenu();
                listOfProducts.Add(p);
            }
            return listOfProducts;
        }

    }
}

