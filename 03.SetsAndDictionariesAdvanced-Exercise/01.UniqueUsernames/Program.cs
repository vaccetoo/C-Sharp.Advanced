
int inputNames = int.Parse(Console.ReadLine());

HashSet<string> uniqueNames = new HashSet<string>();

for (int i = 0; i < inputNames; i++)
{
    string currentName = Console.ReadLine();

    uniqueNames.Add(currentName);
}

foreach (string uniqueName in uniqueNames)
{
    Console.WriteLine(uniqueName);
}