
using System.Text;

Queue<string> songs
    = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));

while (songs.Any())
{
    string[] commandInfo = Console.ReadLine()
        .Split();

    string commandName = commandInfo[0];

    if (commandName == "Play")
    {
        songs.Dequeue();
    }
    else if (commandName == "Add")
    {
        string[] newSong = commandInfo.Skip(1).ToArray();

        string newSongName = string.Join(" ", newSong);
        newSongName = newSongName.TrimEnd(' ');

        if (!songs.Contains(newSongName))
        {
            songs.Enqueue(newSongName);
        }
        else
        {
            Console.WriteLine($"{newSongName} is already contained!");
        }
    }
    else if (commandName == "Show")
    {
        Console.WriteLine(string.Join(", ", songs));
    }
}

Console.WriteLine("No more songs!");
