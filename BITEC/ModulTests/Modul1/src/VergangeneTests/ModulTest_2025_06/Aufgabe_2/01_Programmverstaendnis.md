 Kopiere folgende Angabe nach [Aufgabe_2/01_Programmverständnis.md](../Aufgabe_2/01_Programmverstaendnis.md) und beantworte dort die folgenden Fragen.
  
Gegeben ist ein ``RegEx``. 
1) Suche und beschreibe die ``Operatoren`` und ``Multiziplizäten``welche hier verwendet wurden.
  * ``^``: das Muster, muss mit dem folgenden ``Ausdruck`` beginnen. 
  * ``|``: der links stehende ``Ausdruck`` ODER der rechts davon stehende ``Ausdruck`` wird akzeptiert.
  * ``()``: Die ``Gruppierung`` fasst ``Ausdrücke`` zusammen, welche später als ``back-references`` oder mit ``Quantifizierer`` angewandt werden können.
  * ``+``: alles was in der angegebenen ``Gruppierung`` oder ``Zeichenklasse`` ist, darf *1-n* mal wiederholt werden.
2) Beschreibe ca. was dieser ``RegEx`` darstellen soll.
  * Es können alle Zahlen von ``0-100``, außer ``20, 30, 40, 50, 60, 70, 80, 90`` als Wort geschrieben werden. Manche haben einen *Bindestrich* als Trennung wie z.B. ``sieben-und-fünfzig``.
  * Es darf zusätzlich z.B. ``vier-zehnfünf-zehndreiein-hundert`` geschrieben werden. Also ausgeschriebene Zahlen öfter hintereinander geschrieben werden.


```rx
^(ein-hundert|(20|30|40|50|60|70|80|90)|((ein|zwei|drei|vier|fünf|acht|neun|sechs|sieben)-und-(zwanzig|dreißig|vierzig|fünfzig|sechzig|siebzig|achtzig|neunzig))|((drei|vier|fünf|acht|neun|sech|sieb)-zehn)|(zwei|drei|vier|fünf|acht|neun|sechs|sieben)|(null|eins|zehn|elf|zwölf))+$
```