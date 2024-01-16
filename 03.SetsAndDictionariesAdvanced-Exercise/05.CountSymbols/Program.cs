
string input = Console.ReadLine();

SortedDictionary<char, int> charTimesAdded = new SortedDictionary<char, int>();

foreach (char currentChar in input)
{
    if (!charTimesAdded.ContainsKey(currentChar))
    {
        charTimesAdded.Add(currentChar, 0);
    }

    charTimesAdded[currentChar]++;
}

foreach (var currentChar in charTimesAdded)
{
    Console.WriteLine($"{currentChar.Key}: {currentChar.Value} time/s");
}