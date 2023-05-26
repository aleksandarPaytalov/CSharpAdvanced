using System;
using System.Linq;

int matrixSize = int.Parse(Console.ReadLine());

int[,] matrix = new int[matrixSize, matrixSize];

for (int row = 0; row < matrixSize; row++)
{
    int[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(n => int.Parse(n)).ToArray();

    for (int col = 0; col < matrixSize; col++)
    {
        matrix[row, col] = input[col];
    }
}

string[] indexPairs = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

foreach (var indexPair in indexPairs)
{
    int[] indices = indexPair
        .Split(",", StringSplitOptions.RemoveEmptyEntries)
        .Select(i => int.Parse(i))
        .ToArray();

    int row = indices[0];
    int col = indices[1];

    Explode(row, col, matrix);
}

int freeCells = 0;
int sum = 0;

for (int row = 0; row < matrixSize; row++)
{
    for (int col = 0; col < matrixSize; col++)
    {
        if (matrix[row, col] > 0)
        {
            freeCells++;
            sum += matrix[row, col];
        }
    }
}

Console.WriteLine($"Alive cells: {freeCells}");
Console.WriteLine($"Sum: {sum}");

for (int row = 0; row < matrixSize; row++)
{
    for (int col = 0; col < matrixSize; col++)
    {
        Console.Write($"{matrix[row, col]} ");
    }

    Console.WriteLine();
}

static void Explode(int row, int col, int[,] matrix)
{
    int value = matrix[row, col];

    if (value > 0)
    {
        matrix[row, col] = 0;

        //top
        if (row > 0 && matrix[row - 1, col] > 0)
        {
            matrix[row - 1, col] -= value;
        }

        //bottom
        if (row < matrix.GetLength(0) - 1 && matrix[row + 1, col] > 0)
        {
            matrix[row + 1, col] -= value;
        }

        //left
        if (col > 0 && matrix[row, col - 1] > 0)
        {
            matrix[row, col - 1] -= value;
        }

        //right
        if (col < matrix.GetLength(1) - 1 && matrix[row, col + 1] > 0)
        {
            matrix[row, col + 1] -= value;
        }

        //top left
        if (row > 0 && col > 0 && matrix[row - 1, col - 1] > 0)
        {
            matrix[row - 1, col - 1] -= value;
        }

        //bottom left
        if (row < matrix.GetLength(0) - 1 && col > 0 && matrix[row + 1, col - 1] > 0)
        {
            matrix[row + 1, col - 1] -= value;
        }

        //top right
        if (row > 0 && col < matrix.GetLength(1) - 1 && matrix[row - 1, col + 1] > 0)
        {
            matrix[row - 1, col + 1] -= value;
        }

        //bottom right
        if (row < matrix.GetLength(0) - 1 && col < matrix.GetLength(1) - 1 && matrix[row + 1, col + 1] > 0)
        {
            matrix[row + 1, col + 1] -= value;
        }
    }
}