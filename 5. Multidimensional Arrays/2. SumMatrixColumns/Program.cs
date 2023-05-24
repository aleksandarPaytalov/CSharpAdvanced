int[] matrixSize = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int[,] matrix = new int[matrixSize[0], matrixSize[1]];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] inputRows = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = inputRows[col];
    }
}

for (int col = 0; col < matrix.GetLength(1); col++)
{
    int colSum = 0;
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        colSum += matrix[row, col];
    }
    Console.WriteLine(colSum);
}





//3, 6
//7 1 3 3 2 1
//1 3 9 8 5 6
//4 6 7 9 1 0