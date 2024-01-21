
HashSet<int> inputNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToHashSet();

Func<HashSet<int>, int> min = setNumbers =>
{
    int minNumber = int.MaxValue;

    foreach (var number in setNumbers)
    {
        if (number < minNumber)
        {
            minNumber = number;
        }
    }

    return minNumber;
};

Console.WriteLine(min(inputNumbers));