
using System.Text;

int[] fuelSequence = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] consumptionIndexes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] quantitiesSequence = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> fuels = new Stack<int>(fuelSequence);

Queue<int> consumptions = new Queue<int>(consumptionIndexes);

Queue<int> quantities = new Queue<int>(quantitiesSequence);

int counter = 0;

while (fuels.Any())
{
    int result = fuels.Peek() - consumptions.Peek();

    if (result >= quantities.Peek())
    {
        counter++;
        fuels.Pop();
        consumptions.Dequeue();
        quantities.Dequeue();

        Console.WriteLine($"John has reached: Altitude {counter}");
    }
    else
    {
        Console.WriteLine($"John did not reach: Altitude {counter + 1}");
        break;
    }

    if (!quantities.Any())
    {
        Console.WriteLine($"John has reached all the altitudes and managed to reach the top!");
    }
}

if (quantities.Any() && counter != 0)
{
    Console.WriteLine("John failed to reach the top.");

    StringBuilder sb = new StringBuilder();
    sb.Append($"Reached altitudes: ");

    for (int i = 1; i <= counter; i++)
    {
        sb.Append($"Altitude {i}, ");
    }

    Console.WriteLine(sb.ToString().TrimEnd(',', ' '));
}

if (counter == 0)
{
    Console.WriteLine("John failed to reach the top.");
    Console.WriteLine($"John didn't reach any altitude.");
}