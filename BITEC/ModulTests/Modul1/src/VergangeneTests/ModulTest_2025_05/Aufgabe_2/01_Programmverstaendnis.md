Gegeben ist ein ``RegEx``.
* Suche und beschreibe die ``Operatoren`` welche hier verwendet wurden.
  * ``^``: das Muster, muss mit dem folgenden ``Ausdruck`` beginnen. 
  * ``|``: der links stehende ``Ausdruck`` ODER der rechts davon stehende ``Ausdruck`` wird akzeptiert.
  * ``()``: Die ``Gruppierung`` fasst ``Ausdrücke`` zusammen, welche später als ``back-references`` oder mit ``Quantifizierer`` angewandt werden können.
* Beschreibe ca. was dieser darstellen soll.
  * Es können alle Zahlen von ``0-100`` als Wort geschrieben werden. Manche haben einen *Bindestrich* als Trennung wie z.B. ``sieben-und-fünfzig``.

```rx
^(ein-hundert|null|eins|zehn|elf|zwölf|ein|zwei|drei|vier|fünf|sechs|sieben|acht|neun)|((drei|vier|fünf|sechs|sieben|acht|neun)-zehn)|(zwanzig|dreißig|vierzig|fünfzig|sechzig|siebzig|achtzig|neunzig)|((ein|zwei|drei|vier|fünf|sechs|sieben|acht|neun)-und-(zwanzig|dreißig|vierzig|fünfzig|sechzig|siebzig|achtzig|neunzig))$
```