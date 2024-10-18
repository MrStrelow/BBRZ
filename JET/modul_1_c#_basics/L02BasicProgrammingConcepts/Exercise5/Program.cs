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


// ... dieses Programm hier.
Console.WriteLine("----------Guard Clauses----------");

if (!userExistiert)
{
    Console.WriteLine("Fehler 1!");
    Environment.Exit(0);
    // oder
    //return;
}

if (!userIstAltGenug)
{
    Console.WriteLine("Fehler 2!");
    Environment.Exit(0);
}

if (!userIstPremiumAccount)
{
    Console.WriteLine("Fehler 3!");
    Environment.Exit(0);
}

if (!ressourceExistiert)
{
    Console.WriteLine("Fehler 4!");
    Environment.Exit(0);
}

if (!userIstUnauffaellig)
{
    Console.WriteLine("Fehler 5!");
    Environment.Exit(0);
}

if (!ressourceIstAmNeuestenStand)
{
    Console.WriteLine("Fehler 6!");
    Environment.Exit(0);
}

if (!ressourceUnauffaellig)
{
    Console.WriteLine("Fehler 7!");
    Environment.Exit(0);
}

Console.WriteLine("Passt! User bekommt was er will.");