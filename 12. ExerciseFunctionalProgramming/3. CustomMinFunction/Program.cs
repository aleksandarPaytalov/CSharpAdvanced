//Func<int[], int> func = num => num.Min();
//
//int[] numbers = Console.ReadLine()
//    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
//    .Select(int.Parse)
//    .ToArray();
//
//Console.WriteLine(func(numbers));



Func<int[], int> min = num => 
{
    int min = int.MaxValue;

    foreach (var number in num)
    {
        if (number < min)
        {
            min = number;
        }
    }
    return min;
};

int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Console.WriteLine(min(numbers));