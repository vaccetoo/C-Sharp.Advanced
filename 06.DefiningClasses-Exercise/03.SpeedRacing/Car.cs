using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    public class Car
    {
        public Car()
        {
            TravelledDistance = 0;
        }

        public Car(string model, double fuelAmmount, double fuelConsumptionPerKilometer) : this()
        {
            Model = model;
            FuelAmmount = fuelAmmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }


        public string Model { get; set; }

        public double FuelAmmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; } 

        
        public void Drive(double distance)
        {
            double neededFuel = FuelConsumptionPerKilometer * distance;
            if (neededFuel <= FuelAmmount)
            {
                FuelAmmount -= neededFuel;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

    }
}
