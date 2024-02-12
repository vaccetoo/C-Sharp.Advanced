
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
    string fieldsymbols = Console.ReadLine();

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

int startRow = currentRow;
int startCol = currentCol;

string command = string.Empty;

while (true)
{
    command = Console.ReadLine();

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

    if (isPositionVallid(currentRow, currentCol, field))
    {
        if (field[currentRow, currentCol] == '-')
        {
            field[currentRow, currentCol] = '.';
        }
        else if (field[currentRow, currentCol] == 'P')
        {
            field[currentRow, currentCol] = 'R';

            Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
        }
        else if (field[currentRow, currentCol] == '*')
        {
            currentRow = lastRow;
            currentCol = lastCol;
            continue;
        }
        else if (field[currentRow, currentCol] == 'A')
        {
            field[currentRow, currentCol] = 'P';
            Console.WriteLine("Pizza is delivered on time! Next order...");
            break;
        }
    }
    else
    {
        field[startRow, startCol] = ' ';
        Console.WriteLine("The delivery is late. Order is canceled.");
        break;
    }
}

PrintField(field);

bool isPositionVallid(int currentRow, int currentCol, char[,] field)
{
    return currentRow >= 0 && currentRow < field.GetLength(0) &&
           currentCol >= 0 && currentCol < field.GetLength(1);
}

void PrintField(char[,] field)
{
    for (int row = 0;row < field.GetLength(0); row++)
    {
        for (int col = 0;col < field.GetLength(1); col++)
        {
            Console.Write(field[row, col]);
        }

        Console.WriteLine();
    }
}