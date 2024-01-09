
int[] matrixSizes = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int rows = matrixSizes[0];
int cols = matrixSizes[1];

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    int[] colsValues = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = colsValues[col];
    }
}

// TODO: Find in the matrix square 3 x 3 that has a maximal sum of its elements.

int bestSum = int.MinValue;

int bestRow = 0;
int bestColumn = 0;

for (int row = 0; row < rows - 2; row++)
{
    int currentSum = 0;

    for (int col = 0; col < cols - 2; col++)
    {
        currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                     matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                     matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

        if (currentSum > bestSum)
        {
            bestSum = currentSum;

            bestRow = row;
            bestColumn = col;
        }
    }
}

Console.WriteLine($"Sum = {bestSum}");

for (int row = bestRow; row < bestRow + 3; row++)
{
    for (int col = bestColumn; col < bestColumn + 3 ; col++)
    {
        Console.Write(matrix[row, col] + " ");
    }

    Console.WriteLine();
}