int rowCount = int.Parse(Console.ReadLine());

int[][] jaggedArray = new int[rowCount][];
for (int row = 0; row < jaggedArray.Length; row++)
{
    jaggedArray[row] = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
}

string command = string.Empty;
while ((command = Console.ReadLine()) != "END") 
{
    string[] cmd = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string cmdType = cmd[0];
    int row = int.Parse(cmd[1]);
    int col = int.Parse(cmd[2]);
    int number = int.Parse(cmd[3]);

    if (cmdType == "Add")
    {
        AddOperation(cmdType, row, col, number);        
    }
    else if (cmdType == "Subtract")
    {
        SubtractOperation(cmdType, row, col, number);    
    }

}


for (int row = 0; row < jaggedArray.Length; row++)
{
    for (int col = 0; col < jaggedArray[row].Length; col++)
    {
        Console.Write($"{jaggedArray[row][col]} ");
    }
    Console.WriteLine();
}
void AddOperation(string cmdType, int row, int col, int number)
{
    if (row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray.Length)
    {
        jaggedArray[row][col] = jaggedArray[row][col] + number;
    }
    else
    {
        Console.WriteLine("Invalid coordinates");
    }
}
void SubtractOperation(string cmdType, int row, int col, int number)
{
    if (row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray.Length)
    {
        jaggedArray[row][col] = jaggedArray[row][col] - number;
    }
    else
    {
        Console.WriteLine("Invalid coordinates");
    }
}