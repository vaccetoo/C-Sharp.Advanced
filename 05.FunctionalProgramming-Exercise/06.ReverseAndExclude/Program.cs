
List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int divider = int.Parse(Console.ReadLine());

// return numbers which are not divisible by the given divider
Func<List<int>, int, List<int>> exclude = (list, divider) =>
{
    // numbers in reversed order
    Stack<int> stack = new Stack<int>();

    foreach (var number in list)
    {
        if (number % divider != 0)
        {
            stack.Push(number);
        }
    }

    return stack.ToList();
};

List<int> notDivisibleNumbers =  exclude(numbers, divider);

Console.WriteLine(string.Join(" ", notDivisibleNumbers));