using System;
namespace WallDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int vankoRow = -1;
            int vankoCol = -1;
            for (int i = 0; i < n; i++)
            {
                string colums = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = colums[j];

                    if (colums[j] == 'V')
                    {
                        vankoRow = i;
                        vankoCol = j;
                    }                    
                }
            }

            int moves = 0;
            bool getElectrecuted = false;
            int holesCounter = 1; 
            int rodHits = 0;
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                if (OnField(matrix, input, vankoRow, vankoCol))
                {
                    continue;
                }
                else
                {
                    if (input == "up")
                    {
                        matrix[vankoRow, vankoCol] = '*';
                        vankoRow--;
                        if (matrix[vankoRow, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                        else if (matrix[vankoRow, vankoCol] == 'C')
                        {
                            matrix[vankoRow, vankoCol] = 'E';
                            holesCounter++;
                            getElectrecuted = true;
                            //moves++;
                            break;
                        }
                        else if (matrix[vankoRow, vankoCol] == 'R')
                        {
                            vankoRow++;
                            rodHits++;
                            Console.WriteLine("Vanko hit a rod!");
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                        else if (matrix[vankoRow, vankoCol] == '-')
                        {
                            holesCounter++;
                            //moves++;
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                    }
                    else if (input == "down")
                    {
                        matrix[vankoRow, vankoCol] = '*';
                        vankoRow++;
                        if (matrix[vankoRow, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                        else if (matrix[vankoRow, vankoCol] == 'C')
                        {
                            matrix[vankoRow, vankoCol] = 'E';
                            holesCounter++;
                            getElectrecuted = true;
                            //moves++;
                            break;
                        }
                        else if (matrix[vankoRow, vankoCol] == 'R')
                        {
                            vankoRow--;
                            rodHits++;
                            Console.WriteLine("Vanko hit a rod!");
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                        else if (matrix[vankoRow, vankoCol] == '-')
                        {
                            holesCounter++;
                            //moves++;
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                    }
                    else if (input == "left")
                    {
                        matrix[vankoRow, vankoCol] = '*';
                        vankoCol--;
                        if (matrix[vankoRow, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                        else if (matrix[vankoRow, vankoCol] == 'C')
                        {
                            matrix[vankoRow, vankoCol] = 'E';
                            holesCounter++;
                            getElectrecuted = true;
                            //moves++;
                            break;
                        }
                        else if (matrix[vankoRow, vankoCol] == 'R')
                        {
                            vankoCol++;
                            rodHits++;
                            Console.WriteLine("Vanko hit a rod!");
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                        else if (matrix[vankoRow, vankoCol] == '-')
                        {
                            holesCounter++;
                            //moves++;
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                    }
                    else if (input == "right")
                    {
                        matrix[vankoRow, vankoCol] = '*';
                        vankoCol++;
                        if (matrix[vankoRow, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                        else if (matrix[vankoRow, vankoCol] == 'C')
                        {
                            matrix[vankoRow, vankoCol] = 'E';
                            holesCounter++;
                            getElectrecuted = true;
                            //moves++;
                            break;
                        }
                        else if (matrix[vankoRow, vankoCol] == 'R')
                        {
                            vankoCol--;
                            rodHits++;
                            Console.WriteLine("Vanko hit a rod!");
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                        else if (matrix[vankoRow, vankoCol] == '-')
                        {
                            holesCounter++;
                            //moves++;
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                    }
                }

            }
            if (getElectrecuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCounter} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holesCounter} hole(s) and he hit only {rodHits} rod(s).");
            }
            // in case there is no moves at all or only one try at which position stands "R"
            //if (moves != 0)
            //{
            //    
            //}
            //else
            //{
            //    Console.WriteLine($"Vanko managed to make {0} hole(s) and he hit only {0} rod(s).");
            //}
            
            for (int i = 0; i < n; i++)
            {                
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
        
        private static bool OnField(char[,] matrix, string input, int row, int col)
        {
            return (input == "up" && row == 0)
                || (input == "down" && row == matrix.GetLength(0) - 1)
                || (input == "left" && col == 0)
                || (input == "right" && col == matrix.GetLength(1) - 1);
        }
    }
}

