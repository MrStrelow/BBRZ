- a) Finde die Fehler in diesem Code und markiere diese.
- b) Erkläre wieso diese Fehler zu einer nicht gültigen `Guard Clause` führen. 

a) ✅ b) ✅
```csharp
if (kunde == null)
    throw new ArgumentNullException("Kunde darf nicht null sein.");
```

---

a) 💢 
b) Wir haben einen ``else`` Zweig welcher uns frühzeitig das Programm beendet. 
* Es soll nur in schlechten Fällen das Programm frühzeitig beendet werden (``early exit``) - else ist hier aber ein positiver Fall.
* Das führt dazu dass wir die folgenden Guards nicht mehr überprüfen. 
```csharp
(!kunde.IstAktiv)
{
    Console.WriteLine("Der Kunde ist nicht aktiv. Vorgang abgebrochen.");
    return;
}
else 
{
    Console.WriteLine("Der Kunde ist aktiv.");
    return;
}
```

---

a) 💢 
b) Exit der Methode fehlt und **negation des Ausdrucks ist falsch**: 
  - wie 'return;' oder 'throw new Exception("");'. 
  - Ein Fehlen des Exits in der Methode bedeutet, der Code wird nicht abgebrochen bei Verletzung einer Guard.
     Es wird dadurch möglicherweise ein gültiger Zustand erreicht, auch wenn dies nicht beabsichtigt war. 
     Anders gesagt, Guards sind die "security checks", welche wir bei Verletzung nicht passieren dürfen. 
     Passieren bedeutet hier im Code weiter zur nächsten Guard weiter gehen.
  - Ein logisches ODER kann als ein 'untereinandergeschriebenes IF-Bedingungen' dargestellt werden. 
     Da wir, wenn A wahr ist und unsere Formel A || B || C ist, wir B und C nicht mehr überprüfen wollen, 
     brauchen wir innerhalb jeder IF Bedingung, dazu noch einen "Exit-Punkt" (return; bzw. throw new Exception();).

```csharp
if (!string.IsNullOrEmpty(kunde.Kundenkarte))
{
    Console.WriteLine("Der Kunde hat keine Kundenkarte.");
}
```

---

a) 💢
b) Wir haben in unserer logischen ``Formel`` ein logisches ODER welches mit dem ``literal`` true verknüpft ist. Diese ``Formel`` wertet immer auf ``true`` aus und erzeugt somit immer eine abgelaufene Mitgliedschaft.
```csharp
if (kunde.MitgliedschaftGueltigBis <= DateTime.Now || true)
    throw new KundenCheckException("Die Mitgliedschaft des Kunden ist abgelaufen.");

Console.WriteLine("Alle Überprüfungen bestanden. Der Kunde darf einkaufen!");
```