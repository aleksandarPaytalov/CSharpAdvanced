int n = int.Parse(Console.ReadLine());
char[,] matrix = new char[n, n];

if (n < 3)
{
    Console.WriteLine(0);
    return;
}

for (int row = 0; row < matrix.GetLength(0); row++)
{
    string input = Console.ReadLine();    

    for (int col = 0; col < matrix.GetLength(1); col++)
	{
		matrix[row, col] = input[col];
	}
}

int removedKnights = 0;

while (true)
{
    int countMostAttacking = 0;
    int rowMostAttacking = 0;
    int colMostAttacking = 0;

    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[row, col] == 'K')
            {
                int attackedKnights = CountAttackedKnights(row, col, n, matrix); // TODO

                if (countMostAttacking < attackedKnights)
                {
                    countMostAttacking = attackedKnights;
                    rowMostAttacking = row;
                    colMostAttacking = col;
                }
            }
        }
    }

    if (countMostAttacking == 0)
    {
        break;
    }
    else
    {
        matrix[rowMostAttacking, colMostAttacking] = '0';
        removedKnights++;
    }
}


Console.WriteLine(removedKnights);

static int CountAttackedKnights(int row, int col, int n, char[,] matrix)
{
    int attackedKnights = 0;

    //down right
    if (ValidCell(row + 2, col + 1, n))
    {
        if (matrix[row + 2, col + 1] == 'K')
        {
            attackedKnights++;
        }    
    }
    //down left
    if (ValidCell(row + 2, col - 1, n))
    {
        if (matrix[row + 2, col - 1] == 'K')
        {
            attackedKnights++;
        }
    }
    //left down
    if (ValidCell(row + 1, col - 2, n))
    {
        if (matrix[row + 1, col - 2] == 'K')
        {
            attackedKnights++;
        }
    }
    //left up
    if (ValidCell(row - 1, col - 2, n))
    {
        if (matrix[row - 1, col - 2] == 'K')
        {
            attackedKnights++;
        }
    }
    //up left
    if (ValidCell(row - 2, col - 1, n))
    {
        if (matrix[row - 2, col - 1] == 'K')
        {
            attackedKnights++;
        }
    }
    //up right
    if (ValidCell(row - 2, col + 1, n))
    {
        if (matrix[row - 2, col + 1] == 'K')
        {
            attackedKnights++;
        }
    }
    //right up
    if (ValidCell(row - 1, col + 2, n))
    {
        if (matrix[row - 1, col + 2] == 'K')
        {
            attackedKnights++;
        }
    }

    if (ValidCell(row + 1, col + 2, n))
    {
        if (matrix[row + 1, col + 2] == 'K')
        {
            attackedKnights++;
        }
    }
   
    return attackedKnights;
}

static bool ValidCell (int row, int col, int n)
{
    return
            row >= 0
            && row < n
            && col >= 0
            && col < n;
}
