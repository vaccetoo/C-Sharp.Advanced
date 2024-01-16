
int numberOfInputs = int.Parse(Console.ReadLine());

Dictionary<int, int> numberTimesAdded = new Dictionary<int, int>();

for (int i = 0; i < numberOfInputs; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());

    if (!numberTimesAdded.ContainsKey(currentNumber))
    {
        numberTimesAdded.Add(currentNumber, 0);
    }

    numberTimesAdded[currentNumber]++;
}

foreach (var number in numberTimesAdded)
{
    if (number.Value % 2 == 0)
    {
        Console.WriteLine(number.Key);
    }
}