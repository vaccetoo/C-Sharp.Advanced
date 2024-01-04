
int greenLightDuration = int.Parse(Console.ReadLine());
int freeWindowDuration = int.Parse(Console.ReadLine());

string command = string.Empty;

Queue<string> cars = new Queue<string>();

int passedCars = 0;

int currentGreenDuration = greenLightDuration;

bool isCrashHappend = false;

while ((command = Console.ReadLine()) != "END")
{
    if (command != "green") // We recive car 
    {
        cars.Enqueue(command);
        continue;
    }

    // The command "green" indicates the start of a green light cycle

    currentGreenDuration = greenLightDuration;

    while (cars.Any() && currentGreenDuration > 0)
    {
        string currentCar = cars.Peek();

        if (currentGreenDuration - currentCar.Length >= 0)
        {
            currentGreenDuration -= currentCar.Length;
            cars.Dequeue();
            passedCars++;
        }
        else if (currentGreenDuration + freeWindowDuration - currentCar.Length >= 0)
        {
            currentGreenDuration = 0;
            cars.Dequeue();
            passedCars++;
        }
        else
        {
            char crashedIndex = currentCar[currentGreenDuration + freeWindowDuration];
            Console.WriteLine("A crash happened!");
            Console.WriteLine($"{currentCar} was hit at {crashedIndex}.");

            isCrashHappend = true;
            break;
        }
    }

    if (isCrashHappend)
    {
        break;
    }
}

if (command == "END")
{
    Console.WriteLine("Everyone is safe.");
    Console.WriteLine($"{passedCars} total cars passed the crossroads.");
}