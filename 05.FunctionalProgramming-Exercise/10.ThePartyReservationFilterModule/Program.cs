
Dictionary<string, Predicate<string>> filters = new();

List<string> people = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string command = string.Empty;

while ((command = Console.ReadLine()) != "Print")
{
    string[] commandInfo = command
        .Split(";", StringSplitOptions.RemoveEmptyEntries);

    string action = commandInfo[0];
    string filter = commandInfo[1];
    string value = commandInfo[2];

    if (action == "Add filter")
    {
        if (!filters.ContainsKey(filter + value))
        {
            filters.Add(filter + value, GetPredicate(filter, value));
        }
    }
    else
    {
        filters.Remove(filter + value); 
    }
}

foreach (var filter in filters)
{
    people.RemoveAll(filter.Value);
}

Console.WriteLine(string.Join(" ", people));

Predicate<string> GetPredicate(string filter, string value)
{
    if (filter == "Starts with")
    {
        return name => name.StartsWith(value);
    }
    else if (filter == "Ends with")
    {
        return name => name.EndsWith(value);
    }
    else if (filter == "Length")
    {
        return name => name.Length == int.Parse(value);
    }
    else if(filter == "Contains")
    {
        return name => name.Contains(value);
    }

    return default;
}