
int numberOfCommands = int.Parse(Console.ReadLine());

Stack<int> numbers = new Stack<int>();

for (int i = 0; i < numberOfCommands; i++)
{
    string[] commandInfo = Console.ReadLine()
        .Split();

    string commandName = commandInfo[0];

    if (commandName == "1")
    {
        int numberToPush = int.Parse(commandInfo[1]);

        numbers.Push(numberToPush);
    }
    else if (commandName == "2" && numbers.Any())
    {
        numbers.Pop();
    }
    else if (commandName == "3" && numbers.Any())
    {
        Console.WriteLine(numbers.Max());
    }
    else if (commandName == "4" && numbers.Any())
    {
        Console.WriteLine(numbers.Min());
    }
}

Console.WriteLine(string.Join(", ", numbers));
