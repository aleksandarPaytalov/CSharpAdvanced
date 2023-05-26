using System.Security.Cryptography.X509Certificates;

int n = int.Parse(Console.ReadLine());

int[][] jaggedArray = new int[n][];
for (int row = 0; row < jaggedArray.Length; row++)
{
	int[] input = Console.ReadLine()
		.Split(" ", StringSplitOptions.RemoveEmptyEntries)
		.Select(int.Parse)
		.ToArray();
	jaggedArray[row] = new int[input.Length];
	for (int col = 0; col < jaggedArray[row].Length; col++)
	{
		jaggedArray[row][col] = input[col];
	}
}

for (int row = 0; row < jaggedArray.Length - 1; row++)
{

	if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
	{
		for (int col = 0; col < jaggedArray[row].Length; col++)
		{
            jaggedArray[row][col] *= 2;
            jaggedArray[row + 1][col] *= 2;
        }		
	}
	else
	{
		for (int col = 0; col < jaggedArray[row].Length; col++)
		{
            jaggedArray[row][col] /= 2;
        }
		for (int col = 0; col < jaggedArray[row + 1].Length; col++)
		{
            jaggedArray[row + 1][col] /= 2;
        } 
    }
}

string command = string.Empty;
while ((command = Console.ReadLine()) != "End")
{
	string[] cmd = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
	string cmdType = cmd[0];
	int currentRow = int.Parse(cmd[1]);
	int currentCol = int.Parse(cmd[2]);
	int value = int.Parse(cmd[3]);

	if (cmdType == "Add"
		&& currentRow >= 0
		&& currentCol >= 0
		&& currentRow < jaggedArray.Length
		&& currentCol < jaggedArray[currentRow].Length)
	{
		jaggedArray[currentRow][currentCol] += value;
	}
	else if (cmdType == "Subtract"
        && currentRow >= 0
		&& currentCol >= 0
		&& currentRow < jaggedArray.Length
		&& currentCol < jaggedArray[currentRow].Length)
	{
        jaggedArray[currentRow][currentCol] -= value;
    }

}

foreach (var item in jaggedArray)
{
    Console.WriteLine(string.Join(" ", item));
}
