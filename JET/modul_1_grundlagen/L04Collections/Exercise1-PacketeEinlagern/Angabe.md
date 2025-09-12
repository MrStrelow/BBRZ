## Pakete einlagern
Erstellen Sie einen String[] mit dem Inhalt ``["📦", "📦", "📦", "📦", "📦"]``. Es sollen nun nach Benutzereingaben in leere Pakete Produkte eingelagert und entnommen werden können. Die Identifikation passiert über eine **Paketnummer**. Das String-Array hat 5 leere Plätze mit den Indizes ``0, 1, 2, 3, 4``. (📦 bedeutet, dass der Platz leer ist.)
* Legen Sie den ``string storage`` mit ``["📦", "📦", "📦", "📦", "📦"]`` an.
* Fragen Sie den Benutzer, welche Aktion er ausführen möchte. Geben Sie hierzu folgende Optionen:
    * einlagern, auslagern, beenden

* Nach der Wahl der Option, soll die **Paketnummer** angegeben werden. Es soll dieser **Paketnummer** eines einer der 10 verschiedene **Produkte** (``{0:"🌂", 1:"🧯", 2:"🧺", 3:"🧹", 4:"🪒", 5:"🧼", 6:"🪞", 7:"🚽", 8:"🪠", 9:"💍"}``) zugewisen werden. Die Zahlen in der Auflistung sind die **Produktnummern**. Diese ändern sich nicht.
* Überschreiben den nächsten freien Platz mit dem Produkte anhand folgender Logik:
    * einlagern: das erste 📦 wird durch die **Paketnummer** identifiziert und der user wird gefragt welches Produkt er will. Dazu gibt dieser die **Produktnummer** an. Gibt es keinen freien Platz mehr, so wird eine Meldung ausgegeben.
    * auslagern: das Produkt welches über die Produktnummer identifiziert wird, wird durch 📦 ersetzt.
    * beenden: beendet das Programm.

* Geben Sie in jedem Schleifendurchlauf die Variable storage aus.

*Hinweis: Lege folgenden String an ``string[] produkte = ["🌂", "🧯", "🧺", "🧹", "🪒", "🧼", "🪞", "🚽", "🪠", "💍"]`` und lass die Benutzer die Position des Strings-Arrays eingeben. Nehmen wir an die Postion ist 4, wir schreiben ``int wahlDesUsersAlsUnicode = produkte[4]`` um den String davon zu bekommen.

Beispiel:
```
Willkommen: Wie groß ist das Lager [ganze Zahl]? 5 
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 2425 2 
🧯📦📦📦📦 
 
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 6472115482 6 
🧯🧼📦📦📦 
 
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 1 6 
🧯🧼💍📦📦 
 
Wählen Sie eine Aktion (einlagern, auslagern, beenden): auslagern 
Geben Sie die Paketnummer ein: 2425
📦🧼💍📦📦 
 
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 1 8 
Paketnummer bereits vergeben!
📦🧼💍📦📦

Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 13884 8 
🪠🧼💍📦📦 

Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 1388451 8 
🪠🧼💍🪠📦 
[
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an Paketnummer Produktnummer]: 16 8 
🪠🧼💍🪠🪠

Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 999 8 
Lager ist Voll. Wir melden uns wenn dieses frei ist.
🪠🧼💍🪠🪠
```