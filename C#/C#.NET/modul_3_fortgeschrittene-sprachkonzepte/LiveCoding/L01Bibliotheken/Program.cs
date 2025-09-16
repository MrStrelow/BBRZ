
var sensoren = new List<Sensor>
{
    new Sensor(Ort: "Wien", InBetriebSeit: 18, NächsteWartung: 1, AktuelleMessung: 26),
    new Sensor(Ort: "Innsbruck", InBetriebSeit: 19, NächsteWartung: 2, AktuelleMessung: 29),
    new Sensor(Ort: "Graz", InBetriebSeit: 20, NächsteWartung: 3, AktuelleMessung: 32),
    new Sensor(Ort: "Innsbruck", InBetriebSeit: 21, NächsteWartung: 4, AktuelleMessung: -125124),
    new Sensor(Ort: "Wien", InBetriebSeit: 22, NächsteWartung: 5, AktuelleMessung: -8744156),
    new Sensor(Ort: "Wien", InBetriebSeit: 23, NächsteWartung: 6, AktuelleMessung: 25)
};

// 1) Berechne höchste AktulleMessung aus Wien
var sensorInWien = sensoren.Where(sensor => sensor.Ort == "Wien" && sensor.AktuelleMessung >= -50).Max(sensor => sensor.AktuelleMessung);

// 2) Sensoren aufsteigend sortiert, jedoch nur Ort und AktuelleMessung wird angezeigt
var messungMitOrt = sensoren.OrderBy(s => s.InBetriebSeit).Select(s => new { s.Ort, s.AktuelleMessung });

// 3) Durchschnittliche aktuelle Messung der Temperatur pro Ort
var durchschnittProOrt = sensoren
    .Where(s => s.AktuelleMessung > -50)
    .GroupBy(s => s.Ort)
    .Select(gruppe =>
        new
        {
            Ort = gruppe.Key,
            DurchschnittlicheMessung = gruppe.Average(sensor => sensor.AktuelleMessung)
        }
    );

Console.WriteLine("Durchschnittliche aktuelle Messung der Temperatur pro Ort:");
foreach (var ergebnis in durchschnittProOrt)
{
    Console.WriteLine($"- {ergebnis.Ort}: {Math.Round(ergebnis.DurchschnittlicheMessung, 2)}");
}

public record Sensor(string Ort, int InBetriebSeit, int NächsteWartung, int AktuelleMessung);