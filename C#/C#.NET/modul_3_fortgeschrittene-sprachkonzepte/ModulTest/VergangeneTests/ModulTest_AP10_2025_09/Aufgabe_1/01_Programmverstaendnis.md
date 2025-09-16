1) Berechne höchste AktulleMessung aus Wien
```csharp
var sensorInWien = sensoren.Select(sensor => sensor.Ort == "Wien" && sensor.AktuelleMessung >= -50).Max(sensor => sensor.AktuelleMessung);
```
* Falsch
* Der ``LINQ`` Ausdruck Filter existiert nicht. Es sollte ``Where`` heißen was ein Zeilenfilter bzw. elementwise filter ist. (In der Fachsprache ist es eine Restriktion oder sehr verwirrend, Selektion.)
>**Korrekt wäre:** (nicht gefragt, aber angenehmer zum Lernen) 
```csharp
var sensorInWien = sensoren.Where(sensor => sensor.Ort == "Wien" && sensor.AktuelleMessung >= -50).Max(sensor => sensor.AktuelleMessung);
```

2) Sensoren aufsteigend sortiert, jedoch nur Ort und AktuelleMessung wird angezeigt

```csharp 
Sensor messungMitOrt = sensoren.OrderBy(s => s.InBetriebSeit).Select(s => new { s.Ort, s.AktuelleMessung });
```
* Falsch
* Der ``Typ`` der ``Variable`` *messungMitOrt* ist nicht *Sensor* sondern eine *Liste* von ``anonymen Typen``.

>**Korrekt wäre:** (nicht gefragt, aber angenehmer zum Lernen) 
```csharp
var messungMitOrt = sensoren.OrderBy(s => s.InBetriebSeit).Select(s => new { s.Ort, s.AktuelleMessung });
```

3) Durchschnittliche aktuelle Messung der Temperatur pro Ort
```csharp
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
```
* Richtig