using System.Text;

namespace ModulTest;

public class Flugzeug
{
    public bool IstGross { get; set; }
}


public class Pilot
{
    // Eigenschaften / Felder
    public bool IsActive { get; set; }
    public int Age { get; set; }
    public string MedicalClearanceCertificate { get; set; }
    public DateTime LicenseExpiry { get; set; }
    public int FlightCount { get; set; }

    // Hat-Beziehungen
    public Flugzeug Flieger { get; set; }

    public void ValidatePilot()
    {
        if (IsActive)
        {
            if (Age >= 18)
            {
                if (!string.IsNullOrEmpty(MedicalClearanceCertificate))
                {
                    if (LicenseExpiry > DateTime.Now)
                    {
                        if (Flieger.IstGross)
                        {
                            if (FlightCount >= 200 && FlightCount <= 500)
                            {
                                Console.WriteLine("✅ Pilot hat zwischen 200 und 500 Flügen. Ein Co-Pilot mit mehr als 500 Flügen ist erforderlich um ein großes Flugzeug fliegen zu können.");
                            }
                            else if (FlightCount > 500)
                            {
                                Console.WriteLine("✅ Pilot hat mehr als 500 Flüge. Dieser Pilot darf ein großes Flugzeug fliegen.");
                            }
                            else
                            {
                                throw new InvalidOperationException("❗Pilot hat zu wenig Flüge für ein Großes Flugzeug.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("✅ Pilot darf das Flugzeug fliegen.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("❗Die Lizenz des Piloten ist abgelaufen.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("❗Pilot besitzt kein medizinisches Freigabezertifikat.");
                }
            }
            else
            {
                throw new InvalidOperationException("❗Pilot muss älter als 18 Jahre sein.");
            }
        }
        else
        {
            throw new InvalidOperationException("❗Pilot ist nicht aktiv.");
        }
    }

    public void ValidatePilotGuardClause()
    {
        // Guards - Abfrage der schlechten Zustände
        if (!IsActive)
            throw new InvalidOperationException("❗Pilot ist nicht aktiv.");

        if (Age <= 18)
            throw new InvalidOperationException("❗Pilot muss älter als 18 Jahre sein.");

        if (string.IsNullOrEmpty(MedicalClearanceCertificate))
            throw new InvalidOperationException("❗Pilot besitzt kein medizinisches Freigabezertifikat.");

        if (LicenseExpiry <= DateTime.Now)
            throw new InvalidOperationException("❗Die Lizenz des Piloten ist abgelaufen.");

        if (Flieger.IstGross && FlightCount < 200)
            throw new InvalidOperationException("❗Pilot hat zu wenig Flüge für ein Großes Flugzeug.");

        // Ausführung der guten Zustände (Daumenregel: ein Nesting mit 2-3 Ebenen ist ok, wennes nur um gute Zustände geht, ohne Fehlerbehandlung.)
        if (Flieger.IstGross)
        {
            if (FlightCount >= 200 && FlightCount <= 500)
            {
                Console.WriteLine("✅ Pilot hat zwischen 200 und 500 Flügen. Ein Co-Pilot mit mehr als 500 Flügen ist erforderlich um ein großes Flugzeug fliegen zu können.");
            }
            else if (FlightCount > 500)
            {
                Console.WriteLine("✅ Pilot hat mehr als 500 Flüge. Dieser Pilot darf ein großes Flugzeug fliegen.");
            }
        }
        else
        {
            Console.WriteLine("✅ Pilot darf das Flugzeug fliegen.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Pilot pilot = new Pilot
        {
            IsActive = true,
            Age = 30,
            MedicalClearanceCertificate = "VeryValidCertificate",
            LicenseExpiry = DateTime.Now.AddMonths(6),
            FlightCount = 300,
            Flieger = new Flugzeug { IstGross = true }
        };

        try
        {
            pilot.ValidatePilot();
            pilot.ValidatePilotGuardClause();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Fehler: {ex.Message}");
        }
    }
}