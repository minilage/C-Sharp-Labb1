// Labb 1

Console.Write("Var vänlig skriv in en valfri sträng:");
string input = Console.ReadLine();
Console.WriteLine();

// Skapa en boolean-array för att markera vilka positioner som är siffror
bool[] isNumber = new bool[input.Length];
for (int i = 0; i < input.Length; i++)
{
    isNumber[i] = (input[i] >= '0' && input[i] <= '9');
}

long totalSum = 0;

// Kontrollera varje tecken i texten för att hitta och skriva ut delsträngar
for (int i = 0; i < input.Length; i++) // Yttre loop för start
{
    if (isNumber[i]) // Kontroll för om i-positionen är en siffra
    {
        for (int k = i + 1; k < input.Length; k++) // Mellanloop för slut
        {
            if (isNumber[k] && input[i] == input[k]) // Kontroll för siffra och att i och k är lika
            {
                bool allNumbers = true;
                bool differentNumbers = false;

                for (int j = i + 1; j < k; j++) // Inre loop för att kontrollera siffror mellan i och k
                {
                    if (!isNumber[j])
                    {
                        allNumbers = false;
                        break;
                    }
                    if (input[j] != input[i]) // Kontrollera om någon siffra mellan är annorlunda
                    {
                        differentNumbers = true;
                    }
                }

                if (allNumbers && differentNumbers && k > i + 1) // Kontrollera att minst en siffra mellan är olika
                {
                    // Skriv ut strängen med aktuell delsträng markerad
                    for (int position = 0; position < input.Length; position++)
                    {
                        if (position >= i && position <= k)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // Markerad delsträng
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray; // Övrig text
                        }
                        Console.Write(input[position]);
                    }
                    // Återställ färgen till standard
                    Console.ResetColor();
                    Console.WriteLine();

                    // Lägg till värdet av den markerade delsträngen till totalsumman
                    string markedSubstring = input.Substring(i, k - i + 1);
                    totalSum += long.Parse(markedSubstring); 
                    break; // Avsluta mellanloopen för att förhindra dubbla upptäckter

                }
            }
        }
    }
}

// Skriv ut en tom rad
Console.WriteLine();

// Skriv ut endast den totala summan av markerade delsträngar
Console.WriteLine($"Total summa av markerade delsträngar: {totalSum}");
