Gehe auf folgende Fragen zu dem im Klassendiagramm angegebenen Inhalten.
* Ist die ``Beziehung`` zwischen ``Kunde`` und ``Kunde`` eine Hat-Beziehung oder Ist- Beziehung? Ist diese Bidirektional oder Unidirektional?
> Hat
> Unidirektional

* Was bedeutet das neben der ``Methode`` *informieren* eingezeichnete **-**? Ist es sinnvoll die ``Methode`` sozu modellieren? Wenn ja, warum, wenn nein, was soll geändert werden?
> Es bedeutet dass diese ``privat`` ist. Das macht jedoch wenig Sinn wenn wir diese in der ``Main-Klasse`` aufrufen sollen. Ich änderes auf ``public``.

* Ist die ``Beziehung`` *vertretet* eine Hat- oder Ist-Beziehung? Was bedeutet *1-n*?
> Hat
> Die ``Multiplizität`` /``Kardinalität``. Es zeigt nicht nur *qualitativ* (es *gibt* die Beziehung), sondern stellt diese *quantitativ* (es *gibt* die Beziehung und sie ist *so viel*, z.B. 1 Shop hat *viele* Kunden) dar.

* Die Hat-Beziehung zwischen *Shop* und *Employee* zwingt jedes `Objekt` der ``Klasse`` Employee zu allen Zeitpunkten mindestens einem *Shop* zugewiesen zu sein. Andererseits hat ein *Shop* mindestens einen *Employee*. Tritt bei der Erstellung der ``Objekte`` *Shop* und *Employee* dadurch ein Problem auf?
> ja, denn wir müssen dadurch beide ``Objekte`` *gleichzeitig* erstellen. Wir erstellen ``Objekte`` mit ``Konstruktoren``. Der ``Konstruktor`` des *Shops* verlangt damit sofort einen *Employee* als ``Parameter``. Jedoch verlangt der ``Konstruktor`` des *Employees* sofort einen *Shop*. Das kann nicht funktionieren. Wir müssen daher einen *1ser* in der ``Hat-Beziehung`` auf einen *0* ändern. Das erlaubt uns zuerst einen *Employee* zu erstellen (ohne *Shop*) und danach den *Shop* zu erstellen (mit den zuvor erstellten *Employee*).

![alt](https://raw.githubusercontent.com/MrStrelow/BBRZ/refs/heads/main/JET/modul_1_c%23_basics/ModulTest/VergangeneTests/ModulTest_AP10_2025_03/exam_dark.png)