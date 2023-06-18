using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverContest
{
    class Program
    { 
    static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int countWoodBranches = 0;
            int beaverRow = -1;
            int beaverCol = -1;
            for (int i = 0; i < n; i++)
            {
                char[] colums = Console.ReadLine()
                    .Split(' ')
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = colums[j];

                    if (colums[j] == 'B')
                    {
                        beaverRow = i;
                        beaverCol = j;
                    }
                    else if (char.IsLower(colums[j]))
                    {
                        countWoodBranches++;

                    }
                }
            }

            Stack<char> woodBranches = new Stack<char>();
            int branchesCollected = 0;
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end" && countWoodBranches != 0)
            {
                if (CheckTheNextMove(matrix, beaverRow, beaverCol, input))
                {
                    if (woodBranches.Any())
                    {
                        woodBranches.Pop();
                        branchesCollected--;
                    }
                    continue;
                }
                else if (input == "up")
                {
                    matrix[beaverRow, beaverCol] = '-';
                    beaverRow--;
                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        woodBranches.Push(matrix[beaverRow, beaverCol]);
                        countWoodBranches--;
                        branchesCollected++;
                    }
                    else if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        if (beaverRow > 0)
                        {
                            beaverRow = 0;
                        }
                        else
                        {
                            beaverRow = matrix.GetLength(0) - 1;
                        }
                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            woodBranches.Push(matrix[beaverRow, beaverCol]);
                            branchesCollected++;
                        }
                    }
                    matrix[beaverRow, beaverCol] = 'B';
                }
                else if (input == "down")
                {
                    matrix[beaverRow, beaverCol] = '-';
                    beaverRow++;
                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        woodBranches.Push(matrix[beaverRow, beaverCol]);
                        countWoodBranches--;
                        branchesCollected++;
                    }
                    else if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        if (beaverRow < matrix.GetLength(0) - 1)
                        {
                            beaverRow = matrix.GetLength(0) - 1;
                        }
                        else
                        {
                            beaverRow = 0;
                        }
                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            woodBranches.Push(matrix[beaverRow, beaverCol]);
                            countWoodBranches--;
                            branchesCollected++;
                        }
                    }
                    matrix[beaverRow, beaverCol] = 'B';
                }
                else if (input == "left")
                {
                    matrix[beaverRow, beaverCol] = '-';
                    beaverCol--;
                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        woodBranches.Push(matrix[beaverRow, beaverCol]);
                        countWoodBranches--;
                        branchesCollected++;
                    }
                    else if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        if (beaverCol > 0)
                        {
                            beaverCol = 0;
                        }
                        else
                        {
                            beaverCol = matrix.GetLength(1) - 1;
                        }
                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            woodBranches.Push(matrix[beaverRow, beaverCol]);
                            countWoodBranches--;
                            branchesCollected++;
                        }
                    }
                    matrix[beaverRow, beaverCol] = 'B';
                }
                else if (input == "right")
                {
                    matrix[beaverRow, beaverCol] = '-';
                    beaverCol++;
                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        woodBranches.Push(matrix[beaverRow, beaverCol]);
                        countWoodBranches--;
                        branchesCollected++;
                    }
                    else if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        if (beaverCol < matrix.GetLength(1) - 1)
                        {
                            beaverCol = matrix.GetLength(1) - 1;
                        }
                        else
                        {
                            beaverCol = 0;
                        }
                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            woodBranches.Push(matrix[beaverRow, beaverCol]);
                            countWoodBranches--;
                            branchesCollected++;
                        }
                    }
                    matrix[beaverRow, beaverCol] = 'B';
                }
            }

            Stack<char> branchesInColectionOrder = new Stack<char>(woodBranches); // ordered in order of colection

            if (countWoodBranches == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branchesCollected} wood branches: {string.Join(", ", branchesInColectionOrder)}."); 
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countWoodBranches} branches left.");
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            bool CheckTheNextMove(char[,] matrix, int beaverRow, int beaverCol, string input)
            {
                return (input == "up" && beaverRow == 0)
                    || (input == "down" && beaverRow == matrix.GetLength(0) - 1)
                    || (input == "left" && beaverCol == 0)
                    || (input == "right" && beaverCol == matrix.GetLength(1) - 1);
            }
        }    
    }
}


