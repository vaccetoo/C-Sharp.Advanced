
int squareMatrixSize = int.Parse(Console.ReadLine());

int rows = squareMatrixSize;
int cols = squareMatrixSize;

char[,] board = new char[rows, cols];

for (int row = 0; row < rows; row++)
{
    string cellValues = Console.ReadLine();

    for (int col = 0; col < cols; col++)
    {
        board[row, col] = cellValues[col];
    }
}

if (board.GetLength(0) < 3 && board.GetLength(1) < 3)
{
    Console.WriteLine(0);
    return;
}

int removedKnights = 0;

while (true) // TODO: while there is no more knights attacking other knights
{
    int curruntAttackedKnights = 0;

    int mostAttackedKnights = 0;
    int mostAttackedRow = 0;
    int mostAttackedCol = 0;

    for (int row = 0; row < rows; row++)
    {
        for (int col = 0;col < cols; col++)
        {
            if (board[row, col] == 'K') // we have knight
            {
                int currentRow = row;
                int currentCol = col;
                curruntAttackedKnights = FindAttackedKnights(board, currentRow, currentCol); // saving how many knights this knight attacks

                if (curruntAttackedKnights > mostAttackedKnights)
                {
                    mostAttackedKnights = curruntAttackedKnights;
                    mostAttackedRow = row;
                    mostAttackedCol = col;
                }
            }
        }
    }

    if (mostAttackedKnights == 0)
    {
        break;
    }
    else
    {
        board[mostAttackedRow, mostAttackedCol] = '0';
        removedKnights++;
    }
}

Console.WriteLine(removedKnights);

int FindAttackedKnights(char[,] board, int currentRow, int currentCol)
{
    int attackedKnights = 0;

    // up 2 right 1
    if (isCellVallid(currentRow - 2, currentCol + 1))
    {
        if (board[currentRow - 2, currentCol + 1] == 'K')
        {
            attackedKnights++;
        }
    }

    // up 2 left 1
    if (isCellVallid(currentRow - 2, currentCol - 1))
    {
        if (board[currentRow - 2, currentCol - 1] == 'K')
        {
            attackedKnights++;
        }
    }

    // left 2 up 1
    if (isCellVallid(currentRow - 1, currentCol - 2))
    {
        if (board[currentRow - 1, currentCol - 2] == 'K')
        {
            attackedKnights++;
        }
    }

    // left 2 down 1
    if (isCellVallid(currentRow + 1, currentCol - 2))
    {
        if (board[currentRow + 1, currentCol - 2] == 'K')
        {
            attackedKnights++;
        }
    }

    // right 2 up 1
    if (isCellVallid(currentRow - 1, currentCol + 2))
    {
        if (board[currentRow - 1, currentCol + 2] == 'K')
        {
            attackedKnights++;
        }
    }

    // right 2 down 1
    if (isCellVallid(currentRow + 1, currentCol + 2))
    {
        if (board[currentRow + 1, currentCol + 2] == 'K')
        {
            attackedKnights++;
        }
    }

    // down 2 left 1
    if (isCellVallid(currentRow + 2, currentCol - 1))
    {
        if (board[currentRow + 2, currentCol - 1] == 'K')
        {
            attackedKnights++;
        }
    }

    // down 2 right 1
    if (isCellVallid(currentRow + 2, currentCol + 1))
    {
        if (board[currentRow + 2, currentCol + 1] == 'K')
        {
            attackedKnights++;
        }
    }

    return attackedKnights;
}

bool isCellVallid(int currentRow, int currentCol)
{
    if (currentRow >= 0 && currentRow < rows &&
        currentCol >=0 && currentCol < cols)
    {
        return true;
    }

    return false;
}