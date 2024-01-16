
string command = string.Empty;

Dictionary<string, Dictionary<List<string>, List<string>>> vloggerFollowers = 
    new Dictionary<string, Dictionary<List<string>, List<string>>>();

while ((command = Console.ReadLine()) != "Statistics")
{
    string[] commandInfo = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string vloggerName = commandInfo[0];
    string commandType = commandInfo[1];

    if (commandType == "joined")
    {
        if (!vloggerFollowers.ContainsKey(vloggerName))
        {
            vloggerFollowers.Add(vloggerName, new Dictionary<List<string>, List<string>>());
        }
        else
        {
            continue;
        }
    }
    else if (commandType == "followed")
    {
        string secondVlogger = commandInfo[2];
    }
}

