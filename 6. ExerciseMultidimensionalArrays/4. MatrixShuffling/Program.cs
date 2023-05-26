int[] matrixSize = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string[,] matrix = new string[matrixSize[0], matrixSize[1]];
for (int row = 0; row < matrix.GetLength(0); row++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = input[col];
    }
}

string command = string.Empty;
while ((command = Console.ReadLine()) != "END")
{
    string[] cmd = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (!cmd.Contains("swap") || cmd.Length != 5)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }
    else
    {
        int xFirst = int.Parse(cmd[1]);
        int yFirst = int.Parse(cmd[2]);
        int xSecond = int.Parse(cmd[3]);
        int ySecond = int.Parse(cmd[4]);        

        if ((xFirst < 0 || xFirst >= matrix.GetLength(0))
            && (xSecond < 0 || xSecond >= matrix.GetLength(0))
            && (yFirst < 0 || yFirst >= matrix.GetLength(1))
            && (ySecond < 0 || ySecond >= matrix.GetLength(1)))
        {
            Console.WriteLine("Invalid input!");
            continue;
        }

        string currentFirstElement = matrix[xFirst, yFirst];
        matrix[xFirst, yFirst] = matrix[xSecond, ySecond];
        matrix[xSecond, ySecond] = currentFirstElement;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write($"{matrix[row, col]} ");
            }
            Console.WriteLine();
        }
    }
    
}