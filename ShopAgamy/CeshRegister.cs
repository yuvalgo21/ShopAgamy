using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAgamy
{

    // building a cash register.
    class CashRegister
    {
        private int _cashRegisterNumber;
        private Worker _cashier;
        private CustomerQueue _line;
        private List<List<Product>> _products;
        private List<Customer> _customers;
        private List<string> _allCeshirs;

        public CashRegister(int cashRegisterNumber, CustomerQueue line, Worker cashier)
        {
            CashRegisterNumber = cashRegisterNumber;
            Line = line;
            Cashier = cashier;
            _products = new List<List<Product>>();
            _customers = new List<Customer>();
            _allCeshirs = new List<string>();

        }
        public int CashRegisterNumber { get => _cashRegisterNumber; set => _cashRegisterNumber = value; }
        internal CustomerQueue Line { get => _line; set => _line = value; }
        internal Worker Cashier { get => _cashier; set => _cashier = value; }



        public void AddCustomer(Customer c)
        {
            addProducts(c);
            _line.AddCustomer(c);
            _cashier.addCustomer(c);
            _customers.Add(c);

        }

        private void addProducts(Customer c)
        {
            _products.Add(c.listOfProducts());
        }

        // print all the customers and the products at the cash register.
        public void Documentation()
        {
            Console.WriteLine("Printing custumers that bought in that cashier position: ");
            foreach (Customer c in _customers)
                Console.WriteLine(c.FullName);
            Console.WriteLine("Printing products that bought in that cashier position: ");
            foreach (List<Product> productList in _products)
                foreach (Product product in productList)
                    Console.WriteLine(product.ProdactName);

        }
        
        public void allCeshirs(Worker w)
        {
            string time = DateTimeOffset.Now.ToString("g");
            
            _allCeshirs.Add(w.FullName + " " + time);

        }

        // print all the cesheirs that work at the cash register
        public void PrintallCesheirs()
        {
            Console.WriteLine("The casheirs at this cashier position are:");
            foreach (string cashirAndTime in _allCeshirs)
                Console.WriteLine(cashirAndTime);
        }
    }

}

