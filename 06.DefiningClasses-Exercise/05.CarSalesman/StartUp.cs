
using System.Drawing;

namespace CarSalesman;

class StartUp
{
    public static void Main()
    {
        int enginesCount = int.Parse(Console.ReadLine());

        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < enginesCount; i++)
        {
            string[] engineInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Engine engine = CreateEngine(engineInfo);
            engines.Add(engine);

        }


        int carsCount = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < carsCount; i++)
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = CreateCar(carInfo, engines);
            cars.Add(car);
        }

        foreach (Car car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }

    private static Car CreateCar(string[] carInfo, List<Engine> engines)
    {
        string carModel = carInfo[0];
        string engineModel = carInfo[1];

        if (carInfo.Length == 2)
        {
            Car car = new Car(carModel, engines.First(m => m.Model == engineModel));
            return car;
        }
        else if (carInfo.Length == 3)
        {
            if (int.TryParse(carInfo[2], out int result))
            {
                int wight = int.Parse(carInfo[2]);

                Car car = new Car(carModel, engines.First(m => m.Model == engineModel), wight);
                return car;
            }
            else
            {
                string color = carInfo[2];

                Car car = new Car(carModel, engines.First(m => m.Model == engineModel), color);
                return car;
            }
        }
        else
        {
            int weight = int.Parse(carInfo[2]);
            string color = carInfo[3];

            Car car = new Car(carModel, engines.First(m => m.Model == engineModel), weight, color);
            return car;
        }
    }

    private static Engine CreateEngine(string[] engineInfo)
    {
        string engineModel = engineInfo[0];
        int enginePower = int.Parse(engineInfo[1]);

        if (engineInfo.Length == 2)
        {
            Engine engine = new Engine(engineModel, enginePower);
            return engine;
        }
        else if (engineInfo.Length == 3)
        {
            if (int.TryParse(engineInfo[2], out int result))
            {
                int displacement = int.Parse(engineInfo[2]);

                Engine engine = new Engine(engineModel, enginePower, displacement);
                return engine;
            }
            else
            {
                string efficiency = engineInfo[2];

                Engine engine = new Engine(engineModel, enginePower, efficiency);
                return engine;
            }
        }
        else
        {
            int displacement = int.Parse(engineInfo[2]);
            string efficiency = engineInfo[3];

            Engine engine = new Engine(engineModel, enginePower, displacement, efficiency);
            return engine;
        }
    }
}
