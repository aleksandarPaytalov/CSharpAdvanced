using System;
using System.Linq;

namespace TruffleHunter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] colums = Console.ReadLine()
                    .Split(' ')
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = colums[j];
                }
            }

            int blackTrufflesCollected = 0;
            int summerTrufflesCollected = 0;
            int whiteTrufflesCollected = 0;
            int wildBoarTruffleEaten = 0;
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                string[] command = input.Split(' ');
                string cmdType = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);

                if (cmdType == "Collect")
                {
                    if (matrix[row, col] == 'B')
                    {
                        blackTrufflesCollected++;
                    }
                    else if (matrix[row, col] == 'S')
                    {
                        summerTrufflesCollected++;
                    }
                    else if (matrix[row, col] == 'W')
                    {
                        whiteTrufflesCollected++;
                    }
                    else //if (matrix[row, col] == '-')
                    {
                        continue;
                    }
                    matrix[row, col] = '-';
                }
                else if (cmdType == "Wild_Boar")
                {
                    string direction = command[3];
                    if (direction == "up")
                    {
                        for (int i = row; i >= 0; i -= 2) // =
                        {
                            if (matrix[i, col] == 'B'
                                || matrix[i, col] == 'S'
                                || matrix[i, col] == 'W')
                            {
                                wildBoarTruffleEaten++;
                                matrix[i, col] = '-';
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i <= n - 1; i += 2) // =
                        {
                            if (matrix[i, col] == 'B'
                                || matrix[i, col] == 'S'
                                || matrix[i, col] == 'W')
                            {
                                wildBoarTruffleEaten++;
                                matrix[i, col] = '-';
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= 0; i -= 2) // =
                        {
                            if (matrix[row, i] == 'B'
                                || matrix[row, i] == 'S'
                                || matrix[row, i] == 'W')
                            {
                                wildBoarTruffleEaten++;
                                matrix[row, i] = '-';
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i <= n - 1; i += 2) // =
                        {
                            if (matrix[row, i] == 'B'
                                || matrix[row, i] == 'S'
                                || matrix[row, i] == 'W')
                            {
                                wildBoarTruffleEaten++;
                                matrix[row, i] = '-';
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"Peter manages to harvest {blackTrufflesCollected} black, {summerTrufflesCollected} summer, and {whiteTrufflesCollected} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarTruffleEaten} truffles.");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

        }    
    }
}