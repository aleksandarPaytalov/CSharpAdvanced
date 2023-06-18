Queue<char> vowels = new Queue<char>(Console.ReadLine()
    .Split()
    .Select(char.Parse));
Stack<char> consonants = new Stack<char>(Console.ReadLine()
    .Split()
    .Select(char.Parse));

string pear = "pear";
string flour = "flour";
string pork = "pork";
string olive = "olive";

string pearToAdd = "pear";
string flourToAdd = "flour";
string porkToAdd = "pork";
string oliveToAdd = "olive";

int pearCount = pear.Count();
int flourCount = flour.Count();
int porkCount = pork.Count();
int oliveCount = olive.Count();

int vowelsCount = 0;
int vowelsTrack = vowels.Count;


while (consonants.Count > 0)
{
    char currentVowel = vowels.Dequeue();
    char currentConsonant = consonants.Pop();

    if (vowelsCount < vowelsTrack)
    {
        if (pear.Contains(currentVowel) && pearCount > 0)
        {
            pear = pear.Replace(currentVowel.ToString(), "");
            pearCount--;
        }
        if (flour.Contains(currentVowel) && flourCount > 0)
        {
            flour = flour.Replace(currentVowel.ToString(), "");
            flourCount--;
        }
        if (pork.Contains(currentVowel) && porkCount > 0)
        {
            pork = pork.Replace(currentVowel.ToString(), "");
            porkCount--;
        }
        if (olive.Contains(currentVowel) && oliveCount > 0)
        {
            olive = olive.Replace(currentVowel.ToString(), "");
            oliveCount--;
        }
        vowelsCount++;
        vowels.Enqueue(currentVowel);
    }


    if (pear.Contains(currentConsonant))
    {
        pear = pear.Replace(currentConsonant.ToString(), "");
        pearCount--;
    }
    if (flour.Contains(currentConsonant))
    {
        flour = flour.Replace(currentConsonant.ToString(), "");
        flourCount--;
    }
    if (pork.Contains(currentConsonant))
    {
        pork = pork.Replace(currentConsonant.ToString(), "");
        porkCount--;
    }
    if (olive.Contains(currentConsonant))
    {
        olive = olive.Replace(currentConsonant.ToString(), "");
        oliveCount--;
    }
}

List<string> findings = new List<string>();

if (pear.Length == 0)
{
    findings.Add(pearToAdd);
}
if (flour.Length == 0)
{
    findings.Add(flourToAdd);
}
if (pork.Length == 0)
{
    findings.Add(porkToAdd);
}
if (olive.Length == 0)
{
    findings.Add(oliveToAdd);
}

Console.WriteLine($"Words found: {findings.Count}");
foreach (var find in findings)
{
    Console.WriteLine(find);
}