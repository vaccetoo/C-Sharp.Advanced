
int petrolPumpsCount = int.Parse(Console.ReadLine());

Queue<int[]> pumps = new Queue<int[]>();

for (int i = 0; i < petrolPumpsCount; i++)
{
    int[] currentPumpInfo = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

    int liters = currentPumpInfo[0];
    int kilometers = currentPumpInfo[1];

    pumps.Enqueue(currentPumpInfo);
}

int bestRoute = 0;

while (true)
{
    int totalPetrol = 0;

    foreach (int[] pump in pumps)
    {
        totalPetrol += pump[0];
        int currentKilometers = pump[1];

        if (totalPetrol - currentKilometers < 0)
        {
            totalPetrol = 0;
            break;
        }
        else
        {
            totalPetrol -= currentKilometers;
        }
    }

    if (totalPetrol > 0)
    {
        break;
    }

    bestRoute++;
    pumps.Enqueue(pumps.Dequeue());
}

Console.WriteLine(bestRoute);