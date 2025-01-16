```csharp
// ✅Passt
if (pilot == null){
    throw new ArgumentNullException("Pilot darf nicht null sein.");
}

// 💢Verneinung '!' der logischen Formel in der IF-Bedingung fehlt.
if (pilot.HasLicense)
{
    Console.WriteLine("Der Pilot besitzt keine gültige Lizenz. Start abgebrochen.");
    return;
}

// 💢Exit der Methode fehlt: wie 'return;' oder 'throw new Exception("");'. 
// Dadurch wird nicht abgebrochen und wird möglicherweise ein gültiger Zustand erreicht, auch wenn dies nicht beabsichtigt war. 
// Ein logisches ODER kann als ein 'if untereinander' gschrieben werden. Wir brauchen dazu noch ein wenn es ein exit besitzt.
if (!pilot.IsMedicallyCleared)
{
    Console.WriteLine("Der Pilot hat keine aktuelle medizinische Freigabe.");
}

// 💢return; ist vor der Methode. Falsche Reihenoflge des Methoden-Exit.
if (!aircraft.IsOperational)
{
    return;
    throw new PilotCheckException("Das Flugzeug ist nicht betriebsbereit.");
}

Console.WriteLine("Alle Checks bestanden. Der Flug kann starten!");
```

 - a) Finde die Fehler in diesem Code und markiere diese.
 - b) Erkläre wieso diese Fehler zu einer nicht gültigen `Guard Clause` führen. 
