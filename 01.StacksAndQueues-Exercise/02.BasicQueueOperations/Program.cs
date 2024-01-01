

int[] valueNumbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[] inputNumbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int elementsToPush = valueNumbers[0];
int elementsToPop = valueNumbers[1];
int checkForElement = valueNumbers[2];

Queue<int> queue =
    new Queue<int>(inputNumbers.Take(elementsToPush));

for (int i = 0; i < elementsToPop && queue.Any(); i++)
{
    queue.Dequeue();
}

if (queue.Contains(checkForElement))
{
    Console.WriteLine("true");
}
else if (queue.Count == 0)
{
    Console.WriteLine(0);
}
else if (!queue.Contains(checkForElement))
{
    Console.WriteLine(queue.Min());
}
