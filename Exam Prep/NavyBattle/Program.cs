int n = int.Parse(Console.ReadLine());
char[,] matrix = new char[n, n];

int submarineRow = 0;
int submarineCol = 0;
for (int i = 0; i < n; i++)
{
    string colums = Console.ReadLine();
    for (int j = 0; j < n; j++)
    {
        matrix[i, j] = colums[j];

        if (colums[j] == 'S')
        {
            submarineRow = i;
            submarineCol = j;
        }
    }
}

int mineHits = 0;
int battleCruisers = 0;
while (mineHits < 3 && battleCruisers < 3)
{
    string command = Console.ReadLine();
    matrix[submarineRow, submarineCol] = '-';

    if (command == "up")
    {        
        NextPosition(matrix, submarineRow - 1, submarineCol);
        submarineRow--;
    }
    else if (command == "down")
    {
        NextPosition(matrix, submarineRow + 1, submarineCol);
        submarineRow++;
    }
    else if (command == "left")
    {
        NextPosition(matrix, submarineRow, submarineCol - 1);
        submarineCol--;
    }
    else if (command == "right")
    {
        NextPosition(matrix, submarineRow, submarineCol + 1);
        submarineCol++;        
    }

    matrix[submarineRow, submarineCol] = 'S';
}

void NextPosition(char[,] matrix, int submarineRow, int submarineCol)
{
    
    switch (matrix[submarineRow, submarineCol])
    {
        case '-':
            break;
        case '*':
            mineHits++;
            break;
        case 'C':
            battleCruisers++;
            break;
    }
}

if (mineHits == 3)
{
    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
}
else
{
    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
}
for (int i = 0; i < n; i++)
{    
    for (int j = 0; j < n; j++)
    {
        Console.Write(matrix[i,j]);
    }
    Console.WriteLine();
}