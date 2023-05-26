using System;

string text = Console.ReadLine();
//Predicate<string> upper = x => char.IsUpper(x[0]);
Func<string, bool> upper = x => char.IsUpper(x[0]);

string[] upperWords = text
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(upper)
    .ToArray();

foreach (var item in upperWords)
{
    Console.WriteLine(item);
}