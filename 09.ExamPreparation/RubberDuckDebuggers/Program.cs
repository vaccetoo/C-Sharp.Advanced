
int[] timeForTask = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] tasksNumber = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> times = new Queue<int>(timeForTask);
Stack<int> tasks = new Stack<int>(tasksNumber);

Dictionary<string, int> rubberDucks = new Dictionary<string, int>
{
    { "Darth Vader Ducky", 0 },
    { "Thor Ducky", 0 },
    { "Big Blue Rubber Ducky", 0 },
    { "Small Yellow Rubber Ducky", 0 }

};

while (times.Any() && tasks.Any())
{
    int currentTimeNeeded = times.Peek() * tasks.Peek();

    if (currentTimeNeeded >= 0 && currentTimeNeeded <= 60)
    {
        rubberDucks["Darth Vader Ducky"]++;
        times.Dequeue();
        tasks.Pop();
    }
    else if (currentTimeNeeded >= 61 && currentTimeNeeded <= 120)
    {
        rubberDucks["Thor Ducky"]++;
        times.Dequeue();
        tasks.Pop();
    }
    else if (currentTimeNeeded >= 121 && currentTimeNeeded <= 180)
    {
        rubberDucks["Big Blue Rubber Ducky"]++;
        times.Dequeue();
        tasks.Pop();
    }
    else if (currentTimeNeeded >= 181 && currentTimeNeeded <= 240)
    {
        rubberDucks["Small Yellow Rubber Ducky"]++;
        times.Dequeue();
        tasks.Pop();
    }
    else
    {
        tasks.Push(tasks.Pop() - 2);
        times.Enqueue(times.Dequeue());
    }
}

Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded: ");

foreach (var rubberDuck in rubberDucks)
{
    Console.WriteLine($"{rubberDuck.Key}: {rubberDuck.Value}");
}
