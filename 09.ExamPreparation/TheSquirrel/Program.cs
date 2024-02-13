
int fieldSizes = int.Parse(Console.ReadLine());

int rows = fieldSizes;
int cols = fieldSizes;

char[,] field = new char[rows, cols];

int currentRow = 0;
int currentCol = 0;

List<string> commands = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

for (int row = 0; row < rows; row++)
{
    string fieldSymbols = Console.ReadLine();

    for (int col = 0; col < cols; col++)
    {
        field[row, col] = fieldSymbols[col];

        if (field[row, col] == 's')
        {
            currentRow = row;
            currentCol = col;
        }
    }
}
int hazelnutsCount = 0;

bool isSomethingHappened = false;

foreach (var command in commands)
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

    if (IsPositionVallid(currentRow, currentCol, field))
    {
        if (field[currentRow, currentCol] == 'h')
        {
            hazelnutsCount++;

            field[currentRow, currentCol] = 's';
            field[lastRow, lastCol] = '*';

            if (hazelnutsCount == 3)
            {
                Console.WriteLine("Good job! You have collected all hazelnuts!");
                break;
            }
        }
        else if (field[currentRow, currentCol] == '*')
        {
            field[currentRow, currentCol] = 's';
            field[lastRow, lastCol] = '*';
        }
        else if (field[currentRow, currentCol] == 't')
        {
            isSomethingHappened = true;
            field[lastRow, lastCol] = '*';
            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            break;
        }
    }
    else
    {
        isSomethingHappened = true;
        field[lastRow, lastCol] = '*';
        Console.WriteLine("The squirrel is out of the field.");
        break;
    }
}

if (hazelnutsCount < 3 && !isSomethingHappened)
{
    Console.WriteLine("There are more hazelnuts to collect.");
}

Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");



bool IsPositionVallid(int currentRow, int currentCol, char[,] field)
{
    return currentRow >= 0 && currentRow < field.GetLength(0) &&
           currentCol >= 0 && currentCol < field.GetLength(1);
}
