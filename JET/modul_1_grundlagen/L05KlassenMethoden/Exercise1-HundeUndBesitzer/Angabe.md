# Hunde und dessen Besitzer:innen

## Klassen und Methoden definieren
Gegeben ist ein UML Klassendiagramm. 

![Klassendiagramm](https://raw.githubusercontent.com/MrStrelow/BBRZ/refs/heads/main/JET/modul_1_grundlagen/L04KlassenMethoden/Exercise1/UML/UML-Klassendiagramm-Hunde_dark.png). 

Versuche die ``Hat`` sowie ``Ist`` Beziehungen zu verstehen und...
* **``definiere``** die ``Klassen`` und dessen ``Mitglieder`` (``Felder`` und ``Methoden``) in C#.
* Vergiss nicht auf im Klassendiagramm nicht angeführten ``Methoden``. **``Implementiere``** die ``Konstruktoren`` sowie ``Get und Set`` Methoden. (Wir werden ``Get und Set`` bald mit ``Eigenschaften`` von C# ersetzen).

## Klassen und Methoden implementieren
Um nun das genauere Verhalten der ``Beziehungen`` zwischen den ``Klassen`` zu ``implementieren``, brauchen wir mehr Informationen als im ``Klassendiagramm`` angegeben ist.
Beachte folgendes:
* Die ``Beziehung`` Spielfreund eines ``Objekts`` der ``Klasse`` Hundes ist ``gegenseitig`` zu implementieren (``reziprok``). Bedeutet wenn ein ``Objekt`` *burli* der ``Klassse`` Hund mit einem anderen ``Objekt`` *frida* der ``Klasse`` Hund in der ``Beziehung`` Spielfreund ist, dann ist auch *frida* in der ``Beziehung`` Spielfreund mit *burli*. Beachte, dass es zu **keinem** Zeitpunk möglich sein soll, dass diese ``gegenseitige`` Beziehung verletzt wird.
* Ein ``Objekt`` der ``Klasse`` Hundebesitzer kann das ein ``Objekt`` der ``Klasse`` Hund nur ein mal besitzen. Verwende dazu eine geeignete Datenstruktur (Welche Datenstruktur kann ein **gleiches** ``Objekt`` nur einmal beinhalhten?) oder verwende eine ``Liste`` und stelle sicher dass ein solches Verhalten **immer** gegeben ist.
* Ein ``Objekt`` *francesca* der ``Klasse`` Hundebesitzer kann nur ein ``Objekt`` *burli* der ``Klasse`` Hund besitzen, wenn *burli* in keiner Beziehung zu einem anderen ``Objekt`` *hans* der ``Klasse`` HundeBesitzer ist.
* Ein ``Objekt`` der ``Klasse`` Hundebesitzer muss durch die *1-n* Beziehung "Ein Hundebesitzer hat einen oder mehrere Hunde" zumindest einen Hund besitzten. Bedeutet dass bei der Erstellung eines ``Objektes`` der ``Klasse`` Hundebesitzerdes ein mindestens ein ``Objekt`` der ``Klasse`` Hund dem ``Konstruktor`` übergen werden muss. Zusätzlich muss, wenn ein ``Objekt`` *hans* der ``Klasse`` Hundebesitzer in der besitzt ``Beziehung`` mit einem ``Objekt`` *burli* der ``Klasse`` Hund steht, auch *burli* in Beziehung mit *hans* stehen.
* Ein ``Objekt`` der ``Klasse`` Mensch

## Sonstige implementierungen
* Erstelle einen *Copy-*``Konstruktor`` für die ``Klassen`` Hund. Dies ist ein Konstruktor welcher ein ``Objekt`` der ``Klasse`` Hund entgegennimmt und einen neues ``Objekt`` der ``Klasse`` Hund basierend auf den ``Feldern`` erstellt (ignoriere hier **in unserem Beispiel** die ``Hat-Beziehungen``).

## Objekte aus Klassen erstellen
* erstelle einen hund
* erstelle einen hundebesitzer und verwende named und positional arguments

* prüfe ob der hund welche der hundebesitzter im konstruktor bekommen hat, den hundebesitzer als besitzer eingetragen hat
* erstelle einen weiteren hund und weise diesem den anderen hund als spielfreund zu
* prüfe ob beide ein spielfreund sind

* kopiere einen hund mit dem copy construktor

* erstelle einen menschen.
* erstelle eine mutual love beziehung und zwischen mensch und hundebesitzer. frage ab ob es die methode erkennt.
* erstelle ein love triangle der Größe 3 und 9 und frage ab ob es die methode erkennt

* erstelle einen schäferhund welcher keinen besitzer hat.
* lass diesen alle hunde hüten welche bereits existieren.

