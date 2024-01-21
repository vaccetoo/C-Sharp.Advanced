
int nameLength = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string[], Predicate<string>> print = (array, match) =>
{
    foreach (string name in array)
    {
        if (match(name))
        {
            Console.WriteLine (name);
        }
    }
};

print(names, name => name.Length <= nameLength);