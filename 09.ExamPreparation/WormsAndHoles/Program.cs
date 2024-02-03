
int[] wormsSizes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] holeSizes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> worms = new Stack<int>(wormsSizes);
Queue<int> holes = new Queue<int>(holeSizes);

int matchesCount = 0;

int deadWorms = 0;

while (worms.Any() && holes.Any())
{
    int currentWorm = worms.Peek();
    int currentHole = holes.Peek();

    if (currentWorm == currentHole)
    {
        matchesCount++;

        worms.Pop();
        holes.Dequeue();
    }
    else
    {
        holes.Dequeue();

        int wormNewValue = worms.Peek() - 3;
        worms.Pop();
        worms.Push(wormNewValue);

        if (worms.Peek() <= 0)
        {
            worms.Pop();

            deadWorms++;
        }
    }
}

if (matchesCount > 0)
{
    Console.WriteLine($"Matches: {matchesCount}");
}
else
{
    Console.WriteLine($"There are no matches.");
}

if (!worms.Any() && deadWorms == 0)
{
    Console.WriteLine("Every worm found a suitable hole!");
}
else if (!worms.Any() && deadWorms > 0)
{
    Console.WriteLine("Worms left: none");
}
else if (worms.Any())
{
    Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
}

if (!holes.Any())
{
    Console.WriteLine($"Holes left: none");
}
else
{
    Console.WriteLine($"Holes left: {string.Join(", ", holes)}");
}