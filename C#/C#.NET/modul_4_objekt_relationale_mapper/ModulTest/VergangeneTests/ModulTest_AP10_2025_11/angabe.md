# Modultest 1

Sie haben `180 Minuten` Zeit die Aufgaben zu lösen
* Sie können maximal 100 Punkte erreichen
* Es sind zur Prüfung zugelassen:
    * Taschenrechner (wenn erwünscht)
    * Transparente Wasserflasche
    * Papier, Geodreieck, Stifte, usw.
    * Am Computer sind alle Unterlagen sowie die Nutzung des Internets erlaubt.

Die Nutzung des Internets umfasst nicht
* Chatbots
* Veröffentlichung der Lösungen
* sonstige Kommunikation mit anderen Usern

Die Nutzung von allen anderen Dingen, muss vorher mit mir abgesprochen werden
(z.B. Nutzung von Ohropax), ansonsten wird dies als schummeln gewertet. 
Die Folge des Schummeln ist eine Bewertung mit 0 Punkten.

* Die Abgabe des Programmcodes erfolgt über Teams (ein zip-File des Projektes mir bis spätestens 10:15 schicken)
* Viel Erfolg! :)

Notenschlüssel:
[0-50): N5; [50-62.5%): G4; [62.5-75%): B3; [75-87.5%): G2; [87.5-100%]: S1., (Schulnotensystem)

---

## Data Definition Language (DDL) mit EF-Core Model First umsetzen [40 / 100 Punkte]

include uml diagramm of models

### Programmverständnis [15 / 50 Teilpunkte]

```
hist ist code finde die fehler im model.
eine beziehung ist nicht da. 
bei einem wird nicht spezifiziert dass es ein key ist.
```

1) Finde die Fehler in diesem Code und markiere diese.
2) Erkläre wieso diese Fehler zu einer nicht gültigen bzw. konzeptionell falschen `Guard Clause` führen. 

---

### Programmiern [25 / 50 Teilpunkte]
implementiere das uml driagramm und erstelle dazu den model folder.
1) models erstellen
2) datenbank create queries erstellen
3) befülle datenbank mit daten
4) update daten in der Datenbank
4) ändere das model - spiele es in die datenbank
5) sind die daten noch drinnen?

---

### Theorie [10 / 50 Teilpunkte]
1) shadow properties vs real properties
2) was erleichtert uns efcore vergleiche es mit ado.net.
4) wir haben 5 migations. der letzte add migration produziert nichts nützliches -> wie entfernen wir die letze migration?
5) update database mit einer vergangenen migration.
6) was macht die up und down methode in den den generierten files?

---

## Async Data Manipulation Language (DML) mit EF Core umsetzen [60 Punkte]
### Programmverständnis [20 / 60 Teilpunkte]
1) async vs sync methoden
2) save to db fehlt
2) abfragen welche include und then-includen haben. aber falsch.
3) 

```csharp
es fehlt der parameter.
es wird kein viewmodel der view übergeben sondern ein array.
im cshtml wird kein @model angewandt sondern direkt aus der datenbank gelesen.
``` 

---

### Programmieren [30 / 60 Teilpunkte]
2) ein async select * form all
3) ein where mit einem select und dann mit async send an die db schicken
3) joins mit include
4) joins mit include und then include

#### Erwarteter Output:
resultate der datenbank

---

### Theorie [10 / 60 Teilpunkte]
1) müssen wir sql queries in efcore schreiben? was schreiben wir wirklich?
2) include vs theninclude
3) was muss bei async und dbset bearchtet werden? es muss immer ein task zurückgegeben werden.
```