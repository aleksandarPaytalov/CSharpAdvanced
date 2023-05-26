int n = int.Parse(Console.ReadLine());
int[,] matrix = new int[n, n];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] currentRow = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    for (int col = 0; col < matrix.GetLength(1); col++)
	{	
		matrix[row, col] = currentRow[col];
	}
}

int primary = 0;
int secondary = 0;

for (int i = 0; i < n; i++)
{
    primary += matrix[i, i];
}
for (int i = 0; i < n; i++)
{
    secondary += matrix[i, n - i - 1];
}
int difference = Math.Abs(primary - secondary);
Console.WriteLine(difference);