int[] matrixSize = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int[,] matrix = new int[matrixSize[0], matrixSize[1]];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] inputRows = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = inputRows[col];
    }
}

int maxSum = int.MinValue;
int currentSum = 0;
int x = 0;
int y = 0;
for (int row = 0; row < matrix.GetLength(0) - 1; row++)
{    
    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
    {
        currentSum = matrix[row, col]
            + matrix[row, col + 1]
            + matrix[row + 1, col]            
            + matrix[row + 1, col + 1];

        if (currentSum > maxSum)
        {
            maxSum = currentSum;
            x = row;
            y = col;
        }
    }
}
//for (int row = x; row < x + 2; row++)
//{
//    for (int col = y; col < y + 2; col++)
//    {
//        Console.Write(matrix[row, col] + " ");
//    }
//    Console.WriteLine();
//}
Console.WriteLine($"{matrix[x,y]} {matrix[x, y + 1]}");
Console.WriteLine($"{matrix[x + 1 , y]} {matrix[x + 1, y + 1]}");
Console.WriteLine(maxSum);
