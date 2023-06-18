int[] numbers = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int n = numbers[0];
int m = numbers[1];

char[,] matrix = new char[n, m];

int mouseRow = -1;
int mouseCol = -1;
int cheesCount = 0;
for (int i = 0; i < n; i++)
{
    string colums = Console.ReadLine();
    for (int j = 0; j < m; j++)
    {
        matrix[i, j] = colums[j];
        if (matrix[i, j] == 'M')
        {
            mouseRow = i;
            mouseCol = j;
        }
        else if (matrix[i, j] == 'C')
        {
            cheesCount++;
        }
    }
}

string input = string.Empty;
while ((input = Console.ReadLine()) != "danger")
{
    if (InTheCupboard(matrix, mouseRow, mouseCol, input))
    {
        Console.WriteLine("No more cheese for tonight!"); // позицията на мишката е непроменена, както по условие
        break;
    }
    else
    {
        matrix[mouseRow, mouseCol] = '*';
        if (input == "up") // ???
        {
            mouseRow--;
            if (matrix[mouseRow, mouseCol] == 'C')
            {
                matrix[mouseRow, mouseCol] = 'M';
                cheesCount--;
                if (cheesCount == 0)
                {
                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                    break;
                }
            }
            else if (matrix[mouseRow, mouseCol] == '*')
            {
                matrix[mouseRow, mouseCol] = 'M';
            }
            else if (matrix[mouseRow, mouseCol] == '@')
            {
                mouseRow++;
                matrix[mouseRow, mouseCol] = 'M';
            }
            else if (matrix[mouseRow, mouseCol] == 'T')
            {
                matrix[mouseRow, mouseCol] = 'M';
                Console.WriteLine("Mouse is trapped!");
                break;
            }
        }
        else if (input == "down")
        {
            mouseRow++;
            if (matrix[mouseRow, mouseCol] == 'C')
            {
                matrix[mouseRow, mouseCol] = 'M';
                cheesCount--;
                if (cheesCount == 0)
                {
                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                    break;
                }
            }
            else if (matrix[mouseRow, mouseCol] == '*')
            {
                matrix[mouseRow, mouseCol] = 'M';
            }
            else if (matrix[mouseRow, mouseCol] == '@')
            {
                mouseRow--;
                matrix[mouseRow, mouseCol] = 'M';
            }
            else if (matrix[mouseRow, mouseCol] == 'T')
            {
                matrix[mouseRow, mouseCol] = 'M';
                Console.WriteLine("Mouse is trapped!");
                break;
            }
        }
        else if (input == "left")
        {
            mouseCol--;
            if (matrix[mouseRow, mouseCol] == 'C')
            {
                matrix[mouseRow, mouseCol] = 'M';
                cheesCount--;
                if (cheesCount == 0)
                {
                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                    break;
                }
            }
            else if (matrix[mouseRow, mouseCol] == '*')
            {
                matrix[mouseRow, mouseCol] = 'M';
            }
            else if (matrix[mouseRow, mouseCol] == '@')
            {
                mouseCol++;
                matrix[mouseRow, mouseCol] = 'M';
            }
            else if (matrix[mouseRow, mouseCol] == 'T')
            {
                matrix[mouseRow, mouseCol] = 'M';
                Console.WriteLine("Mouse is trapped!");
                break;
            }
        }
        else if (input == "right")
        {
            mouseCol++;
            if (matrix[mouseRow, mouseCol] == 'C')
            {
                matrix[mouseRow, mouseCol] = 'M';
                cheesCount--;
                if (cheesCount == 0)
                {
                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                    break;
                }
            }
            else if (matrix[mouseRow, mouseCol] == '*')
            {
                matrix[mouseRow, mouseCol] = 'M';
            }
            else if (matrix[mouseRow, mouseCol] == '@')
            {
                mouseCol--;
                matrix[mouseRow, mouseCol] = 'M';
            }
            else if (matrix[mouseRow, mouseCol] == 'T')
            {
                matrix[mouseRow, mouseCol] = 'M';
                Console.WriteLine("Mouse is trapped!");
                break;
            }
        }
    }
}

if (cheesCount > 0 && input == "danger") // трябва да има и проверка за инпута, защото може да излезем от while по друга причина 
{
    Console.WriteLine("Mouse will come back later!");
}
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        Console.Write(matrix[i, j]);
    }
    Console.WriteLine();
}


bool InTheCupboard(char[,] matrix, int mouseRow, int mouseCol, string? input)
{
    return (input == "up" && mouseRow == 0)
                || (input == "down" && mouseRow == matrix.GetLength(0) - 1)
                || (input == "left" && mouseCol == 0)
                || (input == "right" && mouseCol == matrix.GetLength(1) - 1);
}