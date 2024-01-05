
int[] cupsCapacity = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[] bottlesLiquid = Console.ReadLine() // Liters, ml. ...
    .Split()
    .Select(int.Parse)
    .ToArray();

Queue<int> cups = new Queue<int>(cupsCapacity);

Stack<int> bottles = new Stack<int>(bottlesLiquid);

int wastedWater = 0;

int currentBottle = 0;
int currentCup = 0;

bool isEnoughWater = false;

currentBottle = bottles.Peek();
currentCup = cups.Peek();

while (cups.Any() && bottles.Any())
{
    if (isEnoughWater)
    {
        currentBottle = bottles.Peek();
        currentCup = cups.Peek();
    }

    if (currentBottle - currentCup == 0)
    {
        cups.Dequeue();
        bottles.Pop();
        isEnoughWater = true;
    }
    else if (currentBottle - currentCup > 0)
    {
        wastedWater += (currentBottle - currentCup);
        bottles.Pop();
        cups.Dequeue();
        isEnoughWater = true;
    }
    else if (currentBottle - currentCup < 0)
    {
        bottles.Pop();
        currentCup -= currentBottle;
        currentBottle = bottles.Peek();
        isEnoughWater = false;
    }
}

if (!cups.Any() && bottles.Any())
{
    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
}
else
{
    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
}

Console.WriteLine($"Wasted litters of water: {wastedWater}");