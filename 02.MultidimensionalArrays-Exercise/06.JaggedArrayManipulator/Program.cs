
int jaggedArrayRows = int.Parse(Console.ReadLine());

int[][] jaggedArray = new int[jaggedArrayRows][];

for (int row = 0; row < jaggedArray.Length; row++)
{
    jaggedArray[row] = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
}

for (int row = 0; row < jaggedArray.Length - 1; row++)
{
    if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
    {
        // If a row and the one below it have equal length, multiply each element

        for (int col = 0; col < jaggedArray[row].Length; col++)
        {
            jaggedArray[row][col] *= 2;
            jaggedArray[row + 1][col] *= 2;
        }
    }
    else
    {
        // otherwise - divide by 2

        for (int col = 0; col < jaggedArray[row].Length; col++)
        {
            jaggedArray[row][col] /= 2;
        }

        // moving to the next row because it has different Length ...

        for (int col = 0; col < jaggedArray[row + 1].Length; col++)
        {
            jaggedArray[row + 1][col] /= 2; 
        }
    }
}

string command = string.Empty;

while ((command = Console.ReadLine()) != "End")
{
    string[] commandInfo = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string commandName = commandInfo[0];
    int rowIndex = int.Parse(commandInfo[1]);
    int colIndex = int.Parse(commandInfo[2]);
    int value = int.Parse(commandInfo[3]);

    if (AreIndexesValid(jaggedArray, rowIndex, colIndex))
    {
        if (commandName == "Add")
        {
            jaggedArray[rowIndex][colIndex] += value;
        }
        else if (commandName == "Subtract")
        {
            jaggedArray[rowIndex][colIndex] -= value;
        }
    }
}

for (int row = 0; row < jaggedArray.Length; row++)
{
    for (int col = 0; col < jaggedArray[row].Length; col++)
    {
        Console.Write(jaggedArray[row][col] + " ");
    }

    Console.WriteLine();
}

bool AreIndexesValid(int[][] jaggedArray, int rowIndex, int colIndex)
{
    if (rowIndex >= 0 && rowIndex < jaggedArray.Length && 
        colIndex >= 0 && colIndex < jaggedArray[rowIndex].Length)
    {
        return true;
    }

    return false;
}