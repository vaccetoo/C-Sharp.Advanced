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

        public int Count { get { return cars.Count; } }

        public int Capacity { get { return capacity; } set { capacity = value; } }

        public string AddCar(Car car)
        {
            // Check if the car already exist in the parking
            if (cars.Any(r => r.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count + 1 == Capacity) // Check if the parking is full
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car);

                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }


        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.Any(r => r.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.RemoveAll(r => r.RegistrationNumber == registrationNumber);

                return $"Successfully removed {registrationNumber}";
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

    }
}
