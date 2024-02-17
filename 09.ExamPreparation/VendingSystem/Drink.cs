﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingSystem
{
    public class Drink
    {
        public Drink(string name, decimal price, int volume)
        {
            Name = name;
            Price = price;
            Volume = volume;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Volume { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}, Price: ${Price}, Volume: {Volume} ml");

            return sb.ToString().TrimEnd();
        }
    }
}