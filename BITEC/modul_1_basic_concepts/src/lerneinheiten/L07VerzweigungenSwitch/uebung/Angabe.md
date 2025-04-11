# Mehrfachverzweigungen (Switch und If)

## Monate

Einlesen von Monatsnummer (1=Jänner, 2=Februar, ...) und in Variable speichern

Fallunterscheidung und Ausgabe des gewählten Monats mittels switch.

**Beispiel:**
```
Monatsnummer eingeben:  2
Das 2.  Monat hat den Namen Februar
```

## Anzahl der Tage/Monat ermitteln

Die Monate 1, 3, 5, 7, 8, 10, 12 haben 31 Tage

Die Monate 4, 6, 9, 11 haben 30 Tage

Das Monat Februar (2) hat 28 Tage (Schaltjahre ignorieren)

1. Schreiben Sie ein Programm, welches die Monatsnummer einliest und die Anzahl der Tage ausgibt.
2. Kombinieren Sie diese Übung mit der Ermittlung des Monatsnamen um auch diesen Auszugeben.

**Beispiel:**
```
Monatsnummer eingeben:  4
Das 4.  Monat ist April und hat 30 Tage.
```

## Preisberechnung

Die Eintrittspreise für ein Schwimmbad sind gestaffelt nach dem Wochentag:
- Am Tag 1: 4,5 Euro.
- Am Tag 2: 6 Euro.
- Am Tag 3: 7 Euro
- Tag 4 bis 7 kosten die Tageskarten 8 Euro.

Einlesen von Wochentag. Ausgabe von Tagname und Preis

**Beispiel:**
```
Wochentag eingeben:  2
Am Dienstag kostet die Tageskarte 6 Euro.
```

## Klassifizierung von Schrauben

Ein Hersteller klassifiziert Schrauben nach folgendem Schema:

- Schrauben mit einem Durchmesser bis zu 3 mm und einer Länge bis zu 20 mm sind vom Typ1.
- Schrauben mit einem Durchmesser von 4 bis 6 mm und einer Länge von 21 bis 30 mm sind vom Typ2
- Schrauben mit einem Durchmesser von 7 bis 20 mm und einer Länge von 31 bis 50 mm sind vom Typ3

Schreiben Sie ein Programm die den richtigen Schraubentyp ermittelt, wenn Durchmesser und Länge als ganze Zahlen eingegeben werden. Sollte eine Schraube keiner der oben beschriebenen Kategorien angehören, soll die Meldung „Unbekannter Schraubentyp“  ausgegeben werden. Testen Sie Ihr Programm für verschiedene Eingaben.

## Zielpreisberechnung

Sie sind Programmierer in einem Online-Shop und möchten den Versandpreis basierend auf dem Land des Kunden berechnen. Bitten Sie den Benutzer, das Zielland für den Versand einzugeben (z.B., "DE" für Deutschland, "US" für die USA, "FR" für Frankreich usw.). Verwenden Sie eine switch-Anweisung, um den Versandpreis zu berechnen, basierend auf dem Zielland. Geben Sie dann den Versandpreis aus. Wenn das Zielland nicht erkannt wird, geben Sie eine Fehlermeldung aus.

**Preise:**
```
Land Preis
AT 0,00€
DE 4,00€
FR 8,00€
IT 8,00€
SZ 8,00€
US 10,00€
CZ 10,00€
Rest 17,00€
```

## Flugpreise

Sie entwickeln eine Anwendung für eine Fluggesellschaft, die den Ticketpreis basierend auf verschiedenen Kriterien berechnet. Bitten Sie den Benutzer um folgende Informationen:

- Die Entfernung in Kilometern für die Flugstrecke.
- Das Reisedatum (Monat) als Ganzzahlwert (z.B., 1 für Januar, 2 für Februar usw.).
- Die Buchungsklasse (Erste Klasse, Premium Economy oder Economy). Verwenden Sie eine Kombination von switch und if-Anweisungen, um den Ticketpreis basierend auf diesen Informationen zu berechnen. Zum Beispiel können Sie verschiedene Preise für verschiedene Entfernungen und Monate festlegen, und je nach Buchungsklasse den Preis entsprechend anpassen.

**Preise:**
```
Strecke je km 0,02€
Economy Aufschlag 0,00€
Premium Economy Aufschlag 200,00€
Erste Klasse Aufschlag 400,00€
Aufschlag Juli-September 20,00€
Aufschlag Dezember 15,00€
```

## Tage bis Wochenende

Schreiben Sie ein Programm, das den Namen eines Wochentags als Eingabe erhält und die Anzahl der verbleibenden Tage bis zum Wochenende ausgibt. Verwenden Sie Switch-Case, um den entsprechenden Wochentag zu bestimmen.

**Beispiel:**
```
Montag: 5 Tage
Dienstag: 4 Tage
Mittwoch: 3 Tage
Donnerstag: 2 Tage
Freitag: 1 Tage
Samstag: Es ist Wochenende
Sonntag: Es ist Wochenende
```

## Altersgruppe

Schreibe ein Programm, das den Nutzer nach seinem Alter fragt und basierend darauf eine entsprechende Meldung ausgibt, z.B. ob der Nutzer ein Kind(0-13), Jugendlicher(14-17), Erwachsener(18-65) oder Pensionist(ab 65) ist. Entscheiden Sie selbst, ob if oder switch besser passt.

**Beispiel:**
```
Wie alt bist du? 25
Du bist ein Erwachsener.
```

## Rabattrechner

Schreiben Sie ein Programm, das den Nutzer nach dem Kaufpreis eines Produkts fragt und basierend darauf einen Rabatt berechnet. Wenn der Kaufpreis über 100 Euro beträgt, soll ein Rabatt von 10% gewährt werden, ansonsten kein Rabatt.

## Zufallszahl

Erinnerung: Zahl zwischen 1 und 10 generieren:
```java
import java.util.Random; 
// .... 
Random random = new Random(); 
int randomNumber = random.nextInt(0, 11); 
```

## Zahl erraten

Schreibe ein Programm, das eine zufällige Zahl zwischen 1 und 100 generiert und den Benutzer auffordert, diese Zahl zu erraten. Das Programm soll dann eine Nachricht ausgeben, ob die geratene Zahl zu hoch, zu niedrig oder korrekt ist. Der Benutzer hat insgesamt drei Versuche, um die Zahl zu erraten. Verwende dazu die java.util.Random-Klasse.

**Beispiel:**
```
Ich denke an eine Zahl zwischen 1 und 100.  Du hast 3 Versuche,  um sie zu erraten.
Was ist deine erste Vermutung? 50
Zu niedrig.  Du hast noch 2 Versuche.
Was ist deine nächste Vermutung? 75
Zu hoch.  Du hast noch 1 Versuch.
Was ist deine letzte Vermutung? 62
Richtig! Du hast gewonnen.
```

## Switch zu ...

Wandle folgenden Code in eine Mehrfachverzweigung mittels...
```java
String toPrint = switch(genre.toLowerCase()) {
    case "action"            -> "Schauen wir einen Actionfilm!";
    case "komödie", "lustig" -> "Lass uns eine Komödie sehen!";
    case "horror"            -> "Du magst es grueselig";
    case "thriller"          -> "Spannend!";
    case "romantik", "liebesfilm" -> "Wie wäre es mit einer Romanze?";
    default                  -> "Ich kenne dieses Genre nicht.";
}

System.out.println(toPrint)
```

* ... IF-Anweisung um
* ... IF-Ausdruck um
* ... klassische Switch-Anweisung mit case: und break; um
* ... klassische Switch-Anweisung mit case: und break; ohne Beistrich wie case "komödie", "lustig":



