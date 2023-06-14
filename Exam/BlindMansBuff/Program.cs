int[] rowCol = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

char[,] matrix = new char [rowCol[0], rowCol[1]];
int row = 0;
int col = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    char[] lines = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = lines[j];
        if (lines[j] == 'B')
        {
            row = i;
            col = j;
            matrix[row, col] = '-';
        }
    }
}

string input = string.Empty;
int playersTouched = 0;
int movesMade = 0;
while ((input = Console.ReadLine()) != "Finish")
{
    if (FieldRange(matrix, row, col, input) || CheckForObstacle(matrix, row, col))
    {
        continue;
    }
    else 
    {
        movesMade++;
        switch (input)
        {
            case "up":
                row--;
                if (matrix[row, col] == 'P')
                {
                    playersTouched++;
                }
                break;
            case "down":
                row++;
                if (matrix[row, col] == 'P')
                {
                    playersTouched++;
                }
                break;

            case "left":
                col--;
                if (matrix[row, col] == 'P')
                {
                    playersTouched++;
                }
                break;

            case "right":
                col++;
                if (matrix[row, col] == 'P')
                {
                    playersTouched++;
                }
                break;
        }
    }
    matrix[row, col] = '-'; // 

    if (playersTouched == 3)
        break;
}

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {playersTouched} Moves made: {movesMade}");

bool CheckForObstacle(char[,] matrix, int row, int col)
{
    switch (input)
    {
        case "up":
            if (matrix[row - 1, col] == 'O')
            {
                return true;
            }
            break;
        case "down":
            if (matrix[row + 1, col] == 'O')
            {
                return true;
            }
            break;

        case "left":
            if (matrix[row, col - 1] == 'O')
            {
                return true;
            }
            break;

        case "right":
            if (matrix[row, col + 1] == 'O')
            {
                return true;
            }
            break;

    }

    return false;
}
    

bool FieldRange(char[,] matrix, int row, int col, string input)
    => (input == "up" && row == 0) || 
    (input == "down" && row == matrix.GetLength(0) - 1) ||
    (input == "left" && col == 0) ||
    (input =="right" && col == matrix.GetLength(1) - 1);



