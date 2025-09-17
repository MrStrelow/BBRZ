Gehe auf folgende Fragen zu dem im Klassendiagramm angegebenen Inhalten. Es sind hier zwei Klassendiagramme gegeben, eines stellt eine **sauberere** bezogen auf ``S.O.L.I.D`` dar, die andere eine **schlechtere** Lösung.

* Begründe wieso ein ``Hamster`` im **oberen** Klassendiagramm bezogen auf ``The Dependency Inversion Principle``, welches das *O* in ``S.O.L.I.D`` ist, besser abgebildet ist.
    * Der ``Hamster`` und seine ``hat-Beziehungen`` kommunizieren im **oberen** ``Klassendiagramm`` über abstrakte Schnitstellen (``Interfaces`` oder ``abstract Classes``).  Er redet zum Beispiel ein abstrakter ``Hamster`` mit seiner ``IMovementStrategy``, ``NutritionBehaviour`` und besitzt ``IVisuals``. All das sind abstrakte Schnittstellen (``Interfaces`` oder ``abstract Classes``). Im unteren **unteren** ``Klassendiagramm`` ingegen sind alles konkrete Klassen.

* Begründe wieso ein ``Plane`` im **oberen** Klassendiagramm bezogen auf ``The Dependency Inversion Principle``, welches das *O* in ``S.O.L.I.D`` ist, besser abgebildet ist.
    * Gleiches wie beim ``Hamster``, nur ist es hier die Darstellung der ``Plane`` mit ``IVisual`` und die Verwaltung von der ``List<Hamster>`` begrenzt. 
    
    **Anmerkung:** Für uns reicht zur Zeit eine ``Liste`` von einer ``abstrakten Klasse``. Wir könnten jedoch aus der Liste eine z.B. ``ICollection`` machen. Jedoch ist das nicht der Fokus in dem Beispiel. Merke auch, **abstrahiere** nur wenn wir einen Grund dafür sehen! ``ICollection`` ist jedoch billig und schnell implementiert, es gibt also wenig Gründe gegen ``ICollection``.

**Hinweis!** 
* Falls das Bild zu klein ist können Sie mit Rechtsklick dieses in einem Neuen Fenster öffnen.
* Falls die Linien schwer zu erkennen sind und sie keinen darkmode verwenden, probiere jene für den brightmode ohne transparenz [hier](LargeClassDiagram-bright-transparent.png) und [hier](SmallClassDiagram-bright-transparent.png), sowie ohne transparenz jedoch für den darkmode [hier](LargeClassDiagram.png) und [hier](SmallClassDiagram.png). 

---

![alt](../LargeClassDiagram-transparent.png)

---

![alt](../SmallClassDiagram-transparent.png)

---