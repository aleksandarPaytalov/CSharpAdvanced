Dictionary<string, string> contestsCredentials = new();
SortedDictionary<string, Dictionary<string, int>> candidatesStats = new();

string command = string.Empty;
while ((command = Console.ReadLine()) != "end of contests")
{

    string[] credentials = command.Split(":", StringSplitOptions.RemoveEmptyEntries);

    contestsCredentials.Add(credentials[0], credentials[1]);
}

while ((command = Console.ReadLine()) != "end of submissions")
{
    string[] tokens = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);

    string contest = tokens[0];
    string pass = tokens[1];
    string candidateName = tokens[2];
    int points = int.Parse(tokens[3]);

    if (contestsCredentials.ContainsKey(contest) && contestsCredentials[contest] == pass)
    {
        if (!candidatesStats.ContainsKey(candidateName))
        {
            candidatesStats.Add(candidateName, new Dictionary<string, int>());
        }

        if (!candidatesStats[candidateName].ContainsKey(contest))
        {
            candidatesStats[candidateName].Add(contest, 0);
        }

        if (candidatesStats[candidateName][contest] < points)
        {
            candidatesStats[candidateName][contest] = points;
        }
    }
}

string bestCandidate = candidatesStats
    .OrderByDescending(c => c.Value.Values.Sum())
    .First().Key;

//string bestCandidate = candidatesStats.MaxBy(c => c.Value.Values.Sum()).Key;

int bestCandidateTotalPoints = candidatesStats[bestCandidate].Values.Sum();

Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidateTotalPoints} points.");
Console.WriteLine("Ranking:");

foreach (var candidate in candidatesStats)
{
    Console.WriteLine(candidate.Key);

    Dictionary<string, int> ordered = candidate.Value
        .OrderByDescending(c => c.Value)
        .ToDictionary(c => c.Key, c => c.Value);

    foreach (var contest in ordered)
    {
        Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
    }
}
