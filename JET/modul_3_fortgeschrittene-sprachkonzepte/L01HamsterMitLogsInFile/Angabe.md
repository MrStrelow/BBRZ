Tausche die image representation mit einer html representation aus.

-> es muss überall wo image representation war, diese ersetzt werden:
* IVisuals (verwende dann die links angezeigte Typhierarchie)
* Subtypes von IVisals (wir sehen wir können gar nichts vergessen wenn wir IVisuals anpassen! wir werden gezwungen alles auszutauschen)
* Html Renderer (wir wissen jedoch nocht nicht was wir diesem zurückgeben. wir denken uns den korrekten image tag mit path und height und width sollte reichen)
* * Implementiere HtmlRepresentation -> (ImageRepresentation wird nicht mehr benötigt, muss nicht gelöscht werden, kann aber).
	* hier soll ...
    
```csharp 
Representation =    $"<img " +
                        $"src='{Path}' " + //Path muss ausgehend von dem html file sein.
                        $"width='{SizeToDisplay}' " +
                        $"height='{SizeToDisplay}' " +
                    $"/> ";
```

... stehen.
    * in der ToString() Methode soll dann ``return (string) Representation`` zurückgegeben werden.


Hinweis für die Praxis:
Wenn wir Code finden welcher so aussieht
```csharp
$"<img " +
    $"src='{Plane.Visual.ImageRepresentation}' " +
    $"width='{Plane.Visual.ImageRepresentation.SizeToDisplay}' " +
    $"height='{Plane.Visual.ImageRepresentation.SizeToDisplay}'" +
$"/> "
```
sollten wir uns überlegen ob wir nicht stattdessen ein objekt haben können welches all diese info hat.
Wir kapseln also besser und können es kompakt aufrufen.
```csharp
$"{Plane.Visual.ImageRepresentation}"
```

Zudem ist es ein Hinweis, wenn die Kapselung fehlt, dass wir den Code nicht korrekt spezifiziert haben.
Wie hier, ist ``ImageRepresentation`` von uns falsch ausgedacht worden. Wir haben dort ein image selbst gespeicher in ``Representation``.
Das könnte für z.B. eine grafik darstellung verwendet werden, welche eine Bild datei braucht. z.B. WinForms (alt)
Wir brauchen aber den pfad und html code. Was ein string ist. Wir können und sollten auch nicht die unicoderepresentation verwenden,
den diese hat einen anderen hintergedanken. Da soll in einem string selbst die darstellung stehen.
Hier ist der html code in der Representation welcher auch abmaße hat. (auch wenn die abmaße fehlen würde hier eine eigene klasse sinn machen, für das konzept. in der zukunft kann sich was ändern. denn konzeptuell sind unicdoe- und htmlrepresentaion anders. Ersetzbarkeitsprinzip!)
