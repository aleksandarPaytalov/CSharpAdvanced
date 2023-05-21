int cmdNumber = int.Parse(Console.ReadLine());

Dictionary<string, List <decimal>> studentsGrade = new();
for (int i = 0; i < cmdNumber; i++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string name = input[0];
    decimal grade = decimal.Parse(input[1]);

    if (!studentsGrade.ContainsKey(name))
    {
        studentsGrade.Add(name, new List<decimal>());
    }
    studentsGrade[name].Add(grade);
}

foreach (var item in studentsGrade)
{
    Console.Write($"{item.Key} -> ");

    foreach (var grade in item.Value)
    {
        Console.Write($"{grade:f2} ");
    }
    Console.WriteLine($"(avg: {item.Value.Average():f2})");
}