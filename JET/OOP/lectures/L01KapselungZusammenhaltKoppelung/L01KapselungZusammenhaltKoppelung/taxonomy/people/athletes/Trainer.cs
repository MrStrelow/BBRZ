using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class Trainer : Human
{
    // Koppelung: Trainer kümmer sich um was der Verein für eine Datenstruktur ist.
    // TODO: hier dependency injection.
    public ICollection<SportClub> TrackRecord { get; set; } = new List<SportClub>();
    public SportClub CurrentClub { get; set; }
    public TrainerExchange TrainerExchange { get; set; }
    
    public Trainer(
        PersonalInformation data, Authentication id, 
        SportClub currentClub, TrainerExchange trainerExchange
    ) : base(data, id)
    {
        CurrentClub = currentClub;
        TrainerExchange = trainerExchange;
    }

    // Haben wir vor Human als simples Objekt ohne Methoden zu haben?
    // hier haben wir aber einen Fall wo wir funktionalität haben.
    // soll das ausgelagert werden da sich das Verhalten von den anderen Humans unterscheidet?
    // eineigener Service? oder ist das overkill? was sagt die Datenbank?
    public void leaveClub()
    {
        Console.WriteLine($"{this} is leaving {CurrentClub}...");
        
        CurrentClub = TrainerExchange.signContractWithCoach(this);

        Console.WriteLine($"... and starts at {CurrentClub}");
    }
}
