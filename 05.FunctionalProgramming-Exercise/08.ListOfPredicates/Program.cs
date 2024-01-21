
Func<int, List<int>> generateNumbers = range =>
{
    List<int> numbers = new List<int>();

    for (int i = 1; i <= range; i++)
    {
        numbers.Add(i);
    }

    return numbers;
};

Func<List<int>, List<int>, List<int>> exclude = (numbers, dividers) =>
{
    List<int> result = new List<int>();

    foreach (var number in numbers)
    {
        int count = 0;

        for (int i = 0; i < dividers.Count; i++)
        {
            if (number % dividers[i] == 0)
            {
                count++;
            }
        }

        if (count == dividers.Count)
        {
            result.Add(number);
        }
    }

    return result;
};

int range = int.Parse(Console.ReadLine());

List<int> dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

List<int> numbers = generateNumbers(range);

List<int> divisibleNumbers = exclude(numbers, dividers);

Console.WriteLine(string.Join(" ", divisibleNumbers));
