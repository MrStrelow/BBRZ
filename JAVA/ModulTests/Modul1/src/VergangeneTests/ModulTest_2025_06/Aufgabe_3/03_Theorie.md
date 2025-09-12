### Theorie [05 / 30 Teilpunkte]
* Braucht jede ``Funktion`` (Methode) ein ``return`` ``Keyword``?
  * Nein, wenn der  ``Rückgabeparameter`` als *void* gekennzeichnet ist, brauchen wir kein ``return`` ``Keyword``.
* Wenn wir ``Funktionen`` schachteln ``int result = a(b(c()));`` ist es kein Problem wenn eine der ``Funktionen`` den ``Rückgabetyp`` ``void`` hat. Stimmt diese Aussage? Begründe wieso oder wieso nicht.
  * Es ist ein Problem, denn ``a()`` braucht ein Ergebnis von ``b()``, denn ``a(b())``. Wenn ``b()`` kein Ergebnis liefert, haben wir ein Problem
  * **Unnötige Anmerkung:** ``Funktionen`` welche keinen ``Rückgabetyp`` haben, werden auch ``Prozeduren`` genannt.
