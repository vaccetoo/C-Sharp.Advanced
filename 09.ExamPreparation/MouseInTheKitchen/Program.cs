
int[] fieldSizes = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = fieldSizes[0];
int cols = fieldSizes[1];

char[,] field = new char[rows, cols];

int currentRow = 0;
int currentCol = 0;

int cheeseCount = 0;

for (int row = 0; row < rows; row++)
{
    string fieldSymbols = Console.ReadLine();

    for (int col = 0; col < cols; col++)
    {
        field[row, col] = fieldSymbols[col];

        if (field[row, col] == 'M')
        {
            currentRow = row;
            currentCol = col;
        }
        else if (field[row, col] == 'C')
        {
            cheeseCount++;
        }
    }
}

string command = string.Empty;

while ((command = Console.ReadLine()) != "danger")
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
        if (field[currentRow, currentCol] == 'C')
        {
            field[currentRow, currentCol] = 'M';
            field[lastRow, lastCol] = '*';

            cheeseCount--;

            if (cheeseCount == 0)
            {
                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                break;
            }
        }
        else if (field[currentRow, currentCol] == 'T')
        {
            field[currentRow, currentCol] = 'M';
            field[lastRow, lastCol] = '*';

            Console.WriteLine("Mouse is trapped!");
            break;
        }
        else if (field[currentRow, currentCol] == '@')
        {
            currentRow = lastRow;
            currentCol = lastCol;
        }
        else if (field[currentRow, currentCol] == '*')
        {
            field[currentRow, currentCol] = 'M';
            field[lastRow, lastCol] = '*';
        }
    }
    else
    {
        currentRow = lastRow;
        currentCol = lastCol;

        field[currentRow, currentCol] = 'M';

        Console.WriteLine("No more cheese for tonight!");
        break;
    }
}

if (cheeseCount > 0 && command == "danger")
{
    Console.WriteLine("Mouse will come back later!");
}

PrintField(field);


bool IsPositionVallid(int currentRow, int currentCol, char[,] field)
{
    return currentRow >= 0 && currentRow < field.GetLength(0) &&
           currentCol >= 0 && currentCol < field.GetLength(1);
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