
using System.ComponentModel;

int squareMatrixSize = int.Parse(Console.ReadLine());

int rows = squareMatrixSize;
int cols = squareMatrixSize;

int[,] board = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    int[] cellValues = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < cols; col++)
    {
        board[row, col] = cellValues[col];
    }
}

string[] bombs = Console.ReadLine()
    .Split();

foreach (var bomb in bombs)
{
    int[] currentBombIndexes = bomb
        .Split(",", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    int currentBombRow = currentBombIndexes[0];
    int currentBombCol = currentBombIndexes[1];

    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            if (row == currentBombRow && col == currentBombCol) // There is a bomb
            {
                // TODO: The bomb has to explode ... by 1 square UP, DOWN, LEFT, RIGHT, BOTH DIAGONALS

                int bombDamage = board[row, col];

                if (bombDamage > 0) // The bomb can Explode only if it has value greater than 0
                {
                    Explode(currentBombRow, currentBombCol, board, bombDamage);
                }
            }
        }
    }
}

int aliveCells = 0;
int sumCells = 0;

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        if (board[row, col] > 0)
        {
            aliveCells++;
            sumCells += board[row, col];
        }
    }
}

Console.WriteLine($"Alive cells: {aliveCells}");

Console.WriteLine($"Sum: {sumCells}");

PrintBoard(board);

void Explode(int currentBombRow, int currentBombCol, int[,] board, int damage)
{
    // 1 up
    if (IsCellVallid(currentBombRow - 1, currentBombCol))
    {
        if (board[currentBombRow - 1, currentBombCol] > 0) // Is not dead
        {
            board[currentBombRow - 1, currentBombCol] -= damage;
        }
    }

    // 1 up 1 left
    if (IsCellVallid(currentBombRow - 1, currentBombCol - 1))
    {
        if (board[currentBombRow - 1, currentBombCol - 1] > 0) // Is not dead
        {
            board[currentBombRow - 1, currentBombCol - 1] -= damage;
        }
    }

    // 1 up 1 right
    if (IsCellVallid(currentBombRow - 1, currentBombCol + 1))
    {
        if (board[currentBombRow - 1, currentBombCol + 1] > 0) // Is not dead
        {
            board[currentBombRow - 1, currentBombCol + 1] -= damage;
        }
    }

    // 1 left
    if (IsCellVallid(currentBombRow, currentBombCol - 1))
    {
        if (board[currentBombRow, currentBombCol - 1] > 0) // Is not dead
        {
            board[currentBombRow, currentBombCol - 1] -= damage;
        }
    }

    // 1 right
    if (IsCellVallid(currentBombRow, currentBombCol + 1))
    {
        if (board[currentBombRow, currentBombCol + 1] > 0) // Is not dead
        {
            board[currentBombRow, currentBombCol + 1] -= damage;
        }
    }

    // 1 down 
    if (IsCellVallid(currentBombRow + 1, currentBombCol))
    {
        if (board[currentBombRow + 1, currentBombCol] > 0) // Is not dead
        {
            board[currentBombRow + 1, currentBombCol] -= damage;
        }
    }

    // 1 down 1 left
    if (IsCellVallid(currentBombRow + 1, currentBombCol - 1))
    {
        if (board[currentBombRow + 1, currentBombCol - 1] > 0) // Is not dead
        {
            board[currentBombRow + 1, currentBombCol - 1] -= damage;
        }
    }

    // 1 down 1 right
    if (IsCellVallid(currentBombRow + 1, currentBombCol + 1))
    {
        if (board[currentBombRow + 1, currentBombCol + 1] > 0) // Is not dead
        {
            board[currentBombRow + 1, currentBombCol + 1] -= damage;
        }
    }

    board[currentBombRow, currentBombCol] = 0;
}

bool IsCellVallid(int currentRow, int currentCol)
{
    if (currentRow >= 0 && currentRow < rows &&
        currentCol >= 0 && currentCol < cols)
    {
        return true;
    }

    return false;
}

void PrintBoard(int[,] board)
{
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            Console.Write(board[row, col] + " ");
        }

        Console.WriteLine();
    }
}