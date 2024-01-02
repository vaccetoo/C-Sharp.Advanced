
Stack<int> clothes 
    = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray()); // Clothes values

int rackCapacity = int.Parse(Console.ReadLine()); // Rack capacity - 100

int racksCounter = 1;

int currentRackCapacity = rackCapacity;

while (clothes.Any())
{
    int currentClothValue = clothes.Peek(); // 20

    if (currentRackCapacity - currentClothValue >= 0)
    {
        currentRackCapacity -= clothes.Pop();
        continue;
    }

    currentRackCapacity = rackCapacity;
    racksCounter++;
}

Console.WriteLine(racksCounter);