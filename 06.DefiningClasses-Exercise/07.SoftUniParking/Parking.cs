using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;

        private int capacity;

        public Parking(int capacity)
        {
            Capacity = capacity;
            cars = new List<Car>();
        }

        public int Capacity { get { return capacity; } set { capacity = value; } }

        public void AddCar(Car car)
        {
            // Check if the car already exist in the parking
            if (cars.Any(r => r.RegistrationNumber == car.RegistrationNumber))
            {
                Console.WriteLine("Car with that registration number, already exists!");
            }
            else if (cars.Count + 1 == Capacity) // Check if the parking is full
            {
                Console.WriteLine("Parking is full!");
            }
            else
            {
                cars.Add(car);

                Console.WriteLine($"Successfully added new car {car.Make} {car.RegistrationNumber}");
            }


        }

        public void RemoveCar(string registrationNumber)
        {
            if (!cars.Any(r => r.RegistrationNumber == registrationNumber))
            {
                Console.WriteLine("Car with that registration number, doesn't exist!");
            }
            else
            {
                cars.RemoveAll(r => r.RegistrationNumber == registrationNumber);

                Console.WriteLine($"Successfully removed {registrationNumber}");
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.First(r => r.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                if (cars.Any(r => r.RegistrationNumber == registrationNumber))
                {
                    cars.RemoveAll(r => r.RegistrationNumber == registrationNumber);
                }
            }
        }

        public int Count()
        {
            return cars.Count;
        }
    }
}
