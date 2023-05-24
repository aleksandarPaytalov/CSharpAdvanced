int[] matrixSize = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int[,] matrix = new int[matrixSize[0], matrixSize[1]];

for (int row = 0; row < matrixSize[0]; row++)
{
    int[] input = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    for (int col = 0; col < matrixSize[1]; col++)
    {
        matrix[row, col] = input[col];
    }
}
int sum = 0;

//for (int row = 0; row < matrix.GetLength(0); row++)
//{
//    for (int col = 0; col < matrix.GetLength(1); col++)
//    {
//        sum += matrix[row, col];
//    }
//}

foreach (var number in matrix)
{
    sum += number;
}

Console.WriteLine(matrix.GetLength(0));
Console.WriteLine(matrix.GetLength(1));
Console.WriteLine(sum);


//input
//3, 6
//7, 1, 3, 3, 2, 1
//1, 3, 9, 8, 5, 6
//4, 6, 7, 9, 1, 0