
string command = string.Empty;

List<Vlogger> vloggersList = new List<Vlogger>();

while ((command = Console.ReadLine()) != "Statistics")
{
    string[] commandInfo = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string firstVlogger = commandInfo[0];
    string currentCommand = commandInfo[1];

    if (currentCommand == "joined")
    {
        if (vloggersList.Any(x => x.Name == firstVlogger))
        {
            continue;
        }

        Vlogger newVlogger = new Vlogger(firstVlogger, new SortedSet<string>(), new HashSet<string>());

        vloggersList.Add(newVlogger);
    }
    else if (currentCommand == "followed")
    {
        string secondVlogger = commandInfo[2];

        if (vloggersList.Any(x => x.Name == firstVlogger) &&
            vloggersList.Any(x => x.Name == secondVlogger) &&
            firstVlogger != secondVlogger)
        {
            foreach (var vlogger in vloggersList)
            {
                if (vlogger.Name == firstVlogger)
                {
                    vlogger.Following.Add(secondVlogger);
                }

                if (vlogger.Name == secondVlogger)
                {
                    vlogger.Followers.Add(firstVlogger);
                }
            }
        }
    }
}

Console.WriteLine($"The V-Logger has a total of {vloggersList.Count} vloggers in its logs.");

int count = 1;

foreach (var vlogger in vloggersList.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Following.Count))
{
    Console.WriteLine($"{count}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");

    if (count == 1)
    {
        foreach (var follower in vlogger.Followers.OrderBy(name => name))
        {
            Console.WriteLine($"*  {follower}");
        }
    }

    count++;
}

class Vlogger
{
    public Vlogger(string name, SortedSet<string> followers, HashSet<string> following)
    {
        Name = name;
        Followers = followers;
        Following = following;
    }

    public string Name { get; set; }

    public SortedSet<string> Followers { get; set; }

    public HashSet<string> Following { get; set; }
}