
int squareMatrixSize = int.Parse(Console.ReadLine());

int[,] matrix = new int[squareMatrixSize, squareMatrixSize];

for (int row = 0; row < squareMatrixSize; row++)
{
    int[] colValues = Console.ReadLine()
        .Split()
        .Select(int.Parse)  
        .ToArray();

    for (int col = 0; col < squareMatrixSize; col++)
    {
        matrix[row, col] = colValues[col];
    }
}

int primaryDiagonalSum = 0;
int secondaryDiagonalSum = 0;

for (int row = 0; row < squareMatrixSize; row++)
{
    primaryDiagonalSum += matrix[row, row];
    secondaryDiagonalSum += matrix[row, squareMatrixSize - 1 - row];
}

Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));