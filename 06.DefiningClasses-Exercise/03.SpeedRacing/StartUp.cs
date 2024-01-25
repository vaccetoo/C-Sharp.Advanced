
namespace SpeedRacing;

class StartUp
{
    public static void Main()
    {
        int carsCount = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();   

        for (int i = 0; i < carsCount; i++)
        {
            // "{model} {fuelAmount} {fuelConsumptionFor1km}"
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string model = carInfo[0];
            double fuelAmmount = double.Parse(carInfo[1]);
            double fuelConsumption = double.Parse(carInfo[2]);

            Car car = new Car(model, fuelAmmount, fuelConsumption);

            cars.Add(car);
        }

        string command = string.Empty;

        while ((command = Console.ReadLine()) != "End")
        {
            // Drive car
            string[] commandInfo = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string carModel = commandInfo[1];
            double distance = double.Parse(commandInfo[2]);

            foreach (Car car in cars.Where(m => m.Model == carModel))
            {
                car.Drive(distance);
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmmount:f2} {car.TravelledDistance}");
        }
    }
}