1) Was ist der Unterschied zwischen einer ``If-Verzweigung`` und einer ``Bedingte Anweisung``?
  * ``If-Verzweigung``: If mit einem else. Wir haben 2 möglichkeiten welche sich ausschließen. Wir führen den code im if aus, wenn die Bedingung erfüllt ist. Wir führen den code im else aus, wenn die Bedingung nicht erfüllt ist.
  * ``Bedingte Anweisung``: If ohne else. Der Code wird im if ausgeführt, wenn die Bedingung erfüllt ist, ansonsten machen wir nach dem if mit dem Programm weiter.

2) Denke an eine ``If-Verzweigung``. Was ist die ``logische Formel`` des ``else`` Zweigs, wenn die ``logische Formel`` für den ``if`` Zweig ``alter > 25`` ist?
  * ``!(alter > 25)`` was einfacher ``alter <= 25`` ist. ``alter < 26`` ist auch möglich. Wir sehen, es gibt viele verschiedene Formulierungen.

3) Kann eine ``If-Verzweigung`` das gleiche Verhalten wie eine ``Bedingte Anweisung`` haben? Vergleiche dazu folgenden Code.
  * Ja. In beiden Fällen wird einmal der Code im if ausgegeben wenn die Bedingung ``alter > 25`` erfüllt wird. Wenn diese nicht erfüllt ist führen wir das Gegenteil aus. Bei der Verzweigung passiert das automatisch, jedoch für die 2. ``Bedingte Anweisung`` müssen wir eine Bedingung angeben, eine logische Formel. Diese muss das Gegenteil der ersten Bedingung in der ``Bedingte Anweisung`` sein. Was hier mit ``alter <= 25`` der Fall ist.
```java
if (alter > 25) {
    System.out.println("If-Zweig")
} else { // wir führen else aus wenn alter <= 25, also das Gegenteil von alter > 25 eintritt.
    System.out.println("Else-Zweig")
}
```

vs.

```java
if (alter > 25) {
    System.out.println("Bedingte Anweisung")
} 

if (alter <= 25) {
    System.out.println("Auch eine Bedingte Anweisung")
}
```