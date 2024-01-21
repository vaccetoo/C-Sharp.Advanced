
Func<string, int, bool> isBiggerOrEqual = (name, n) =>
{
    int charSum = 0;

    for (int i = 0; i < name.Length; i++)
    {
        charSum += name[i];
    }

    return charSum >= n;
};

int n = int.Parse(Console.ReadLine());

List<string> names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

Console.WriteLine(names.FirstOrDefault(x => isBiggerOrEqual(x, n)));

//foreach (var name in names)
//{
//    if (isBiggerOrEqual(name, n))
//    {
//        Console.WriteLine(name);
//        break;
//    }
//}