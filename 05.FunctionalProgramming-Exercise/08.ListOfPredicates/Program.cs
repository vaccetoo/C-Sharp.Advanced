
List<Predicate<int>> predicates = new List<Predicate<int>> ();

int endRange = int.Parse(Console.ReadLine());

int[] numbers = Enumerable.Range(1, endRange).ToArray();

HashSet<int> dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToHashSet();

foreach (var divider in dividers)
{
    predicates.Add(number => number % divider == 0);
}

foreach (var number in numbers)
{
    bool isDivisible = true;

    foreach (var match in predicates)
    {
        if (!match(number))
        {
            isDivisible = false; 
            break;
        }
    }

    if (isDivisible)
    {
        Console.Write($"{number} ");
    }
}