Wir üben folgende Konzepte der Programmiersprache:
* verschachtelte IF-Verzweigungen

Welches Konzept üben wir hier?
* Guard Clauses vs. verschachtelte IF

## 3. Guard Clauses
* Schreibe folgendes verschachtelte If in eine Guard Clause um.

```csharp
Boolean userExistiert = false;
Boolean userIstAltGenug = false;
Boolean userIstPremiumAccount = true;
Boolean userIstUnauffaellig = true;

Boolean ressourceExistiert = false;
Boolean ressourceIstAmNeuestenStand = true;
Boolean ressourceUnauffaellig = true;

Console.WriteLine("----------Verschachteltes IF----------");

if (userExistiert)
{
    if (userIstAltGenug)
    {
        if (userIstPremiumAccount)
        {
            if (userIstUnauffaellig)
            {
                if (ressourceExistiert)
                {
                    if (ressourceIstAmNeuestenStand)
                    {
                        if (ressourceUnauffaellig)
                        {
                            Console.WriteLine("Passt! User bekommt was er will.");
                        }
                        else
                        {
                            Console.WriteLine("Fehler 7!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Fehler 6!");
                    }
                }
                else
                {
                    Console.WriteLine("Fehler 5!");
                }
            }
            else
            {
                Console.WriteLine("Fehler 4!");
            }
        }
        else
        {
            Console.WriteLine("Fehler 3!");
        }
    }
    else
    {
        Console.WriteLine("Fehler 2!");
    }
}
else
{
    Console.WriteLine("Fehler 1!");
}
```