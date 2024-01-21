
using System.Threading.Channels;

string[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action <string[]> printArray = array => 
Console.WriteLine(string.Join(Environment.NewLine, array));

printArray(input);