 - a) Finde die Fehler in diesem Code und markiere diese.
 - b) Erkläre wieso diese Fehler zu einer nicht gültigen `Guard Clause` führen. 

a) ✅ b) 
```csharp
if (pilot == null){
    throw new ArgumentNullException("Pilot darf nicht null sein.");
}
```

a) 💢 
b) Verneinung '!' der logischen Formel in der IF-Bedingung fehlt. 
   Dadurch verwenden wir die logische Formel für einen ✅ gültigen Zustand und nicht für den 💢 fehlerhaften.
   Wir brechen also ab, wenn wir es nicht tun sollten.
```csharp
if (pilot.HasLicense)
{
    Console.WriteLine("Der Pilot besitzt keine gültige Lizenz. Start abgebrochen.");
    return;
}
```

a) 💢 
b) Exit der Methode fehlt: 
   - wie 'return;' oder 'throw new Exception("");'. 
   - Ein Fehlen des Exits in der Methode bedeutet, der Code wird nicht abgebrochen bei Verletzung einer Guard.
     Es wird dadurch möglicherweise ein gültiger Zustand erreicht, auch wenn dies nicht beabsichtigt war. 
     Anders gesagt, Guards sind die "security checks", welche wir bei Verletzung nicht passieren dürfen. 
     Passieren bedeutet hier im Code weiter zur nächsten Guard weiter gehen.
   - Ein logisches ODER kann als ein 'untereinandergeschriebenes IF-Bedingungen' dargestellt werden. 
     Da wir, wenn A wahr ist und unsere Formel A || B || C ist, wir B und C nicht mehr überprüfen wollen, 
     brauchen wir innerhalb jeder IF Bedingung, dazu noch einen "Exit-Punkt" (return; bzw. throw new Exception();).
```csharp
if (!pilot.IsMedicallyCleared)
{
    Console.WriteLine("Der Pilot hat keine aktuelle medizinische Freigabe.");
}
```

a) 💢
b) "return;" ist vor der aufzurufenden Exception. 
   Falsche Reihenoflge und redundanter ("doppelte") Aufruf eines Methoden-Exits.
   Logisch für die Guard-Clause gesehen ist das nicht sehr schlimm, da wir einen Methoden-Exit haben.
   Jedoch ist es hier ein Kompilerfehler, welches einen Start des Programmes verhindert.
```csharp
if (!aircraft.IsOperational)
{
    return;
    throw new PilotCheckException("Das Flugzeug ist nicht betriebsbereit.");
}

Console.WriteLine("Alle Checks bestanden. Der Flug kann starten!");
```