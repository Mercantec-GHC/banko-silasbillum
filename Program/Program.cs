

List<List<string>> List1 = new List<List<string>>();
List<List<string>> List2 = new List<List<string>>();
List<List<string>> List3 = new List<List<string>>();
List<List<string>> List4 = new List<List<string>>();
List<List<string>> List5 = new List<List<string>>();
//silas Kort 1
List1.Add(new List<string> { "12", "23", "61", "70", "80" });
List1.Add(new List<string> { "16", "25", "35", "62", "72" });
List1.Add(new List<string> { "9", "36", "49", "58", "75" });
//Mikkelsen Kort 2
List2.Add(new List<string> { "2", "21", "31", "52", "60" });
List2.Add(new List<string> { "5", "17", "43", "54", "87" });
List2.Add(new List<string> { "9", "57", "67", "75", "88" });
//Tanja Kort 3
List3.Add(new List<string> { "20", "30", "40", "62", "72" });
List3.Add(new List<string> { "5", "16", "55", "65", "82" });
List3.Add(new List<string> { "7", "17", "26", "38", "69" });
//Asta Kort 4
List4.Add(new List<string> { "1", "11", "20", "40", "55" });
List4.Add(new List<string> { "21", "35", "48", "57", "84" });
List4.Add(new List<string> { "13", "58", "66", "77", "87" });
//Elias Kort 5
List5.Add(new List<string> { "1", "10", "61", "70", "80" });
List5.Add(new List<string> { "24", "33", "41", "52", "76" });
List5.Add(new List<string> { "29", "48", "56", "78", "83" });

List<List<List<string>>> allLists = new List<List<List<string>>>
{
    List1,
    List2,
    List3,
    List4,
    List5

};


bool[][] listsMatched = new bool[5][];
for (int i = 0; i < allLists.Count(); i ++)
{
    bool[] matched = new bool[3];
    listsMatched[i] = matched;
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
        int fullyMatchedRowCount = 0;

        for (int j = 0; j < allLists[i].Count; j++)
        {
            if (allLists[i][j].Contains(trukket))
            {
                Console.WriteLine($"{trukket} er trukket på Række {j + 1} på kort {i + 1}");
                allLists[i][j].Remove(trukket);

                if (allLists[i][j].Count == 0 && !listsMatched[i][j])
                {
                    Console.WriteLine($"Række {j + 1} er fuldstændigt trukket! på kort {i + 1}");
                    listsCompletedInCurrentCard++;
                    listsMatched[i][j] = true;
                }

                found = true;
                listIndex = i;
                break;
            }
            if (listsMatched[i][j])
            {
                fullyMatchedRowCount++;
            }
        }
         if (fullyMatchedRowCount == 2)
        {
            Console.WriteLine($"Kort {i + 1} har 2 rækker fuldstændigt trukket!");
            
            
        }

        if (listIndex >= 0 && listsMatched[listIndex].All(matched => matched))
        {
            Console.WriteLine($"Kort {i + 1} er fuldstændigt trukket!");
            break;
        }

    }

   

    if (listsCompletedInCurrentCard == allLists.Count)
    {
        Console.WriteLine($"Sæt {currentSet + 1} er trukket!");

        if (currentSet % cardsPerSet == 0)
        {
            Console.WriteLine("Alle rækker er fuldstændigt trukket!");
        }

    }

    

    
    if (!found)
    {
        Console.WriteLine($"{trukket} er ikke på pladen");
    }
}