using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAgamy
{
    // building Product.
    class Product
    {
        private string _prodactName;
        private double _prodactPrice;

        public Product(string prodactName, double prodactPrice)
        {

            ProdactPrice = prodactPrice;
            ProdactName = prodactName;

        }

        public static Product CreateProductMenu()
        {
            Console.WriteLine("please enter product name:");
            var prodactName = Console.ReadLine();
            while (string.IsNullOrEmpty(prodactName))
            {
                Console.WriteLine("Invalid input, please enter your full name");
                prodactName = Console.ReadLine();
            }
            Console.WriteLine("please enter product price:");
            var prodactPricAsString = Console.ReadLine();
            double prodactPric;
            while (!double.TryParse(prodactPricAsString, out prodactPric))
            {
                Console.WriteLine("Invalid input, please enter a price");
                prodactPricAsString = Console.ReadLine();
            }
            prodactPric = double.Parse(prodactPricAsString);

            Product p = new Product(prodactName, prodactPric);
            return p;
        }

        public string ProdactName { get => _prodactName; set => _prodactName = value; }
        public double ProdactPrice { get => _prodactPrice; set => _prodactPrice = value; }
    }
}

