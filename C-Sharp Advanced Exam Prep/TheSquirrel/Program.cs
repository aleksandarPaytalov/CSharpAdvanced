using System.Runtime.CompilerServices;
using System.Text;

int n = int.Parse(Console.ReadLine());
string[] commands = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
string[,] matrix = new string[n, n];

int squirrelPositionRow = 0;
int squirrelPositionCol = 0;
for (int i = 0; i < n; i++)
{
    string colums = Console.ReadLine();
    for (int j = 0; j < n; j++)
    {
        matrix[i, j] = colums[j].ToString();
        if (colums[j] == 's')
        {
            squirrelPositionRow = i;
            squirrelPositionCol = j;
        }
    }
}

int hazelnutsCount = 0;
bool onField = true;
for (int i = 0; i < commands.Length; i++)
{
    matrix[squirrelPositionRow, squirrelPositionCol] = "*"; //

    if (commands[i] == "left")
    {
        squirrelPositionCol--;
        PositionCheck();
        if (onField)
        {
            hazelnutsCount = SquirrelMove(matrix, squirrelPositionRow, squirrelPositionCol, hazelnutsCount);
            onField = BoolOnField(matrix, squirrelPositionRow, squirrelPositionCol, onField);
        }
        if (!onField)
        {
            break;
        }
    }
    else if (commands[i] == "right")
    {
        squirrelPositionCol++;
        PositionCheck();
        if (onField)
        {
            hazelnutsCount = SquirrelMove(matrix, squirrelPositionRow, squirrelPositionCol, hazelnutsCount);
            onField = BoolOnField(matrix, squirrelPositionRow, squirrelPositionCol, onField);
        }
        if (!onField)
        {
            break;
        }
    }
    else if (commands[i] == "down")
    {
        squirrelPositionRow++;
        PositionCheck();
        if (onField)
        {
            hazelnutsCount = SquirrelMove(matrix, squirrelPositionRow, squirrelPositionCol, hazelnutsCount);
            onField = BoolOnField(matrix, squirrelPositionRow, squirrelPositionCol, onField);
        }
        if (!onField)
        {
            break;
        }
    }
    else if (commands[i] == "up")
    {
        squirrelPositionRow--;
        PositionCheck();
        if (onField)
        {
            hazelnutsCount = SquirrelMove(matrix, squirrelPositionRow, squirrelPositionCol, hazelnutsCount);
            onField = BoolOnField(matrix, squirrelPositionRow, squirrelPositionCol, onField);
        }
        if (!onField)
        {
            break;
        }
    }

    if (hazelnutsCount == 3)
    {
        Console.WriteLine("Good job! You have collected all hazelnuts!");
        Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
        break;
    }
}

if (hazelnutsCount < 3 && onField)
{
    Console.WriteLine("There are more hazelnuts to collect.");
    Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
}
static void StepOnTrap(int hazelnutsCount)
{
    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
    Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
}
void PositionCheck()
{
    if (squirrelPositionCol < 0 || squirrelPositionRow < 0 || squirrelPositionCol >= n || squirrelPositionRow >= n)
    {
        Console.WriteLine("The squirrel is out of the field.");
        Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
        onField = false;
    }
}
static int SquirrelMove(string[,] matrix, int squirrelPositionRow, int squirrelPositionCol, int count)
{
    if (matrix[squirrelPositionRow, squirrelPositionCol] == "t")
    {
        StepOnTrap(count);
    }
    else if (matrix[squirrelPositionRow, squirrelPositionCol] == "h")
    {
        matrix[squirrelPositionRow, squirrelPositionCol] = "s";
        count++;
    }
    else
    {
        matrix[squirrelPositionRow, squirrelPositionCol] = "s";
    }
    return count;
}
static bool BoolOnField(string[,] matrix, int squirrelPositionRow, int squirrelPositionCol, bool onField)
{
    if (matrix[squirrelPositionRow, squirrelPositionCol] == "t")
    {
        onField = false;
    }
    return onField;
}

// alternative 

//int fieldSize = int.Parse(Console.ReadLine());
//
//Queue<string> commands = new Queue<string>(Console.ReadLine()
//    .Split(", ", StringSplitOptions.RemoveEmptyEntries));
//
//string[,] field = new string[fieldSize, fieldSize];
//
//bool isTrappedOrLeft = false;
//
//int sqRow = -1;
//int sqCol = -1;
//
//for (int i = 0; i < field.GetLength(0); i++)
//{
//    string row = Console.ReadLine();
//
//    for (int j = 0; j < field.GetLength(1); j++)
//    {
//        field[i, j] = row[j].ToString();
//        if (field[i, j] == "s")
//        {
//            sqRow = i;
//            sqCol = j;
//            field[i, j] = "*";
//        }
//    }
//}
//
//int hazelnutsCollected = 0;
//
//while (hazelnutsCollected < 3 && commands.Any())
//{
//    string direction = commands.Dequeue();
//
//    if (OutOfBounds(direction, sqCol, sqRow, field) ||
//        PositionIsATrap(direction, sqCol, sqRow, field))
//    {
//        break;
//    }
//
//    switch (direction)
//    {
//        case "left":
//            sqCol--;
//            break;
//        case "right":
//            sqCol++;
//            break;
//        case "up":
//            sqRow--;
//            break;
//        case "down":
//            sqRow++;
//            break;
//    }
//
//    if (field[sqRow, sqCol] == "h")
//    {
//        hazelnutsCollected++;
//        field[sqRow, sqCol] = "*";
//    }
//}
//
//if (!isTrappedOrLeft)
//{
//    if (hazelnutsCollected == 3)
//    {
//        Console.WriteLine($"Good job! You have collected all hazelnuts!");
//    }
//    else
//    {
//        Console.WriteLine($"There are more hazelnuts to collect.");
//    }
//}
//
//
//Console.WriteLine($"Hazelnuts collected: {hazelnutsCollected}");
//
//bool PositionIsATrap(string direction, int sqCol, int sqRow, string[,] field)
//{
//    switch (direction)
//    {
//        case "left":
//            sqCol--;
//            break;
//        case "right":
//            sqCol++;
//            break;
//        case "up":
//            sqRow--;
//            break;
//        case "down":
//            sqRow++;
//            break;
//    }
//
//    if (field[sqRow, sqCol] == "t")
//    {
//        Console.WriteLine($"Unfortunately, the squirrel stepped on a trap...");
//        isTrappedOrLeft = true;
//        return true;
//    }
//    return false;
//}
//
//bool OutOfBounds(string direction, int sqCol, int sqRow, string[,] field)
//{
//    if ((direction == "left" && sqCol == 0) ||
//        (direction == "right" && sqCol == field.GetLength(1) - 1) ||
//        (direction == "up" && sqRow == 0) ||
//        (direction == "down" && sqRow == field.GetLength(0) - 1))
//    {
//        Console.WriteLine($"The squirrel is out of the field.");
//        isTrappedOrLeft = true;
//        return true;
//    }
//
//    return false;
//}