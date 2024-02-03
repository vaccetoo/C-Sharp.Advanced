




int boardSize = int.Parse(Console.ReadLine());

char[,] field = new char[boardSize, boardSize];

int startedRow = 0;
int startedCol = 0;

for (int row = 0; row < boardSize; row++)
{
    string fieldSymbols = Console.ReadLine();

    for (int col = 0; col < boardSize; col++)
    {
        field[row, col] = fieldSymbols[col];

        if (fieldSymbols[col] == 'G')
        {
            startedRow = row;
            startedCol = col;
        }
    }
}


int money = 100;

int currentRow = startedRow;
int currentCol = startedCol;

string command = string.Empty;

while ((command = Console.ReadLine()) != "end")
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

    if (IsPositonValid(currentRow, currentCol, field))
    {
        if (field[currentRow, currentCol] == '-')
        {
            field[currentRow, currentCol] = 'G';
            field[lastRow, lastCol] = '-';
            continue;
        }
        else if (field[currentRow, currentCol] == 'W')
        {
            money += 100;
        }
        else if (field[currentRow, currentCol] == 'P')
        {
            money -= 200;
        }
        else if (field[currentRow, currentCol] == 'J')
        {
            money += 100000;
            Console.WriteLine($"You win the Jackpot!");
            Console.WriteLine($"End of the game. Total amount: {money}$");

            field[currentRow, currentCol] = 'G';
            field[lastRow, lastCol] = '-';

            break;
        }

        field[currentRow, currentCol] = 'G';
        field[lastRow, lastCol] = '-';
    }
    else
    {
        
        field[currentRow, currentCol] = 'G';
        field[lastRow, lastCol] = '-';
        money = 0;
        Console.WriteLine($"Game over! You lost everything!");
        break;
    }

    if (money <= 0)
    {
        Console.WriteLine($"Game over! You lost everything!");
        break;
    }
}

if (command == "end")
{
    Console.WriteLine($"End of the game. Total amount: {money}$");
}

if (money > 0)
{
    PrintField(field);
}

void PrintField(char[,] field)
{
    for (int row = 0; row < field.GetLength(0); row ++)
    {
        for (int col = 0; col < field.GetLength(1); col++)
        {
            Console.Write(field[row, col]);
        }

        Console.WriteLine();
    }
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