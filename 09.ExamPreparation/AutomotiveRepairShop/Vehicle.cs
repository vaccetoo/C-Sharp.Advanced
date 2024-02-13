﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveRepairShop
{
    public class Vehicle
    {
        public Vehicle(string vin, int mileage, string damage)
        {
            VIN = vin;
            Mileage = mileage;
            Damage = damage;
        }

        public string VIN { get; set; }

        public int Mileage { get; set; }

        public string Damage { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Damage: {Damage}, Vehicle: {VIN} ({Mileage} km)");

            return sb.ToString().TrimEnd();
        }
    }
}
