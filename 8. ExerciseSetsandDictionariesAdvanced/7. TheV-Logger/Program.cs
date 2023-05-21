string input = string.Empty;

Dictionary<string, Dictionary<string, HashSet<string>>> vlogersStatistic = new();

while ((input = Console.ReadLine()) != "Statistics")
{
    string[] vlogerInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string vlogerName = vlogerInfo[0];
    string command = vlogerInfo[1];
    string vlogerToFollow = vlogerInfo[2];

    if (command == "joined" && !vlogersStatistic.ContainsKey(vlogerName))
    {
        vlogersStatistic.Add(vlogerName, new());
        vlogersStatistic[vlogerName].Add("followers", new HashSet<string>());
        vlogersStatistic[vlogerName].Add("following", new HashSet<string>());
    }
    else if (command == "followed"
        && vlogersStatistic.ContainsKey(vlogerToFollow)
        && vlogersStatistic.ContainsKey(vlogerName)
        && vlogerName != vlogerToFollow)
    {
        vlogersStatistic[vlogerToFollow]["followers"].Add(vlogerName);
        vlogersStatistic[vlogerName]["following"].Add(vlogerToFollow);
    }

}
Console.WriteLine($"The V-Logger has a total of {vlogersStatistic.Count} vloggers in its logs.");
Dictionary<string, Dictionary<string, HashSet<string>>> sortedVlogers =
    vlogersStatistic.OrderByDescending(x => x.Value["followers"].Count)
    .ThenBy(x => x.Value["following"].Count).ToDictionary(x => x.Key, x => x.Value);

int count = 1;
foreach (var vloger in sortedVlogers)
{
    Console.WriteLine($"{count}. {vloger.Key} : {vloger.Value["followers"].Count} followers, {vloger.Value["following"].Count} following");

    if (count == 1)
    {
        List<string> sorterFollowers = vloger.Value["followers"].OrderBy(x => x).ToList();

        foreach (var follower in sorterFollowers)
        {
            Console.WriteLine($"*  {follower}");
        }    
    }
    count++;
}