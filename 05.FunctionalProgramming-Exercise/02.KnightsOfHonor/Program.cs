
using System.Threading.Channels;

string[] inputNames = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string, string[]> printTitleNames = (title, array) =>
{
    foreach (var name in array)
    {
        Console.WriteLine($"{title} {name}");
    }
};

printTitleNames("Sir", inputNames);