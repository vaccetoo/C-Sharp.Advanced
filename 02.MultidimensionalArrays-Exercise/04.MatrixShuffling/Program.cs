
using System.Runtime.CompilerServices;

int[] matrixSizes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = matrixSizes[0];
int cols = matrixSizes[1];

string[,] matrix = new string[rows, cols];

for (int row = 0; row < rows; row++)
{
    string[] colsValues = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = colsValues[col];
    }
}

string command = string.Empty;

while ((command = Console.ReadLine()) != "END")
{
    string[] commandInfo = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (isCommandVallid(commandInfo, matrix))
    {
        int firstRowToSwap = int.Parse(commandInfo[1]);
        int firstColToSwap = int.Parse(commandInfo[2]);
        int secondRowToSwap = int.Parse(commandInfo[3]);
        int secondColToSwap = int.Parse(commandInfo[4]);

        string valueToSwap = matrix[firstRowToSwap, firstColToSwap];
        matrix[firstRowToSwap, firstColToSwap] = matrix[secondRowToSwap, secondColToSwap];
        matrix[secondRowToSwap, secondColToSwap] = valueToSwap;

        PrintMatrix(matrix);
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }
}

bool isCommandVallid(string[] commandInfo, string[,] matrix)
{
    if (commandInfo[0] == "swap" && commandInfo.Length == 5)
    {
        int firstRowToSwap = int.Parse(commandInfo[1]);
        int firstColToSwap = int.Parse(commandInfo[2]);
        int secondRowToSwap = int.Parse(commandInfo[3]);    
        int secondColToSwap = int.Parse(commandInfo[4]);

        if (firstRowToSwap >= 0 && firstRowToSwap < matrix.GetLength(0) &&
            firstColToSwap >= 0 && firstColToSwap < matrix.GetLength(1) &&
            secondRowToSwap >= 0 && secondRowToSwap < matrix.GetLength(0) &&
            secondColToSwap >= 0 && secondColToSwap < matrix.GetLength(1))
        {
            return true;
        }
    }

    return false;
}

static void PrintMatrix(string[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col] + " ");
        }

        Console.WriteLine();
    }
}