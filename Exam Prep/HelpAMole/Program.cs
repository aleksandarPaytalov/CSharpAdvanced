using System;
using System.ComponentModel.DataAnnotations;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int moleRow = -1;
            int molCol = -1;
            int s1Row = -1;
            int s1Col = -1;
            int s2Row = -1;
            int s2Col = -1;
            for (int i = 0; i < n; i++)
            {
                string colums = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = colums[j];

                    if (colums[j] == 'M')
                    {
                        moleRow = i;
                        molCol = j;
                    }
                    if (colums[j] == 'S')
                    {
                        if (s1Row < 0 && s1Col < 0)
                        {
                            s1Row = i;
                            s1Col = j;
                        }
                        else
                        {
                            s2Row = i;
                            s2Col = j;
                        }
                    }
                }
            }

            int points = 0;
            string command = string.Empty;
            char currentdigit = ' ';

            while ((command = Console.ReadLine()) != "End" && points < 25)
            {
                bool sFound = false;

                if (FieldRange(matrix, moleRow, molCol, command))
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    continue;
                }

                else if (command == "up")
                {
                    matrix[moleRow, molCol] = '-';
                    moleRow--;

                    if (matrix[moleRow, molCol] == '-')
                    {

                    }
                    else if (matrix[moleRow, molCol] == 'S')
                    {
                        if (moleRow == s1Row && molCol == s1Col)
                        {
                            matrix[s1Row, s1Col] = '-';
                            moleRow = s2Row;
                            molCol = s2Col;
                        }
                        else
                        {
                            matrix[s2Row, s2Col] = '-';
                            moleRow = s1Row;
                            molCol = s1Col;
                        }
                        points -= 3;
                    }
                    else if (char.IsDigit(matrix[moleRow, molCol]))
                    {
                        points += int.Parse(matrix[moleRow, molCol].ToString());
                    }
                    matrix[moleRow, molCol] = 'M';
                }
                else if (command == "down")
                {
                    matrix[moleRow, molCol] = '-';
                    moleRow++;

                    if (matrix[moleRow, molCol] == '-')
                    {

                    }
                    else if (matrix[moleRow, molCol] == 'S')
                    {
                        if (moleRow == s1Row && molCol == s1Col)
                        {
                            matrix[s1Row, s1Col] = '-';
                            moleRow = s2Row;
                            molCol = s2Col;
                        }
                        else
                        {
                            matrix[s2Row, s2Col] = '-';
                            moleRow = s1Row;
                            molCol = s1Col;
                        }
                        points -= 3;
                    }
                    else if (char.IsDigit(matrix[moleRow, molCol]))
                    {
                        points += int.Parse(matrix[moleRow, molCol].ToString());
                    }
                    matrix[moleRow, molCol] = 'M';
                }
                else if (command == "left")
                {
                    matrix[moleRow, molCol] = '-';
                    molCol--;

                    if (matrix[moleRow, molCol] == '-')
                    {

                    }
                    else if (matrix[moleRow, molCol] == 'S')
                    {
                        if (moleRow == s1Row && molCol == s1Col)
                        {
                            matrix[s1Row, s1Col] = '-';
                            moleRow = s2Row;
                            molCol = s2Col;
                        }
                        else
                        {
                            matrix[s2Row, s2Col] = '-';
                            moleRow = s1Row;
                            molCol = s1Col;
                        }
                        points -= 3;
                    }
                    else if (char.IsDigit(matrix[moleRow, molCol]))
                    {
                        points += int.Parse(matrix[moleRow, molCol].ToString());
                    }
                    matrix[moleRow, molCol] = 'M';
                }
                else if (command == "right")
                {
                    matrix[moleRow, molCol] = '-';
                    molCol++;

                    if (matrix[moleRow, molCol] == '-')
                    {

                    }
                    else if (matrix[moleRow, molCol] == 'S')
                    {
                        if (moleRow == s1Row && molCol == s1Col)
                        {
                            matrix[s1Row, s1Col] = '-';
                            moleRow = s2Row;
                            molCol = s2Col;
                        }
                        else
                        {
                            matrix[s2Row, s2Col] = '-';
                            moleRow = s1Row;
                            molCol = s1Col;
                        }
                        points -= 3;
                    }
                    else if (char.IsDigit(matrix[moleRow, molCol]))
                    {
                        points += int.Parse(matrix[moleRow, molCol].ToString());
                    }
                    matrix[moleRow, molCol] = 'M';
                }
            }

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        private static bool FieldRange(char[,] matrix, int row, int col, string input)
        {
            return (input == "up" && row == 0)
                || (input == "down" && row == matrix.GetLength(0) - 1)
                || (input == "left" && col == 0)
                || (input == "right" && col == matrix.GetLength(1) - 1);
        }
    }
}

