
int[] textilesArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] medicamentsArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> textiles = new Queue<int>(textilesArray);
Stack<int> medicaments = new Stack<int>(medicamentsArray);

Dictionary<string, int> items = new Dictionary<string, int>
{
    {"Patch", 0},
    {"Bandage", 0},
    {"MedKit", 0 }
};

while (textiles.Any() && medicaments.Any())
{
    int currentComboSum = textiles.Peek() + medicaments.Peek();

    if (currentComboSum == 30)
    {
        items["Patch"]++;
        textiles.Dequeue();
        medicaments.Pop();
    }
    else if (currentComboSum == 40)
    {
        items["Bandage"]++;
        textiles.Dequeue();
        medicaments.Pop();
    }
    else if (currentComboSum == 100)
    {
        items["MedKit"]++;
        textiles.Dequeue();
        medicaments.Pop();
    }
    else if (currentComboSum > 100)
    {
        items["MedKit"]++;

        int remainingResource = currentComboSum - 100;
        textiles.Dequeue();
        medicaments.Pop();
        medicaments.Push(medicaments.Pop() + remainingResource);
    }
    else
    {
        textiles.Dequeue();
        medicaments.Push(medicaments.Pop() + 10);
    }
}

if (!textiles.Any() && !medicaments.Any())
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}
else if (!textiles.Any())
{
    Console.WriteLine("Textiles are empty.");
}
else if (!medicaments.Any())
{
    Console.WriteLine("Medicaments are empty.");
}

foreach (var item in items.OrderByDescending(amount => amount.Value).ThenBy(name => name.Key))
{
    if (item.Value > 0)
    {
        Console.WriteLine($"{item.Key} - {item.Value}");
    }
}

if (medicaments.Any())
{
    Console.Write($"Medicaments left: ");
    Console.Write(string.Join(", ", medicaments));
    Console.WriteLine();
}

if (textiles.Any())
{
    Console.Write($"Textiles left: ");
    Console.Write(string.Join(", ", textiles));
    Console.WriteLine();
}