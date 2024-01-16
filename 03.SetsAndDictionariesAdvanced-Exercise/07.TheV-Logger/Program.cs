
string command = string.Empty;

List<Vlogger> vloggers = new List<Vlogger>();

while ((command = Console.ReadLine()) != "Statistics")
{
    string[] commandInfo = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string vloggerName = commandInfo[0];
    string commandType = commandInfo[1];

    if (commandType == "joined")
    {
        Vlogger newVlogger = new Vlogger(vloggerName, new HashSet<string>(), new HashSet<string>());
        vloggers.Add(newVlogger);
    }
    else if (commandType == "followed")
    {
        string secondVlogger = commandInfo[2];

        foreach (Vlogger vlogger in vloggers)
        {
            if (vlogger.Name == vloggerName && secondVlogger != vloggerName)
            {
                vlogger.Following.Add(secondVlogger);
            }

            if (vlogger.Name == secondVlogger)
            {
                vlogger.Followers.Add(vloggerName);
            }
        }
    }
}

Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

int count = 1;

foreach (var vlogger in vloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Following.Count))
{
    Console.WriteLine($"{count}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");

    foreach (var follower in vlogger.Followers)
    {
        Console.WriteLine($"* {follower}");
    }

    count++;
}

class Vlogger
{
    public Vlogger(string name, HashSet<string> following, HashSet<string> followers)
    {
        Name = name;
        Following = following;
        Followers = followers;
    }

    public string Name { get; set; }

    public HashSet<string> Following { get; set; }

    public HashSet<string> Followers { get; set; }   
}