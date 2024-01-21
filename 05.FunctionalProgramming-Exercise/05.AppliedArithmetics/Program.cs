
List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

string command = string.Empty;

Action<List<int>> print = array =>
{
    Console.WriteLine(string.Join(" ", array));
};

Func<string, List<int>, List<int>> manipulateArray = (command, array) =>
{ 
    List<int> returnArray = new List<int>();

    if (command == "add")
    {
        for (int i = 0; i < array.Count; i++)
        {
            returnArray.Add(array[i] + 1);  
        }
    }
    else if (command == "multiply")
    {
        for (int i = 0; i < array.Count; i++)
        {
            returnArray.Add(array[i] * 2);
        }
    }
    else if (command == "subtract")
    {
        for (int i = 0; i < array.Count; i++)
        {
            returnArray.Add(array[i] - 1);
        }
    }

    return returnArray;
};

while ((command = Console.ReadLine()) != "end")
{
    if (command == "print")
    {
        print(numbers);
        continue;
    }

    numbers = manipulateArray(command, numbers);
}