﻿### Theorie [05 / 30 Teilpunkte]
* Was ist der Unterschied zwischen dem ``Rückgabeparameter`` und dem ``Eingangsparameter``?
  * ``Rückgabeparameter``: Funktion gibt diesen dem Aufrufer der Funktion. Quasi ein Ergebnis der Funktion.
  * ``Eingangsparameter``: Informationen, welche die Funktion vom Aufrufer benötigt um die Berechnung durchführen zu können. 
* Braucht jede ``Funktion`` (Methode) ein ``return`` ``Keyword``?
  * Nein, wenn der  ``Rückgabeparameter`` als *void* gekennzeichnet ist, brauchen wir kein ``return`` ``Keyword``.
* Wenn wir ``Funktionen`` schachteln ``int result = a(b(c()));`` ist es kein Problem wenn eine der ``Funktionen`` den ``Rückgabetyp`` ``void`` hat. Stimmt diese Aussage? Begründe wieso oder wieso nicht.
  * Es ist ein Problem, denn ``a()`` braucht ein Ergebnis von ``b()``, denn ``a(b())``. Wenn ``b()`` kein Ergebnis liefert, haben wir ein Problem
  * **Unnötige Anmerkung:** ``Funktionen`` welche keinen ``Rückgabetyp`` haben, werden auch ``Prozeduren`` genannt.
* Warum sollen wir uns mit ``Funktionen`` quälen? Was ist deren Vorteil wenn wir diese Verwenden?
  * Wir organisieren den Code dadurch besser in, best case, wiederverwendbare Module. Quasi "Legoblöcke" mit welche wir leicher arbeiten können als mit dem Coder der sich in denen befindet.
