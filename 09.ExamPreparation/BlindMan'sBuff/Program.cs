
int[] fieldSize = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = fieldSize[0];
int cols = fieldSize[1];

char[,] field = new char[rows, cols];

int currentRow = 0;
int currentCol = 0;

for (int row = 0; row < rows; row++)
{
    char[] fieldsymbols = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < cols; col++)
    {
        field[row, col] = fieldsymbols[col];

        if (field[row, col] == 'B')
        {
            currentRow = row;
            currentCol = col;
        }
    }
}

// furniture or other obstacles will be marked with the letter 'O'
// opponents will be marked with the letter 'P'. There will always be three other players participating in the game
// All of the empty positions will be marked with '-'

string command = string.Empty;

int movesCount = 0;

int touchedPlayers = 0;

while ((command = Console.ReadLine()) != "Finish")
{
    int lastRow = currentRow;
    int lastCol = currentCol;

    if (command == "up")
    {
        currentRow--;
    }
    else if (command == "down")
    {
        currentRow++;
    }
    else if (command == "left")
    {
        currentCol--;
    }
    else if (command == "right")
    {
        currentCol++;
    }

    if (!isPositionVallid(currentRow, currentCol, field) || field[currentRow, currentCol] == 'O')
    {
        currentRow = lastRow;
        currentCol = lastCol;
    }
    else
    {
        movesCount++;

        if (field[currentRow, currentCol] == '-')
        {
            field[currentRow, currentCol] = 'B';
            field[lastRow, lastCol] = '-';
        }
        else if (field[currentRow, currentCol] == 'P')
        {
            touchedPlayers++;

            field[currentRow, currentCol] = 'B';
            field[lastRow, lastCol] = '-';

            if (touchedPlayers == 3)
            {
                break;  
            }
        }
    }
}

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {touchedPlayers} Moves made: {movesCount}");

bool isPositionVallid(int currentRow, int currentCol, char[,] field)
{
    return currentRow >= 0 && currentRow < field.GetLength(0) &&
           currentCol >= 0 && currentCol < field.GetLength(1);
}