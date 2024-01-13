
int fieldSizes = int.Parse(Console.ReadLine());

int rows = fieldSizes;
int cols = fieldSizes;

char[,] field = new char[rows, cols];

Queue<string> commands = new Queue<string>
    (Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries));  

for (int row = 0; row < rows; row++)
{
    char[] cellValues = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < cols; col++)
    {
        field[row, col] = cellValues[col];
    }
}

// Field positions:
// * – a regular position on the field
// e – the end of the route
// c  - coal
// s - the place where the miner starts

int currentRow = 0;
int currentCol = 0;

int coalsCount = 0;

bool isGameOver = false;

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        if (field[row, col] == 's')
        {
            currentRow = row;
            currentCol = col;
        }

        if (field[row, col] == 'c')
        {
            coalsCount++;
        }
    }
}

int coalsFound = 0;

while (commands.Any()) // TODO: Break if cell with 'e' is found or have collected all coals
{
    string currentCommand = commands.Dequeue();

    if (currentCommand == "left")
    {
        if (IsCellVallid(currentRow, currentCol - 1))
        {
            currentCol = currentCol - 1;

            CheckCurrentCell(currentRow, currentCol);

            if (isGameOver)
            {
                break;
            }
        }
    }
    else if (currentCommand == "right")
    {
        if (IsCellVallid(currentRow, currentCol + 1))
        {
            currentCol = currentCol + 1;

            CheckCurrentCell(currentRow, currentCol);

            if (isGameOver)
            {
                break;
            }
        }
    }
    else if (currentCommand == "up")
    {
        if (IsCellVallid(currentRow - 1, currentCol))
        {
            currentRow = currentRow - 1;

            CheckCurrentCell(currentRow, currentCol);

            if (isGameOver)
            {
                break;
            }
        }
    }
    else if (currentCommand == "down")
    {
        if (IsCellVallid(currentRow + 1, currentCol))
        {
            currentRow = currentRow + 1;

            CheckCurrentCell(currentRow, currentCol);

            if (isGameOver)
            {
                break;
            }
        }
    }

    if (coalsFound == coalsCount)
    {
        isGameOver = true;
        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
        break;
    }
}

if (!commands.Any() && !isGameOver)
{
    Console.WriteLine($"{coalsCount - coalsFound} coals left. ({currentRow}, {currentCol})");
}

void CheckCurrentCell(int currentRow, int currentCol)
{
    if (field[currentRow, currentCol] == 'c')
    {
        coalsFound++;
        field[currentRow, currentCol] = '*';
    }
    else if (field[currentRow, currentCol] == 'e')
    {
        isGameOver = true;
        Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
    }
}

bool IsCellVallid(int row, int col)
{
    if (row >= 0 && row < field.GetLength(0) &&
        col >= 0 && col < field.GetLength(1))
    {
        return true;
    }

    return false;
}