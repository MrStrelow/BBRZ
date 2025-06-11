Gegeben ist ein ``RegEx``.
* Suche und beschreibe die ``Operatoren`` und ``Multiziplizäten`` welche hier verwendet wurden.
  * ``^``: das Muster, muss mit dem folgenden ``Ausdruck`` beginnen. 
  * ``|``: der links stehende ``Ausdruck`` ODER der rechts davon stehende ``Ausdruck`` wird akzeptiert.
  * ``()``: Die ``Gruppierung`` fasst ``Ausdrücke`` zusammen, welche später als ``back-references`` oder mit ``Quantifizierer`` angewandt werden können.
  * ``+``: alles was in der angegebenen ``Gruppierung`` oder ``Zeichenklasse`` ist, darf *1-n* mal wiederholt werden.
* Beschreibe ca. was dieser darstellen soll.
  * Es können alle Zahlen von ``0-100``, außer ``20, 30, 40, 50, 60, 70, 80, 90`` als Wort geschrieben werden. Manche haben einen *Bindestrich* als Trennung wie z.B. ``sieben-und-fünfzig``.
  * Es darf zusätzlich z.B. ``ein-hundertein-hundert`` geschrieben werden. Also die gleiche Zahl öfter.
```rx
^((ein-hundert|null|eins|zehn|elf|zwölf|ein|zwei|drei|vier|fünf|sechs|sieben|acht|neun)|((drei|vier|fünf|sechs|sieben|acht|neun)-zehn)|((ein|zwei|drei|vier|fünf|sechs|sieben|acht|neun)-und-(zwanzig|dreißig|vierzig|fünfzig|sechzig|siebzig|achtzig|neunzig)))+$
```