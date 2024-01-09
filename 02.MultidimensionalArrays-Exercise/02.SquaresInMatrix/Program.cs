
int[] matrixSizes = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int rows = matrixSizes[0];
int cols = matrixSizes[1];

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    char[] colValues = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = colValues[col];
    }
}

// TODO: Find all squares 2x2 where chars are the same

int count = 0;  

for (int row = 0; row < rows - 1; row++)
{
    for (int col = 0; col < cols - 1; col++)
    {
        if (matrix[row, col] == matrix[row, col + 1] &&
            matrix[row, col] == matrix[row + 1, col] &&
            matrix[row, col] == matrix[row + 1, col + 1])
        {
            count++;
        }
    }
}

Console.WriteLine(count); 