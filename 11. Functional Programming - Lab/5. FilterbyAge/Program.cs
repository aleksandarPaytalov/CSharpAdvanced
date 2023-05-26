using System.Threading.Channels;

List<Person> people = new List<Person>();

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(", ");
    people.Add(new Person() { Name = input[0], Age = int.Parse(input[1]) });
}

string filterType = Console.ReadLine();
int ageFilter = int.Parse(Console.ReadLine());
string formatType = Console.ReadLine();

Func<Person, bool> filter = GetFilter(filterType, ageFilter);
people = people.Where(filter).ToList();

Action<Person> printer = Printer(formatType);

foreach (var person in people)
{
    printer(person);
}

Func<Person, bool> GetFilter(string filterType, int ageFilter)
{
    switch (filterType)
    {
        case "older": return person => person.Age >= ageFilter;
        case "younger": return person => person.Age < ageFilter;
        default:
            return null;    
    }
}
Action<Person> Printer(string? formatType)
{
    switch (formatType)
    {
        case "name age": return person => Console.WriteLine($"{person.Name} - {person.Age}");
        case "name": return person => Console.WriteLine($"{person.Name}");
        case "age": return person => Console.WriteLine($"{person.Age}");
        default:
            return null;
    }
}

class Person
{ 
    public string Name { get; set; }
    public int Age { get; set; }

}