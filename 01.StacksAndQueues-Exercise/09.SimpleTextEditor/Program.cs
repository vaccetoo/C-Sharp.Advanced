
int numberOfCommands = int.Parse(Console.ReadLine());

string text = string.Empty;

Stack<string> stack = new Stack<string>();

stack.Push(text);

for (int i = 0; i < numberOfCommands; i++)
{
    string[] commandInfo = Console.ReadLine()
        .Split();

    string commandName = commandInfo[0];

    if (commandName == "1")
    {
        string addString = commandInfo[1];

        text += addString;
        stack.Push(text);
    }
    else if (commandName == "2")
    {
        int count = int.Parse(commandInfo[1]);

        text = text.Remove(text.Length - count, count);

        stack.Push(text);
    }
    else if (commandName == "3")
    {
        int index = int.Parse(commandInfo[1]);

        string currentText = stack.Peek();

        char charToPrint = currentText[index - 1];

        Console.WriteLine(charToPrint);
    }
    else if (commandName == "4")
    {
        stack.Pop();

        text = stack.Peek();
    }
}
