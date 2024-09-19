using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class Trainer : Human
{
    // Koppelung: Trainer kümmer sich um was der Verein für eine Datenstruktur ist.
    public ICollection<Club> TrackRecord { get; set; } = new List<Club>();
    public Club CurrentClub { get; set; }
    public ClubExchange ClubExchange { get; set; }
    
    public Trainer(PersonalInformation data, Authentication id, Club currentClub, ClubExchange clubExchange) : base(data, id)
    {
        CurrentClub = currentClub;
        ClubExchange = clubExchange;
    }

    // Haben wir vor Human als simples Objekt ohne Methoden zu haben?
    // hier haben wir aber einen Fall wo wir funktionalität haben.
    // soll das ausgelagert werden da sich das Verhalten von den anderen Humans unterscheidet?
    // eineigener Service? oder ist das overkill? was sagt die Datenbank?
    public void leaveClub()
    {
        Console.WriteLine($"{this} is leaving {CurrentClub}...");
        
        CurrentClub = ClubExchange.signContractWithCoach(this);

        Console.WriteLine($"... and starts at {CurrentClub}");
    }
}
