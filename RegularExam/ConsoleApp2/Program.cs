
int fieldSizes = int.Parse(Console.ReadLine());

int rows = fieldSizes;
int cols = fieldSizes;

char[,] field = new char[rows, cols];

int currentRow = 0;
int currentCol = 0;

int enemyAircraftCount = 0;

for (int row = 0; row < rows; row++)
{
    string fieldSymbols = Console.ReadLine();

    for (int col = 0; col < cols; col++)
    {
        field[row, col] = fieldSymbols[col];

        if (field[row, col] == 'J')
        {
            currentRow = row;
            currentCol = col;
        }
        else if (field[row, col] == 'E')
        {
            enemyAircraftCount++;
        }
    }
}

int armor = 300;

while (true)
{
    string command = Console.ReadLine();

    int lastRow = currentRow;
    int lastCol = currentCol;

    if (command == "up")
    {
        currentRow--;
    }
    else if(command == "down")
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

    if (field[currentRow, currentCol] == '-')
    {
        field[currentRow, currentCol] = 'J';
        field[lastRow, lastCol] = '-';
        continue;
    }
    else if (field[currentRow, currentCol] == 'E')
    {
        field[currentRow, currentCol] = 'J';
        field[lastRow, lastCol] = '-';

        enemyAircraftCount--;

        if (enemyAircraftCount == 0)
        {
            Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
            break;
        }
        else
        {
            armor -= 100;

            if (armor <= 0)
            {
                Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{currentRow}, {currentCol}]!");
                break;
            }
        }
    }
    else if (field[currentRow, currentCol] == 'R')
    {
        armor = 300;
        field[currentRow, currentCol] = 'J';
        field[lastRow, lastCol] = '-';
    }
}

PrintField(field);

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