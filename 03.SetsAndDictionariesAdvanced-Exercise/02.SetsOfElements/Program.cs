
int[] setsLengths = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int firstSetLength = setsLengths[0];
int secondSetLength = setsLengths[1];

HashSet<int> firstSet = new HashSet<int>();
HashSet<int> secondSet = new HashSet<int>();

for (int i = 0; i < firstSetLength; i++)
{
    int number = int.Parse(Console.ReadLine());

    firstSet.Add(number);
}

for (int i = 0; i < secondSetLength; i++)
{
    int number = int.Parse(Console.ReadLine());

    secondSet.Add(number);
}

if (firstSet.Count > secondSet.Count)
{
    foreach (var number in secondSet)
    {
        if (firstSet.Contains(number))
        {
            Console.Write(number + " ");
        }
    }
}
else
{
    foreach (var number in firstSet)
    {
        if (secondSet.Contains(number))
        {
            Console.Write(number + " ");
        }
    }
}