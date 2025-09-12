# Ein Leitfaden für Git und GitHub Classroom

Dieser Leitfaden bietet eine umfassende Übersicht über die Verwendung von Git für deine Aufgaben – von den grundlegenden Befehlen bis hin zu fortgeschrittenen Konzepten wie Branching und Rebasing.

## 1. GitHub Classroom: Wie es funktioniert

GitHub Classroom automatisiert den Prozess der Verteilung und des Einsammelns von Aufgaben.

* **Die Aufgabe annehmen:** Dein Lehrer stellt für jede Aufgabe eine eindeutige URL zur Verfügung. Wenn du auf diesen Link klickst, wird ein **privates Repository** für dich erstellt. Dies ist dein persönlicher Arbeitsbereich für die Aufgabe.
* **An der Aufgabe arbeiten:** Du bearbeitest die Aufgabe lokal auf deinem Computer und verwendest Git, um deinen Fortschritt in deinem privaten Repository auf GitHub zu speichern.
* **Abgabe:** Es gibt keinen "Abgabe"-Button. Deine Abgabe ist einfach der Zustand deines Repositorys zum Zeitpunkt der Deadline. Dein Lehrer kann alle deine Commits und den Verlauf deiner Arbeit einsehen.
* **Autograding:** Viele Aufgaben verwenden **GitHub Actions** für die automatische Bewertung. Das bedeutet, dass jedes Mal, wenn du deinen Code `pushst`, eine Reihe von automatisierten Tests ausgeführt wird. Die Ergebnisse dieser Tests kannst du im Tab "Actions" deines Repositorys einsehen, was dir sofortiges Feedback zu deiner Arbeit gibt.

---

## 2. Der grundlegende Git-Workflow

Dies ist der Zyklus von Befehlen, den du am häufigsten verwenden wirst.

### `git clone`

Dieser Befehl lädt eine Kopie eines Repositorys von GitHub auf deinen lokalen Rechner herunter. Dies musst du nur einmal pro Aufgabe tun.

```bash
git clone <repository_url>
```

### `git status`

Dieser Befehl zeigt dir den aktuellen Zustand deines Repositorys an. Er sagt dir, welche Dateien geändert wurden, welche neu sind und welche für den nächsten Commit vorgemerkt sind ("staged"). Es ist eine gute Praxis, diesen Befehl häufig auszuführen.

```bash
git status
```

### `git add` und `git commit`

Diese beiden Befehle werden verwendet, um deine Arbeit zu speichern. Ein **Commit** ist ein Schnappschuss deines Codes zu einem bestimmten Zeitpunkt.

1.  **Änderungen vormerken (staging):** Mit `git add` teilst du Git mit, welche Dateien du in den nächsten Commit aufnehmen möchtest. Du kannst Dateien einzeln hinzufügen oder einen `.` verwenden, um alle geänderten Dateien im aktuellen Verzeichnis hinzuzufügen.
    ```bash
    # Eine einzelne Datei vormerken
    git add rechner.py

    # Alle geänderten Dateien vormerken
    git add .
    ```
2.  **Änderungen committen:** Mit `git commit` speicherst du die vorgemerkten Änderungen. Du musst mit dem Flag `-m` eine aussagekräftige Nachricht hinzufügen.
    ```bash
    git commit -m "Feat: Füge Subtraktionsfunktion hinzu"
    ```
    * **Gute Commit-Nachrichten sind wichtig!** Sie sollten im Präsens formuliert sein und beschreiben, was der Commit *tut* (z.B. "Fix: Korrigiere Berechnungsfehler in Divisionsfunktion").

### `git push`

Dieser Befehl lädt deine Commits von deinem lokalen Rechner in dein Repository auf GitHub hoch.

```bash
git push
```

### `git pull`

Dieser Befehl lädt alle Änderungen aus dem Remote-Repository auf GitHub herunter und fügt sie in deine lokale Kopie ein. Wenn du mit anderen an einem Projekt arbeitest, solltest du dies tun, bevor du mit der Arbeit beginnst, um sicherzustellen, dass du die neueste Version des Codes hast.

```bash
git pull
```

---

## 3. Informationen abrufen

Diese Befehle helfen dir, die Historie deines Projekts und die von dir vorgenommenen Änderungen zu verstehen.

### `git diff`

Dieser Befehl zeigt dir die genauen Änderungen an, die du seit deinem letzten Commit an deinen Dateien vorgenommen hast. Hinzugefügte Zeilen werden grün und entfernte Zeilen rot dargestellt.

```bash
git diff
```

### `git log`

Dieser Befehl zeigt dir eine Historie aller Commits in deinem Projekt.

```bash
git log

# Eine kompaktere Ansicht der Commit-Historie
git log --oneline

# Eine Ansicht mit Verzweigungen (Branches)
git log --oneline --graph --all
```

---

## 4. Branching: Parallel arbeiten

Branches ermöglichen es dir, an neuen Funktionen oder Fehlerbehebungen zu arbeiten, ohne die Haupt-Codebasis zu beeinträchtigen. Der Haupt-Branch wird normalerweise `main` oder `master` genannt.

### `git branch`

Dieser Befehl zeigt dir eine Liste aller Branches in deinem Repository an. Der Branch, auf dem du dich gerade befindest, wird mit einem Sternchen (`*`) markiert.

```bash
git branch
```

### `git checkout -b`

Dieser Befehl erstellt einen neuen Branch und wechselt sofort zu ihm.

```bash
# Erstelle einen neuen Branch namens "feature/add-division" und wechsle zu ihm
git checkout -b feature/add-division
```

### `git checkout`

Dieser Befehl wechselt zwischen bestehenden Branches.

```bash
# Wechsle zurück zum main-Branch
git checkout main
```

---

## 5. Fehler korrigieren und Verlauf umschreiben

Diese Befehle ermöglichen es dir, Fehler zu korrigieren, von kleinen Tippfehlern bis hin zu größeren Patzern. **Verwende diese Befehle mit Vorsicht, da sie den Verlauf deines Projekts dauerhaft verändern können.**

### `git checkout -- <datei>`

Dieser Befehl verwirft alle Änderungen, die du seit deinem letzten Commit an einer Datei vorgenommen hast. **Dies ist eine destruktive Operation und kann nicht rückgängig gemacht werden.**

```bash
# Verwirf alle Änderungen in der Datei rechner.py
git checkout -- rechner.py
```

### `git commit --amend`

Mit diesem Befehl kannst du die Nachricht deines letzten Commits ändern.

```bash
# Korrigiere den letzten Commit mit einer neuen Nachricht
git commit --amend -m "Eine bessere Commit-Nachricht"
```

### `git reset --hard`

Dieser Befehl setzt den aktuellen Branch auf einen früheren Commit zurück und verwirft alle Commits, die danach kamen. **Dies ist eine sehr destruktive Operation.**

1.  Verwende `git log --oneline`, um den Commit zu finden, zu dem du zurückkehren möchtest.
2.  Verwende `git reset --hard` mit dem Commit-Hash.

```bash
# Gehe zu einem früheren Commit zurück und verwerfe alle nachfolgenden Commits
git reset --hard <commit_hash>
```

Wenn du die "schlechten" Commits bereits auf GitHub gepusht hast, musst du `git push --force` verwenden, um das Remote-Repository zu aktualisieren. **Sei sehr vorsichtig beim Force-Pushen, da dies Probleme für Mitarbeiter verursachen kann.**

### `git rebase -i`

Rebasing ist eine mächtige Methode, um die Historie umzuschreiben. Es ermöglicht dir, deine Commits zu kombinieren, neu anzuordnen und zu bearbeiten. Ein **interaktiver Rebase** (`-i`) ist eine hervorragende Möglichkeit, deine Commit-Historie aufzuräumen, bevor du deine Arbeit teilst.

Angenommen, deine Commit-Historie sieht so aus:
```
a1b2c3d (HEAD -> feature) Ups, Datei vergessen
e4f5g6h Füge neues Feature hinzu
i7j8k9l Beginne mit der Arbeit am neuen Feature
```
Du kannst einen interaktiven Rebase verwenden, um diese Commits zu einem einzigen, sauberen Commit zusammenzufassen ("squash").

1.  Starte den interaktiven Rebase. `HEAD~3` teilt Git mit, die letzten 3 Commits zu betrachten.
    ```bash
    git rebase -i HEAD~3
    ```
2.  Dies öffnet einen Texteditor mit einer Liste deiner Commits. Um sie zu kombinieren, ändere `pick` in `squash` (oder `s`) für die Commits, die du mit dem darüber liegenden zusammenführen möchtest.
    ```
    pick i7j8k9l Beginne mit der Arbeit am neuen Feature
    squash e4f5g6h Füge neues Feature hinzu
    squash a1b2c3d Ups, Datei vergessen
    ```
3.  Speichere und schließe den Editor. Git öffnet dann einen weiteren Editor, in dem du eine neue, saubere Commit-Nachricht für den kombinierten Commit schreiben kannst.

---

## 6. Änderungen vorübergehend speichern (`git stash`)

Manchmal musst du dringend den Branch wechseln, aber deine aktuelle Arbeit ist noch nicht bereit für einen Commit. `git stash` ist die Lösung. Es speichert deine uncommitteten Änderungen vorübergehend weg.

* **Szenario:** Du arbeitest an einem neuen Feature, als ein dringender Bug gemeldet wird. Du musst sofort den Branch wechseln, aber deine Arbeit ist noch unfertig.

### `git stash`

Speichert deine aktuellen Änderungen (sowohl "staged" als auch "unstaged") in einem Zwischenspeicher ("Stash") und setzt dein Arbeitsverzeichnis auf den Zustand des letzten Commits zurück. Jetzt ist dein Arbeitsverzeichnis sauber und du kannst den Branch wechseln.

```bash
git stash
```

### `git stash list`

Zeigt dir eine Liste aller gespeicherten Stashes an.

```bash
git stash list
# Ausgabe könnte so aussehen:
# stash@{0}: WIP on feature/add-division: i7j8k9l Füge Multiplikationsfunktion hinzu
```

### `git stash pop`

Wendet den zuletzt gespeicherten Stash wieder an **und entfernt ihn aus der Liste**. Dies ist der häufigste Weg, um deine Arbeit wiederherzustellen, nachdem du zurück auf deinen Branch gewechselt bist.

```bash
# Wechsle zurück zu deinem Feature-Branch
git checkout feature/add-division

# Hole deine gespeicherten Änderungen zurück
git stash pop
```

---

## 7. Die `.gitignore`-Datei

Eine `.gitignore`-Datei teilt Git mit, welche Dateien und Verzeichnisse ignoriert werden sollen. Dies ist nützlich, um temporäre Dateien, Systemdateien und geheime Dateien (wie API-Schlüssel) daran zu hindern, in dein Repository committet zu werden.

* **Wo sie hingehört:** Die `.gitignore`-Datei sollte im **Hauptverzeichnis (root)** deines Repositorys platziert werden.
* **Was hineingehört:** Jede Zeile in der Datei sollte ein Muster für eine Datei oder ein Verzeichnis sein, das du ignorieren möchtest.

```
# Ignoriere Python's Bytecode-Dateien
__pycache__/
*.pyc

# Ignoriere virtuelle Umgebungen
venv/
.env

# Ignoriere OS-spezifische Dateien
.DS_Store
```

### Häufige Fehler mit `.gitignore`

* **Datei wird bereits getrackt:** Wenn du eine Datei bereits committet hast und sie dann zu deiner `.gitignore` hinzufügst, wird Git sie weiterhin verfolgen. Du musst Git explizit anweisen, die Datei nicht mehr zu verfolgen:
    ```bash
    git rm --cached <datei>
    git commit -m "Entferne <datei> aus der Nachverfolgung"
    ```
* **`.gitignore`-Datei vergessen zu committen:** Die `.gitignore`-Datei ist nur eine weitere Datei in deinem Repository. Du musst sie mit `git add .gitignore` hinzufügen und committen, damit sie für andere, die dein Repository klonen, wirksam wird.
```