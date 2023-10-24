

List<List<string>> List1 = new List<List<string>>();
List<List<string>> List2 = new List<List<string>>();
List<List<string>> List3 = new List<List<string>>();

List1.Add(new List<string> { "12", "23", "61", "70", "80" });
List1.Add(new List<string> { "16", "25", "35", "62", "72" });
List1.Add(new List<string> { "9", "36", "49", "58", "75" });

List2.Add(new List<string> { "2", "21", "30", "74", "82" });
List2.Add(new List<string> { "22", "32", "43", "56", "67" });
List2.Add(new List<string> { "14", "28", "38", "77", "89" });

List3.Add(new List<string> { "21", "31", "44", "71", "80" });
List3.Add(new List<string> { "8", "32", "47", "53", "64" });
List3.Add(new List<string> { "9", "18", "37", "49", "88" });

List<List<List<string>>> allLists = new List<List<List<string>>>
{
    List1,
    List2,
    List3
};


List<List<bool>> listsMatched = new List<List<bool>>();
foreach (var bingoList in allLists)
{
    List<bool> matched = new List<bool>(bingoList.Count);
    listsMatched.Add(matched);
}

for (int i = 0; i < allLists.Count; i++)
{
    Console.WriteLine($"Kort {i + 1}:");
    foreach (var bingoList in allLists[i])
    {
        Console.WriteLine(string.Join(" ", bingoList));
    }
    Console.WriteLine();
}

int currentSet = 0;
const int cardsPerSet = 3;
int listsCompletedInCurrentCard = 0;

while (true)
{
    string trukket = Console.ReadLine() ?? "";
    bool found = false;
    int listIndex = -1;

    for (int i = 0; i < allLists.Count; i++)
    {
        for (int j = 0; j < allLists[i].Count; j++)
        {
            if (allLists[i][j].Contains(trukket))
            {
                Console.WriteLine($"{trukket} er trukket på Række {j + 1} på kort {currentSet + 1} i Liste {i + 1}");
                allLists[i][j].Remove(trukket);

                if (allLists[i][j].Count == 0 && !listsMatched[i][j])
                {
                    Console.WriteLine($"Sæt {currentSet + 1} er fuldstændigt trukket!");
                    listsCompletedInCurrentCard++;
                    listsMatched[i][j] = true;
                }

                found = true;
                listIndex = i;
                break;
            }
        }
        if (found) break;
    }

    if (!found)
    {
        Console.WriteLine($"{trukket} er ikke på pladen");
    }

    if (listsCompletedInCurrentCard == allLists.Count)
    {
        Console.WriteLine($"Sæt {currentSet + 1} er trukkethjj!");

        if (currentSet % cardsPerSet == 0)
        {
            Console.WriteLine("Alle rækker er fuldstændigt trukket!");
        }

    }

    if (listIndex >= 0 && listsMatched[listIndex].All(matched => matched))
    {
        Console.WriteLine($"Sæt {currentSet + 1} er fuldstændigt trukket!");
    }

    if (listsCompletedInCurrentCard == allLists.Count)
    {
        currentSet++;  
        listsCompletedInCurrentCard = 0;  
    }
}
