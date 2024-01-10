
int[] matrixSizes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = matrixSizes[0];
int cols = matrixSizes[1];

char[,] matrix = new char[rows, cols];

string snake = Console.ReadLine();

int currentIndex = 0;

for (int row = 0; row < rows; row++)
{
    if (row % 2 == 0)
    {
        for (int col = 0; col < cols; col++)
        {
            if (currentIndex >= snake.Length)
            {
                currentIndex = 0;
            }

            matrix[row, col] = snake[currentIndex];

            currentIndex++;
        }
    }
    else
    {
        for (int col = cols - 1; col >= 0; col--)
        {
            if (currentIndex >= snake.Length)
            {
                currentIndex = 0;
            }

            matrix[row, col] = snake[currentIndex];

            currentIndex++;
        }
    }
}

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        Console.Write(matrix[row, col]);
    }

    Console.WriteLine();
}