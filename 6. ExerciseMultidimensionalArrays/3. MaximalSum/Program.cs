int[] matrixSize = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[,] matrix = new int[matrixSize[0], matrixSize[1]];
for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = input[col];
    }
}

int maxSum = int.MinValue;
int x = 0;
int y = 0;
for (int row = 0; row < matrix.GetLength(0) - 2; row++)
{
    int currentSum = 0;
    for (int col = 0; col < matrix.GetLength(1) - 2; col++)
    {
        currentSum = matrix[row, col] + matrix[row + 1, col] + matrix[row + 2, col]
            + matrix[row, col + 1] + matrix[row + 1, col + 1] + matrix[row + 2, col + 1]
            + matrix[row, col + 2] + matrix[row + 1, col + 2] + matrix[row + 2, col + 2];

        if (currentSum > maxSum)
        {
            maxSum = currentSum;
            x = row;
            y = col;
        }
    }    
}

Console.WriteLine($"Sum = {maxSum}");
for (int row = x; row < x + 3; row++)
{
    for (int col = y; col < y + 3; col++)
    {
        Console.Write($"{matrix[row, col]} ");
    }
    Console.WriteLine();
}