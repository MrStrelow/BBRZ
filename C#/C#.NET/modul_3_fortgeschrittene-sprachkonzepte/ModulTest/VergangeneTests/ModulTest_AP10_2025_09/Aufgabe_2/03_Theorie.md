Schreiben Sie ihre Meinung zu folgenden Aussagen:
* Ein ``Service`` soll von einem ``Reository`` aufgerufen werden.
* **Antwort:** Nein, umgekehrt. Ein ``Repository`` wird von einem ``Service`` aufgerufen. ``Services`` sind der Zentrale Verwaltungspunkt für die ``Business-Logik``. Diese benötigt einen einheitlichen Zugriff auf die Datenbank durch ``Repositories``. Nicht die *Datenbank*, welche auf die Logik einer ``Entity`` *User* in der Form eines ``Services`` zugreift und lösen will.

* Ein ``DTO`` wird von ``Entities`` verwendet um mit einer externen Schnittstelle (anderes Programm welches mit dem service unter http kommuniziert) zu kommunizieren.
* **Antwort:** Nein, da es von ``Servies`` und manchmal auch von ``Repositories`` verwendet wird.

* Wir verwenden das ``Keyword`` ``await``, um auf das Ergebnis einer ``asynchronen`` ``Methode`` zu Warten.
* **Antwort:** Ja. Wir bekommen ein ``Promise``, dass sich das Programm meldet, sobald die Berechnung der ``asynchronen`` ``Methode`` fertig ist. Währenddessen kann der Computer andere Rechenaufgaben absolvieren. **Wichtig!** Das Programm wartet jedoch und rechnet nicht ``gleichzeitg`` an anderen Problemen weiter.

* Wenn zwei ``Methoden`` welche mit ``async`` gekennzeichnet sind, hintereinander mit ``await`` aufgerufen werden, werden diese ``gleichzeit`` ausgeführt. 
* **Antwort:** Nein. da wir auf das Ergebnis warten und unser Programm nicht ``gleichzeitg`` was anderes berechnet. Wir müssen hier ``Task.WhenAll`` oder die Methode ohne ``await`` aufrufen und die Rückgabe eines ``Tasks`` behandeln, wenn wir ``gleichzeitg`` aufrufe umsetzen wollen. Zudem ist es wichtig ``Locks`` auf kritische Operationen wie *Schreibzugriffe* zu setzten. Diese stellen sicher, dass wir keine ```Race Conditions`` auftreten.
