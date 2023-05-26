int[] matrixSize = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
string input = Console.ReadLine();

char[,] matrix = new char[matrixSize[0], matrixSize[1]];
int counter = 0;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    
    {
        if (counter == input.Length)
        {
            counter = 0;
        }
        if (row % 2 == 0)
        {
            matrix[row, col] = input[counter];
        }
        else
        {
            matrix[row, matrix.GetLength(1) - 1 - col] = input[counter];
        }

        counter++;        
    }
}

for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        Console.Write($"{matrix[row, col]}");
    }
    Console.WriteLine();
}