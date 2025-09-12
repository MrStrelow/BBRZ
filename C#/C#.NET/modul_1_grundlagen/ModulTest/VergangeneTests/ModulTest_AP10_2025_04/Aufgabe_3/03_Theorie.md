* Ist es vorteilhaft eine ``Methode`` an ein ``Objekt`` zu koppeln? Denke an folgendes Beispiel
```csharp
kunde.Informieren(); // Methode aufrufbar beim Objekt
```

vs.

```csharp
Informieren(willInformiertWerden: kunde, informiertAnderen: bekannterDesKunden); // Funktion welche 2 beliebige Kunden entgegennimmt 
```

> Ja, denn somit kann nur ein ``Objekt`` der ``Klasse`` *Kunde* die *Informieren* ``Methode`` verwenden. Wenn eine Methode verwendet wird, müssen wir uns auch nicht darum kümmern ob der *Kunde* einen *bekanntenKunden* hat. Die Aufrufe werden schlanker.