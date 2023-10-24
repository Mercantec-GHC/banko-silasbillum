

List<List<string>> Silas = new List<List<string>>();

Silas.Add(new List<string> { "12", "23", "61", "70", "80" });
Silas.Add(new List<string> { "16", "25", "35", "62", "72" });
Silas.Add(new List<string> { "9", "36", "49", "58", "75" });


Silas.Add(new List<string> { "2", "21", "30", "74", "82" });
Silas.Add(new List<string> { "22", "32", "43", "56", "67" });
Silas.Add(new List<string> { "14", "28", "38", "77", "89" });

Silas.Add(new List<string> { "21", "31", "44", "71", "80" });
Silas.Add(new List<string> { "8", "32", "47", "53", "64" });
Silas.Add(new List<string> { "9", "18", "37", "49", "88" });



foreach (var numbers in Silas)
{
    
    Console.WriteLine(string.Join(" ", numbers));
    
}

List<bool> listsMatched = new List<bool>(Silas.Count);

foreach (var list in Silas)
{
    listsMatched.Add(false);
}

int currentSet = 0;
const int cardsPerSet = 3;
int listsCompletedInCurrentCard = 0;

while (true)
{
    string trukket = Console.ReadLine() ?? "";
    bool found = false;

    for (int i = 0; i < Silas.Count; i++)
    {
        if (Silas[i].Contains(trukket))
        {
            Console.WriteLine($"{trukket} er trukket på Række {i + 1} på card {currentSet + 1}");
            Silas[i].Remove(trukket);

            if (Silas[i].Count == 0 && !listsMatched[i])
            {
                listsCompletedInCurrentCard++;
                listsMatched[i] = true;
            }

            found = true;
            break;
        }
    }

    if (!found)
    {
        Console.WriteLine($"{trukket} er ikke på pladen");
    }

    if (listsCompletedInCurrentCard == 1)
    {
        Console.WriteLine($"Første række færdig på sæt {currentSet / cardsPerSet + 1}");
    }
    else if (listsCompletedInCurrentCard == 2)
    {
        Console.WriteLine($"Anden række færdig på sæt {currentSet / cardsPerSet + 1}");
    }

    if (listsMatched.All(matched => matched))
    {
        Console.WriteLine($"Sæt {currentSet + 1} er fuldstændigt trukket!");

        if (currentSet % cardsPerSet == cardsPerSet - 1)
        {
            Console.WriteLine("Alle rækker er fuldstændigt trukket!");
        }
    }
}
