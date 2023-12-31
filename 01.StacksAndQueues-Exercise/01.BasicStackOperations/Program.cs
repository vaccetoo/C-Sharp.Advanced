﻿
int[] valueNumbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[] inputNumbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int elementsToPush = valueNumbers[0];
int elementsToPop = valueNumbers[1];
int checkForElement = valueNumbers[2];

Stack<int> stack = 
    new Stack<int>(inputNumbers.Take(elementsToPush));

for (int i = 0; i < elementsToPop && stack.Any(); i++)
{
    stack.Pop();
}

if (stack.Contains(checkForElement))
{
    Console.WriteLine("true");
}
else if (stack.Count == 0)
{
    Console.WriteLine(0);
}
else if (!stack.Contains(checkForElement)) // could be 'else'
{
    Console.WriteLine(stack.Min());
}
