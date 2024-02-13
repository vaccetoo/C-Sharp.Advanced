using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;

            Drinks = new List<Drink>();
        }

        public int ButtonCapacity { get; set; }

        public List<Drink> Drinks { get; set; }

        public int GetCount { get => Drinks.Count; }  
        
        public void AddDrink(Drink drink)
        {
            if (Drinks.Count < ButtonCapacity)
            {
                Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name)
        {
            if (Drinks.Any(n => n.Name == name))
            {
                Drinks.RemoveAll(n => n.Name == name);
                return true;
            }

            return false;
        }

        public Drink GetLongest()
        {
            return Drinks.OrderByDescending(v => v.Volume).First();
        }

        public Drink GetCheapest()
        {
            return Drinks.OrderBy(p => p.Price).First();
        }

        public string BuyDrink(string name)
        {
            return Drinks.First(n => n.Name == name).ToString();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Drinks available:");

            foreach (var drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
