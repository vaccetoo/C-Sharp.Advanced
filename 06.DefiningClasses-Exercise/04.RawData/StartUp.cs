
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace RawData;

class StartUp
{
    public static void Main()
    {
        int numberOfCars = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < numberOfCars; i++)
        {
            // "{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"

            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string model = carInfo[0];
            int engineSpeed = int.Parse(carInfo[1]);
            int enginePower = int.Parse(carInfo[2]);
            int cargoWeight = int.Parse(carInfo[3]);
            string cargoType = carInfo[4];
            string[] tiresInfo = carInfo.Skip(5).ToArray();

            List<Tire> tires = new List<Tire>();

            for (int j = 0; j < tiresInfo.Length; j+=2)
            {
                if (j % 2 == 0)
                {
                    double pressure = double.Parse(tiresInfo[j]);
                    int age = int.Parse(tiresInfo[j+1]);

                    Tire tire = new Tire(age, pressure);
                    tires.Add(tire);
                }
            }

            Engine engine = new Engine(engineSpeed, enginePower);

            Cargo cargo = new Cargo(cargoType, cargoWeight);

            Car car = new Car(model, engine, cargo, tires.ToArray());
            cars.Add(car);
        }

        string typeOfCargo = Console.ReadLine();

        PrindCars(typeOfCargo, cars);

        void PrindCars(string type, List<Car> cars)
        {
            if (type == "fragile")
            {
                foreach (var car in cars.Where(car => car.Cargo.Type == "fragile" && car.Tires.Any(p => p.Pressure <= 1)))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else if (type == "flammable")
            {
                foreach (var car in cars.Where(car => car.Cargo.Type == "flammable" && car.Engine.Power > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }
    }
}