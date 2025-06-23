1)  Was ist der Unterschied zwischen einem ``If-Ausdruck`` und einer ``If-Anweisung``?
  * ``If-Ausdruck``: Ein If mit einem else was einen ``Wert`` erzeugt. In ``JAVA`` wird das mit dem ``?: Operator`` umgesetzt. 
  * ``If-Anweisung``: Ein If mit einem else was **keinen** ``Wert`` erzeugt. Es mit dem ``Keyword`` ``if()`` und ``else`` geschrieben, was eine ``If-Verzweigung`` ist. Es kann auch nur ein ``if()`` als ``Bedingte Anweisung`` sein.
2) Denke an eine ``If-Verzweigung``. Was ist die ``logische Formel`` des ``else`` Zweigs, wenn die ``logische Formel`` für den ``if`` Zweig ``!(alter >= 25)`` ist?
  * ``!!(alter >= 25)`` was einfacher ``alter >= 25`` ist. ``alter > 24`` ist auch möglich. Wir sehen, es gibt viele verschiedene Formulierungen.
3) Kann ein ``If-Ausdruck`` das gleiche Verhalten wie eine ``If-Anweisung`` haben? Vergleiche dazu folgenden Code.
Der angegebene Code erzugt den Gleichen Output. Nur einmal mit einer ``If-Anweisung``, welche zusätzlich eine ``Verzweigung`` ist und einmal als ``If-Ausdruck``, welcher ebenfalls zusätzlich eine ``Verzweigung``, umgesetzt.
```java
String antwort;

if (alter > 25) {
    antwort = "passt.";

} else {
    antwort = "passt nicht."
}

System.out.println(antwort);
```

vs.

```java
System.out.println(alter > 25 ? "passt" : "passt nicht");
```