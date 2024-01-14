
int[] fieldSizes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = fieldSizes[0];
int cols = fieldSizes[1];

char[,] field = new char[rows, cols];

int playerCurrentRow = 0;
int playerCurrentCol = 0;

for (int row = 0; row < rows; row++)
{
    string cellsValues = Console.ReadLine();

    for (int col = 0; col < cols; col++)
    {
        field[row, col] = cellsValues[col];

        if (field[row, col] == 'P')
        {
            playerCurrentRow = row;
            playerCurrentCol = col;
            field[playerCurrentRow, playerCurrentCol] = '.';
        }
    }
}

string commands = Console.ReadLine();

foreach (char command in commands)
{
    int lastPlayerRow = playerCurrentRow;
    int lastPlayerCol = playerCurrentCol;

    if (command == 'L')
    {
        playerCurrentCol--;
    }
    else if (command == 'R')
    {
        playerCurrentCol++;
    }
    else if (command == 'U')
    {
        playerCurrentRow--;
    }
    else if (command == 'D')
    {
        playerCurrentRow++;
    }

    field = SpreadBunnies(field);

    if (playerCurrentRow < 0 || playerCurrentRow >= rows ||
             playerCurrentCol < 0 || playerCurrentCol >= cols)
    {
        PrintField(field);
        Console.WriteLine($"won: {lastPlayerRow} {lastPlayerCol}");
        break;
    }
    else if (field[playerCurrentRow, playerCurrentCol] == 'B')
    {
        PrintField(field);
        Console.WriteLine($"dead: {playerCurrentRow} {playerCurrentCol}");
        break;
    }

}

void PrintField(char[,] field)
{
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            Console.Write(field[row, col]);
        }

        Console.WriteLine();
    }
}

char[,] SpreadBunnies(char[,] field)
{
    char[,] newField = new char[field.GetLength(0), field.GetLength(1)];

    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            newField[row, col] = field[row, col];
        }
    }

    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            if (field[row, col] == 'B')
            {
                //up
                if (row - 1 >= 0)
                {
                    newField[row - 1, col] = 'B';
                }

                //down
                if (row + 1 < rows)
                {
                    newField[row + 1, col] = 'B';
                }

                //left
                if (col - 1 >= 0)
                {
                    newField[row, col - 1] = 'B';
                }

                //right
                if (col + 1 < cols)
                {
                    newField[row, col + 1] = 'B';
                }

            }
        }
    }

    return newField;
}