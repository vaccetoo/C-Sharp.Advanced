using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public GroceriesStore(int capacity)
        {
            Stall = new List<Product>();
            Capacity = capacity;
            Turnover = 0;
        }

        public List<Product> Stall { get; set; }

        public int Capacity { get; set; }

        public double Turnover { get; set; }

        public void AddProduct(Product product)
        {
            if (Stall.Contains(product))
            {
                return;
            }
            else if (Stall.Count() < Capacity)
            {
                Stall.Add(product);
            }
        }

        public bool RemoveProduct(string name)
        {
            if (Stall.Any(n => n.Name == name))
            {
                Stall.RemoveAll(n => n.Name == name);
                return true;
            }

            return false;
        }

        public string SellProduct(string name, double quantity)
        {
            if (Stall.Any(n => n.Name == name))
            {
                double profit = Stall.First(n => n.Name == name).Price * quantity;

                Turnover += profit;

                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"{name} - {profit:f2}$");

                return sb.ToString().TrimEnd();
            }

            return "Product not found";
        }

        public string GetMostExpensive()
        {
            return Stall.OrderByDescending(p => p.Price).First().ToString();
        }

        public string CashReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Total Turnover: {Turnover:f2}$");

            return sb.ToString().TrimEnd();
        }

        public string PriceList()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Groceries Price List: ");
            foreach (var product in Stall)
            {
                sb.AppendLine($"{product.Name}: {product.Price:f2}$");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
