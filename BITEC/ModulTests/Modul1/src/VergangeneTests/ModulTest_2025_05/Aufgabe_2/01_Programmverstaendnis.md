﻿Gegeben ist ein ``RegEx``. 
1) Suche und beschreibe die ``Operatoren`` welche hier verwendet wurden.
  * ``^``: das Muster, muss mit dem folgenden ``Ausdruck`` beginnen. 
  * ``|``: der links stehende ``Ausdruck`` ODER der rechts davon stehende ``Ausdruck`` wird akzeptiert.
  * ``()``: Die ``Gruppierung`` fasst ``Ausdrücke`` zusammen, welche später als ``back-references`` oder mit ``Quantifizierer`` angewandt werden können.
2) Beschreibe ca. was dieser ``RegEx`` darstellen soll.
  * Es können alle Zahlen von ``0-100`` als Wort geschrieben werden. Manche haben einen *Bindestrich* als Trennung wie z.B. ``sieben-und-fünfzig``.

```rx
^ein-hundert|(zwanzig|dreißig|vierzig|fünfzig|sechzig|siebzig|achtzig|neunzig)|((ein|zwei|drei|vier|fünf|acht|neun|sechs|sieben)-und-(zwanzig|dreißig|vierzig|fünfzig|sechzig|siebzig|achtzig|neunzig))|((drei|vier|fünf|acht|neun|sech|sieb)-zehn)|(zwei|drei|vier|fünf|acht|neun|sechs|sieben)|(null|eins|zehn|elf|zwölf)$
```

**Hinweis:** Verwende z.B. einen [Regex-Online-Checker](https://regex101.com/) um die erlaubten Texte zu überprüfen.
