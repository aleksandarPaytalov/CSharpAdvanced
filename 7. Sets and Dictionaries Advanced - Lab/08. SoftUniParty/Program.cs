HashSet<string> reservationsVIP = new();
HashSet<string> reservationsRegular = new();
string input = string.Empty;

while ((input = Console.ReadLine()) != "PARTY")
{    
    char firstLetter = input[0];
    if (char.IsDigit(firstLetter))
    {
        reservationsVIP.Add(input);
    }
    else
    {
        reservationsRegular.Add(input);
    }    
}
while ((input = Console.ReadLine()) != "END")
{
    if (reservationsVIP.Contains(input))
    {
        reservationsVIP.Remove(input);
    }
    if (reservationsRegular.Contains(input))
    {
        reservationsRegular.Remove(input);
    }
}
Console.WriteLine(reservationsVIP.Count+reservationsRegular.Count);
foreach (var item in reservationsVIP)
{
    Console.WriteLine(item);
}
foreach (var item in reservationsRegular)
{
    Console.WriteLine(item);
}