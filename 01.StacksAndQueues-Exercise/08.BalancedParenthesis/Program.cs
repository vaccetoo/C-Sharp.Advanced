
string input = Console.ReadLine();

Stack<char> brackets = new Stack<char>();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '('
        || input[i] == '['
        || input[i] == '{')
    {
        brackets.Push(input[i]);
    }
    else if ((input[i] == ')' && brackets.Count == 0)
        || (input[i] == '}' && brackets.Count == 0)
        || (input[i] == ']' && brackets.Count == 0))
    {
        brackets.Push(input[i]);
        break;
    }
    else if ((input[i] == ')' && brackets.Peek() == '(')
        || (input[i] == ']' && brackets.Peek() == '[')
        || (input[i] == '}' && brackets.Peek() == '{'))
    {
        brackets.Pop();
    }
}

if (brackets.Count == 0)
{
    Console.WriteLine("YES");
}
else
{
    Console.WriteLine("NO");
}