int size = int.Parse(Console.ReadLine());
int[,] matrix = new int[size, size];


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

int sumPrimaryDiagonal = 0;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        sumPrimaryDiagonal += matrix[row, col];
        row++;
    }
}
Console.WriteLine(sumPrimaryDiagonal);

//int sum = 0;
//for (int i = 0; i < size; i++)
//{
//    sum += matrix[i, i];
//}
//Console.WriteLine(sum);