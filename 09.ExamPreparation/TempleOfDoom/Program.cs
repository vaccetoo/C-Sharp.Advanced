
int[] tools = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] substances = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

List<int> challenges = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

Queue<int> toolsQueue = new Queue<int>(tools);
Stack<int> substancesStack = new Stack<int>(substances);

while (toolsQueue.Any() && substancesStack.Any())
{
    int currentTool = toolsQueue.Peek();
    int currentSubstance = substancesStack.Peek();

    int result = currentTool * currentSubstance;

    toolsQueue.Dequeue();
    substancesStack.Pop();

    if (challenges.Contains(result))
    {
        challenges.Remove(result);
    }
    else
    {
        int newTool = currentTool + 1;
        toolsQueue.Enqueue(newTool);

        int newSubstance = currentSubstance - 1;

        if (newSubstance > 0)
        {
            substancesStack.Push(newSubstance);
        }
    }
}

if (challenges.Count > 0)
{
    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
}
else
{
    Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
}

if (toolsQueue.Any())
{
    Console.Write("Tools: ");
    Console.Write(string.Join(", ", toolsQueue));
    Console.WriteLine();
}

if (substancesStack.Any())
{
    Console.Write("Substances: ");
    Console.Write(string.Join(", ", substancesStack));
    Console.WriteLine();
}

if (challenges.Count > 0)
{
    Console.Write("Challenges: ");
    Console.Write(string.Join(", ", challenges));
    Console.WriteLine();
}