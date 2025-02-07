## Aufgabenstellung
### Schreiben Sie ein Java-Programm, das ein Zahlen-Ratespiel simuliert.
Der Benutzer muss eine geheime Zahl zwischen 0 und 100 erraten. Nach jeder Eingabe gibt das Programm Hinweise, ob die Zahl zu hoch oder zu klein ist. Der Benutzer hat 5 Leben. Wenn die Leben aufgebraucht sind, endet das Spiel mit einer Niederlage.
Anforderungen
#### Geheime Zahl:
Das Programm wählt zu Beginn eine zufällige Zahl zwischen 0 und 100 aus.
Verwenden Sie dazu Math.random() oder java.util.Random.
#### Benutzereingabe:
Der Benutzer wird in jeder Runde aufgefordert, eine Zahl einzugeben.
Die Eingabe muss überprüft werden, ob sie der geheimen Zahl entspricht.
#### Feedback:
Wenn die Eingabe zu hoch ist, gibt das Programm die Nachricht "Die Zahl ist zu hoch!" aus.
Wenn die Eingabe zu niedrig ist, gibt das Programm die Nachricht "Die Zahl ist zu klein!" aus.
Bei korrekter Eingabe zeigt das Programm "Herzlichen Glückwunsch, Sie haben die Zahl erraten!" an und beendet das Spiel.
#### Leben:
Der Benutzer hat 5 Leben.
Bei jeder falschen Eingabe verliert er ein Leben.
Wenn die Leben aufgebraucht sind, endet das Spiel mit der Nachricht: "Game Over! Die geheime Zahl war: [Geheime Zahl]".
#### Schleifensteuerung:
Nutzen Sie eine while-Schleife, um die Eingaben des Benutzers zu prüfen, bis die Zahl erraten wurde oder die Leben aufgebraucht sind.

#### Beispielablauf:
Willkommen beim Zahlen-Ratespiel!
Ich habe eine geheime Zahl zwischen 0 und 100 ausgewählt.
Sie haben 5 Leben. Viel Glück!
 
Geben Sie Ihre Schätzung ein: 
> 50
Die Zahl ist zu hoch! Sie haben noch 4 Leben.
 
Geben Sie Ihre Schätzung ein: 
> 25
Die Zahl ist zu klein! Sie haben noch 3 Leben.
 
Geben Sie Ihre Schätzung ein: 
> 37
Die Zahl ist zu hoch! Sie haben noch 2 Leben.
 
Geben Sie Ihre Schätzung ein: 
> 30
Die Zahl ist zu klein! Sie haben noch 1 Leben.
 
Geben Sie Ihre Schätzung ein: 
> 35
Game Over! Die geheime Zahl war: 33

 
### Hinweise
#### Zufällige Zahl generieren:
Verwenden Sie int geheimZahl = (int) (Math.random() * 100); (Die Zahl liegt dann zwischen 0 und 100).
#### Variable für Leben:
int leben = 5 (Zählt, wie viele Leben der Benutzer hat).
#### Benutzereingabe:
Nutzen Sie Scanner, um Eingaben aus der Konsole zu lesen.
#### Zusatzaufgabe (optional):
Geben Sie am Ende die Anzahl der Versuche aus, die der Benutzer benötigt hat, um die Zahl zu erraten.
Fügen Sie eine Möglichkeit hinzu, das Spiel nach einem Durchgang erneut zu starten.