
int inputsCount = int.Parse(Console.ReadLine());

SortedSet<string> elements = new SortedSet<string>();

for (int i = 0; i < inputsCount; i++)
{
    string[] inputInfo = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    foreach (var element in inputInfo)
    {
        elements.Add(element);
    }
}

foreach (var element in elements)
{
    Console.Write(element + " ");
}