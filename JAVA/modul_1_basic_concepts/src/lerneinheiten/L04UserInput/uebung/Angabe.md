# Userinteraktion auf dem Terminal

## Abfragen von Strings

Fragen Sie den Benutzer nach 3 Strings ab. Geben Sie anschließend alle drei Strings aus.

**Eingabe:**  
Eingabe von String 1: Hallo  
Eingabe von String 2: am  
Eingabe von String 3: Mittwoch

**Ausgabe:**  
Hallo am Mittwoch

## Abfragen von Integer

Fragen Sie den Benutzer nach 3 Integer ab. Geben Sie anschließend die Summe aller drei Integer aus.

**Eingabe:**  
Eingabe von Integer 1: 5  
Eingabe von Integer 2: 2  
Eingabe von Integer 3: 10

**Ausgabe:**  
5 + 2 + 10 = 17

## Einstieg

Fragen Sie folgende Datentypen von der Konsole ab. Speichern Sie diese Eingaben in die entsprechenden Variablen:

- String
- Integer
- Double
- Boolean

Geben Sie anschließend alle Eingaben aus:

**Beispielausgabe:**  
Eingegebener String: BBRZ  
Eingegebener Integer: 17  
Eingegebener Double: 11.11111  
Eingegebener Boolean: true

## Name abfragen

Fragen Sie den Benutzer in der Konsole nach seinem Vornamen und Nachnamen (zwei Eingaben). Der eingegebene String soll anschließend folgendermaßen ausgegeben werden:

**Beispiel:**  
Eingabe: Max Mustermann  
Ausgabe: Hallo Max Mustermann!

Wenn der Benutzer mehrere Vornamen hat, werden diese alle in der Eingabe Vorname gespeichert.

## Taschenrechner mit Eingaben

Fragen Sie den Benutzer nach zwei Integer-Zahlen a und b. Führen Sie folgende Operationen aus und geben Sie die Ergebnisse auf die Konsole aus:

- a + b = c
- a - b = c
- a / b = c (double)
- a % b = c

## Berechnung des Quadrats einer Zahl

Fordern Sie den Benutzer auf, eine Zahl einzugeben, und geben Sie anschließend das Quadrat dieser Zahl aus.

## Berechnung des Durchschnitts

Fordern Sie den Benutzer auf, drei Zahlen einzugeben, und berechnen Sie den Durchschnitt dieser Zahlen. Geben Sie das Ergebnis aus.

## Entfernung

Deklarieren Sie Variablen für einen Ort1, einen Ort2 und die Entfernung als Text. Lassen Sie den Benutzer diese Werte eingeben. Nach den Benutzereingaben sollen sie wie im Beispiel formatiert ausgegeben werden:

**Beispiel:**  
Ort 1: Wien  
Ort 2: Bratislava  
Entfernung in km: 55

**Ausgabe:**  
Die Entfernung zw. Wien und Bratislava beträgt 55 km.

## Jahre bis 100

Das Alter des Benutzers einlesen. Die Differenz auf 100 Jahre ermitteln und ausgeben:

**Beispiel:**  
Alter: 80  
Du hast noch 20 Jahre bis 100.

## Durchschnitt

Vom Benutzer 2 Zahlen einlesen und den Durchschnitt berechnen. Das Ergebnis entsprechend ausgeben.

**Beispiel:**  
Zahl 1: 4  
Zahl 2: 2  
Der Durchschnitt beträgt 3.

## Mehrwertsteuerrechner

Fragen Sie den Benutzer nach einem Produktnamen und einem Nettobetrag. Errechnen Sie die Mehrwertsteuer (20%) und geben Sie das Ergebnis aus.

**Beispiel:**  
Das Produkt XXXXX kostet XXXXX € netto und XXXXX € brutto.

Formatieren Sie die Beträge mit folgendem Befehl:
```java
String.format("%.2f", value)
```
Hierfür ersetzen Sie `value` mit der entsprechenden Variable.

"%.2f" bedeutet, dass das Ergebnis auf zwei Nachkommastellen gerundet wird.

