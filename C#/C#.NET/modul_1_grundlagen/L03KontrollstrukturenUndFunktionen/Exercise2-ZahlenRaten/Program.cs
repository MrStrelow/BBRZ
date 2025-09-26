using System;
using System.Diagnostics;

class NumberGuessingGame
{
    // Zusammenfassung der Angabe
    // 1.) benutzereingabe von zahlen 0-100

    // 2.) 5 Leben, bei fehler soll eins abgezogen werden.

    // 3.) info ob größer oder kleiner.

    // 4.) falls gewonnen soll dies ausgegeben werden, falls verloren ebenso.

    // 5.) willst du nochmal spielen? (reset von leben, und neue zahl ziehen)

    /*
    Notizen:
        - gameloop -> while ganz außen
        - guessloop -> while für zahlen raten
        - können beide loops zusammenfassen.

        - verzweigung:
        -> genug leben?
        -> guess zu hoch oder zu niedrig?
        -> weiterspielen?

        - funktionsaufruf
        -> zufallszahl erzeugen
        -> userinput
    */
    static void Main()
    {
        Random random = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            int geheimzahl = random.Next(0, 101);
            int leben = 5;
            int maximaleLeben = leben;

            Console.WriteLine("Eine Zahl zwischen 0 und 100 wurde gewählt. Rate die Zahl!");

            // guesloop
            while (leben > 0)
            {
                Console.Write("Gib eine Zahl ein [0-100]: ");
                int guess;
                while (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("Bitte eine gültige Zahl eingeben! Gib eine Zahl ein [0-100]: ");
                }

                leben--;
                int versuche = maximaleLeben - leben;

                // Zusändigkeit: Logik des Ratens
                // Zustand gewonnen
                if (guess == geheimzahl)
                {
                    Console.WriteLine("Glückwunsch! Du hast die Zahl erraten.");
                    break;
                }
                else if (guess > geheimzahl) 
                {
                    Console.WriteLine($"Die Zahl ist kleiner. Du hast noch {leben} Leben.");
                }
                else // guess < geheimzahl
                {
                    Console.WriteLine($"Die Zahl ist größer. Du hast noch {leben} Leben.");
                }

                // Zusändigkeit: Logik des Ratens
                // Zustand verloren
                if (leben == 0)
                {
                    Console.WriteLine($"Leider verloren. Die richtige Zahl war {geheimzahl}. Du hast {versuche} Versuche benötigt.");
                }
            }

            Console.Write("Möchtest du nochmals spielen? [+/-]: ");
            playAgain = Console.ReadLine() == "+";
        }

        Console.WriteLine("Spiel beendet. Danke fürs Spielen!");
    }
}
