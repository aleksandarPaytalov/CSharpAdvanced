Func<string, int, bool> checkEqualOrLargerNameSum =    
    (name, sum) =>
    {
        int charsSum = name.Sum(ch => ch);

        return charsSum >= sum;
    };


Func<string[], int, Func<string, int, bool>, string> firstName =   
    (names, sum, match) =>
    {
        foreach (var name in names)
        {
            if (match(name, sum))
            {
                return name;
            }
        }

        return null;
    };

int sum = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string foundName = firstName(names, sum, checkEqualOrLargerNameSum);

Console.WriteLine(foundName);