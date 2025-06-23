* a) Was ist der Unterschied zwischen einem ``If-Ausdruck`` und einer ``If-Anweisung``?
  * ``If-Ausdruck``: Ein If mit einem else was einen ``Wert`` erzeugt. In ``JAVA`` wird das mit dem ``?: Operator`` umgesetzt. 
  * ``If-Anweisung``: Ein If mit einem else was **keinen** ``Wert`` erzeugt. Es mit dem ``Keyword`` ``if()`` und ``else`` geschrieben, was eine ``If-Verzweigung`` ist. Es kann auch nur ein ``if()`` als ``Bedingte Anweisung`` sein.
* b) Denke an eine ``If-Verzweigung``. Was ist die ``logische Formel`` des ``else`` Zweigs, wenn die ``logische Formel`` für den ``if`` Zweig ``!(alter >= 25)`` ist?
  * ``!!(alter >= 25)`` was einfacher ``alter >= 25`` ist. ``alter > 24`` ist auch möglich. Wir sehen, es gibt viele verschiedene Formulierungen.
* c) Kann ein ``If-Ausdruck`` das gleiche Verhalten wie eine ``If-Anweisung`` haben? Erstelle ein Beispiel und unterstütze deine Antwort damit.
  * Ja. Beides macht das gleiche - siehe Beispiel.
```java
String antwort;
if (alter > 25) {
    antwort =  "Ok. Passt";
} else {
    antwort =  "Nein.";
}
```
vs.
```java
String antwort = alter > 25 ? "Ok. Passt" : "Nein.";
```