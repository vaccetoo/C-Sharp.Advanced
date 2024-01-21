
int[] arrayRange = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int start = arrayRange[0];
int end = arrayRange[1];

Func<int, int, int[]> generateArray = (int start, int end) =>
{
    List<int> array = new List<int>();

    for (int i = start; i <= end; i++)
    {
        array.Add(i);
    }

    return array.ToArray();
};

int[] numbers = generateArray(start, end);

string condition = Console.ReadLine(); // odd OR even

Func<string, int, bool> isEvenOrOdd = (condition, number) =>
{
    if (condition == "even")
    {
        return number % 2 == 0;
    }
    else
    {
        return number % 2 != 0;
    }
};

foreach (var number in numbers)
{
    if (isEvenOrOdd(condition, number))
    {
        Console.Write($"{number} ");
    }
}