
int fieldSize = int.Parse(Console.ReadLine());

char[,] field = new char[fieldSize, fieldSize];

int currentRow = 0;
int currentCol = 0;

for (int row = 0; row < fieldSize; row++)
{
    string fieldSymbols = Console.ReadLine();

    for (int col = 0; col < fieldSize; col++)
    {
        field[row, col] = fieldSymbols[col];

        if (fieldSymbols[col] == 'S')
        {
            currentRow = row;
            currentCol = col;
        }
    }
}


string command = string.Empty;

int tonesCatch = 0;

bool isWhirlpoolReached = false;

while ((command = Console.ReadLine()) != "collect the nets")
{
    string direction = command;

    int lastRow = currentRow;
    int lastCol = currentCol;

    if (direction == "up")
    {
        currentRow--;
    }
    else if (direction == "down")
    {
        currentRow++;
    }
    else if (direction == "left")
    {
        currentCol--;
    }
    else if (direction == "right")
    {
        currentCol++;
    }

    field[lastRow, lastCol] = '-';

    if (!IsPositonValid(currentRow, currentCol, field))
    {
        if (currentRow < 0)
        {
            currentRow = field.GetLength(0) - 1;
        }
        else if (currentRow >= field.GetLength(0))
        {
            currentRow = 0;
        }
        else if (currentCol < 0)
        {
            currentCol = field.GetLength(1) - 1;
        }
        else if (currentCol >= field.GetLength(1))
        {
            currentCol = 0;
        }
    }

    if (field[currentRow, currentCol] == '-')
    {
        field[currentRow, currentCol] = 'S';
        continue;
    }
    else if (field[currentRow, currentCol] == 'W')
    {
        isWhirlpoolReached = true;

        field[currentRow, currentCol] = 'S';

        Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{currentRow},{currentCol}]");

        break;
    }
    else if (char.IsDigit(field[currentRow, currentCol]))
    {
        int value = int.Parse(field[currentRow, currentCol].ToString());

        tonesCatch += value;

        field[currentRow, currentCol] = 'S';
    }
}

if (isWhirlpoolReached)
{
    return;
}


if (tonesCatch >= 20)
{
    Console.WriteLine($"Success! You managed to reach the quota!");
}
else
{
    int tonesNeeded = 20 - tonesCatch;

    Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {tonesNeeded} tons of fish more.");
}

if (tonesCatch > 0)
{
    Console.WriteLine($"Amount of fish caught: {tonesCatch} tons.");
}

if (!isWhirlpoolReached)
{
    PrintField(field);
}


bool IsPositonValid(int currentRow, int currentCol, char[,] field)
{
    if (currentRow >= 0 && currentRow < field.GetLength(0) &&
        currentCol >= 0 && currentCol < field.GetLength(1))
    {
        return true;
    }

    return false;
}


void PrintField(char[,] field)
{
    for (int row = 0; row < field.GetLength(0); row++)
    {
        for (int col = 0; col < field.GetLength(1); col++)
        {
            Console.Write(field[row, col]);
        }

        Console.WriteLine();
    }
}