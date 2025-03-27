* a) Warum brauchen wir ein ``try-catch`` in der ``Main`` Methode um ``kunde.ValidateKunde();`` sowie miteinander vergleichen zu können ``kunde.ValidateKundeGuardClause();``?
> Ansonsten würde die geworfene ``Exception`` nicht gefangen werden und zu einem Programmabsturz führen. Wir könnten somit nicht die ungewünschten Zustände beider Methoden abfragen. Eine Methode stellt die Logik mit einem ``verschachtelten If-Verzweigung`` dar, die andere eine ``Guard Clause``.

* b) Die gültigen Zustände des Programms sind mit ✅ gekennzeichnet. Können diese zu einem gültigen Zustand ✅ Zusammengefasst werden? 
> Ja und Nein. 
> * **Nein**, wenn es wichtig ist diese zu unterscheiden. Wichtig sind sie, wenn z.B. verschiedener Programm Code ausgeführt wird. Das ist meistens der Fall.
> * Ja, wenn wir nicht an der unterscheidung der korrekten Zustände interessiert sind. Falls wir nur, wie hier in der Aufgabe "Ausgaben an die Konsole schicken" und sonst nichts tun, dann ist es eigentlich egal. 