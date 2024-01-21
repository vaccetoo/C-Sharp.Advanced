
List<string> people = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string command = string.Empty;

while ((command = Console.ReadLine()) != "Party!")
{
    // Manipulate List<string> people

    string[] commandInfo = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    // Remove StartsWith P
    // Double Length 5

    string commandName = commandInfo[0];
    string condidition = commandInfo[1];
    string value = commandInfo[2];

    if (commandName == "Remove")
    {
        people.RemoveAll(GetPredicate(condidition, value));
    }
    else if (commandName == "Double")
    {
        List<string> peopleToDouble = people.FindAll(GetPredicate(condidition, value));

        foreach (var person in peopleToDouble)
        {
            int index = people.FindIndex(p => p == person);
            people.Insert(index, person);
        }
    }
}

if (people.Any())
{
    Console.Write($"{string.Join(", ", people)} ");
    Console.Write("are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}

Predicate<string> GetPredicate(string condition, string value)
{
    if (condition == "StartsWith")
    {
        return name => name.StartsWith(value);
    }
    else if (condition == "EndsWith")
    {
        return name => name.EndsWith(value);
    }
    else if (condition == "Length")
    {
        return name => name.Length == int.Parse(value);
    }

    return default;
}