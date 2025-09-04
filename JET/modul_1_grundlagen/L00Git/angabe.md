# Git Kollaborations-Übung: Bubble Sort

In dieser Übung werdet ihr als **UserA** und **UserB** an einem gemeinsamen Repository arbeiten. Ihr werdet Code hinzufügen, Änderungen verwalten und absichtlich Konflikte erzeugen, um deren Lösung zu lernen.

**Ziel:** Am Ende sollt ihr sicher im Umgang mit dem täglichen Git-Workflow, dem Branching und der Konfliktlösung sein.

---

## 1. Vorbereitung und Setup

### 1.1 Repository erstellen und Mitarbeiter hinzufügen (Nur UserA)

1.  **UserA:** Gehe auf GitHub und erstelle ein neues, **privates** Repository. Nenne es `Git-Uebung-BubbleSort`.
2.  **UserA:** Navigiere in deinem neuen Repository zu `Settings` > `Collaborators`.
3.  **UserA:** Füge **UserB** als Mitarbeiter hinzu, indem du seinen GitHub-Benutzernamen eingibst.
4.  **UserB:** Überprüfe deine E-Mails und nimm die Einladung an.

### 1.2 Repository klonen (Beide User)

Jeder von euch klont nun das Repository auf seinen eigenen Computer.

```bash
# Ersetze <url_des_repos> mit der URL von GitHub
git clone <url_des_repos>
cd Git-Uebung-BubbleSort
```

### 1.3 Git-Benutzer konfigurieren (Beide User)

Stellt sicher, dass Git weiß, wer ihr seid. Führt diese Befehle mit euren eigenen Daten im Terminal aus.

```bash
git config --global user.name "Dein Name"
git config --global user.email "deine@email.com"
```

**Hinweis zu HTTPS vs. SSH:**
* **HTTPS:** Verwendet eine URL wie `https://github.com/...`. Bei jedem Push werdet ihr nach eurem GitHub-Benutzernamen und einem Personal Access Token (PAT) gefragt.
* **SSH:** Verwendet eine URL wie `git@github.com:...`. Dies erfordert die Einrichtung von SSH-Schlüsseln, ist aber danach passwortlos. Für diese Übung sind beide Methoden in Ordnung.

---

## 2. Der grundlegende Workflow

### 2.1 `.gitignore` hinzufügen (UserA)

Wir beginnen damit, eine `.gitignore`-Datei für C# / Visual Studio Projekte hinzuzufügen.

1.  **UserA:** Erstelle eine Datei namens `.gitignore` im Hauptverzeichnis des Projekts. Füge folgenden Inhalt hinzu:

    ```
    # .gitignore für C# / Visual Studio

    # User-spezifische Dateien
    *.suo
    *.user
    *.userosscache
    *.sln.docstates

    # Build-Ergebnisse
    [Bb]in/
    [Oo]bj/

    # Rider
    .idea/
    ```

2.  **UserA:** Überprüfe den Status.

    ```bash
    git status
    # Erwartete Ausgabe:
    # On branch main
    # Untracked files:
    #   .gitignore
    ```

3.  **UserA:** Füge die Datei hinzu, committe sie und pushe sie.

    ```bash
    git add .gitignore
    git commit -m "Feat: Füge .gitignore für C# hinzu"
    git push
    ```

### 2.2 Änderungen abrufen (UserB)

1.  **UserB:** Überprüfe deinen lokalen Status. Git weiß noch nichts von den neuen Änderungen.

    ```bash
    git status
    # Erwartete Ausgabe:
    # On branch main
    # Your branch is up to date with 'origin/main'.
    ```

2.  **UserB:** Hole die Änderungen vom Server.

    ```bash
    git pull
    ```

3.  **UserB:** Überprüfe den Status erneut. Die `.gitignore`-Datei sollte nun auch bei dir vorhanden sein.

    ```bash
    git status
    # Erwartete Ausgabe:
    # On branch main
    # Your branch is up to date with 'origin/main'.
    ```

### 2.3 Bubble Sort Algorithmus hinzufügen (UserA)

1.  **UserA:** Erstelle eine Datei `BubbleSort.cs` mit folgendem Inhalt (absichtlich ohne die `- j` Optimierung):

    ```csharp
    using System;

    public class BubbleSort
    {
        public static void Main(string[] args)
        {
            int[] zahlen = { 5, 1, 4, 2, 8 };
            Console.WriteLine("Unsortierte Zahlen:");
            DruckeArray(zahlen);

            Sortiere(zahlen);

            Console.WriteLine("\nSortierte Zahlen:");
            DruckeArray(zahlen);
        }

        public static void Sortiere(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                // Die innere Schleife durchläuft das Array
                for (int j = 0; j < n - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void DruckeArray(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
    ```

2.  **UserA:** Führe den Add-Commit-Push-Zyklus durch.

    ```bash
    git status
    git add BubbleSort.cs
    git commit -m "Feat: Füge Bubble Sort Algorithmus hinzu"
    git push
    ```

3.  **UserB:** Hole die neue Datei mit `git pull`.

---

## 3. Änderungen und Fehler korrigieren

### 3.1 Änderungen verwerfen (`checkout`) (UserA)

1.  **UserA:** Ändere die Zeile `int[] zahlen = { 5, 1, 4, 2, 8 };` zu `int[] zahlen = { 99, 50, 10, 3, 1 };`. Speichere die Datei.
2.  **UserA:** Sieh dir den Unterschied an.

    ```bash
    git diff
    # Zeigt dir die exakte Änderung an der Zeile.
    ```

3.  **UserA:** Du entscheidest dich, die Änderung doch nicht zu wollen. Verwirf sie.

    ```bash
    git checkout -- BubbleSort.cs
    ```

4.  **UserA:** Überprüfe den Status. Alles ist wieder sauber.

    ```bash
    git status
    # On branch main
    # Your branch is up to date with 'origin/main'.
    ```

### 3.2 Staging rückgängig machen (UserA)

1.  **UserA:** Ändere die Zahlen erneut, wie im Schritt zuvor.
2.  **UserA:** Füge die Datei zum Staging-Bereich hinzu.

    ```bash
    git add BubbleSort.cs
    git status
    # Erwartete Ausgabe:
    # Changes to be committed:
    #   modified:   BubbleSort.cs
    ```

3.  **UserA:** Du bemerkst, du willst diesen Change doch nicht committen. Nimm ihn aus dem Staging-Bereich wieder heraus ("unstage").

    ```bash
    git reset HEAD BubbleSort.cs
    git status
    # Erwartete Ausgabe:
    # Changes not staged for commit:
    #   modified:   BubbleSort.cs
    ```

4.  **UserA:** Verwirf die Änderung endgültig mit `git checkout -- BubbleSort.cs`.

### 3.3 Letzten Commit korrigieren (`amend`) (UserB)

1.  **UserB:** "Verschlimmbessere" den Code, indem du einen Bug einbaust. Ändere `if (arr[j] > arr[j + 1])` zu `if (arr[j] < arr[j + 1])`. Der Algorithmus sortiert nun falsch.
2.  **UserB:** Committe diesen Fehler mit einer unklaren Nachricht.

    ```bash
    git add BubbleSort.cs
    git commit -m "Änderung an Sortierlogik"
    # NICHT PUSHEN!
    ```

3.  **UserB:** Du bemerkst den Fehler. Korrigiere den Code zurück zu `if (arr[j] > arr[j + 1])`.
4.  **UserB:** Korrigiere den letzten Commit, indem du die Code-Änderung hinzufügst und die Nachricht verbesserst.

    ```bash
    git add BubbleSort.cs
    git commit --amend -m "Fix: Korrigiere Sortierlogik zu aufsteigend"
    git push
    ```

5.  **UserA:** Hole die korrigierte Version mit `git pull`.

---

## 4. Merge-Konflikte

### 4.1 Der erste Konflikt (Standard-Merge)

Jetzt erzeugen wir einen absichtlichen Konflikt.

1.  **UserA & UserB:** Stellt sicher, dass ihr beide auf dem neuesten Stand seid (`git pull`).
2.  **UserA:** Ändere die zu sortierenden Zahlen. Ändere die Zeile `int[] zahlen = { 5, 1, 4, 2, 8 };` zu `int[] zahlen = { 10, 3, 18, 1, 99 };`.
3.  **UserA:** Committe und pushe die Änderung.

    ```bash
    git add BubbleSort.cs
    git commit -m "Feat: Aktualisiere zu sortierende Zahlen"
    git push
    ```

4.  **UserB:** Füge die Performance-Optimierung hinzu. Ändere die innere Schleife `for (int j = 0; j < n - 1; j++)` zu `for (int j = 0; j < n - 1 - i; j++)`.
5.  **UserB:** Committe die Änderung (noch nicht pushen!).

    ```bash
    git add BubbleSort.cs
    git commit -m "Perf: Optimiere innere Schleife von Bubble Sort"
    ```

6.  **UserB:** Versuche nun, die Änderungen von UserA zu holen.

    ```bash
    git pull
    # FEHLER! Du erhältst eine Merge-Konflikt-Meldung.
    # Auto-merging BubbleSort.cs
    # CONFLICT (content): Merge conflict in BubbleSort.cs
    ```

7.  **UserB:** Öffne `BubbleSort.cs` in einem Editor. Du siehst die Konfliktmarker:

    ```csharp
    // ...
    public static void Main(string[] args)
    {
    <<<<<<< HEAD
        int[] zahlen = { 5, 1, 4, 2, 8 };
    =======
        int[] zahlen = { 10, 3, 18, 1, 99 };
    >>>>>>> abc123def456... (Feat: Aktualisiere zu sortierende Zahlen)
        Console.WriteLine("Unsortierte Zahlen:");
    // ...
    // Und ein weiterer Konflikt bei der Schleife...
    // ...
    ```

8.  **UserB:** Löse den Konflikt, indem du die Marker entfernst und den Code so anpasst, dass **beide** Änderungen enthalten sind. Das korrekte Ergebnis ist:

    ```csharp
    //...
    int[] zahlen = { 10, 3, 18, 1, 99 }; // Die neuen Zahlen von UserA
    //...
    for (int j = 0; j < n - 1 - i; j++) // Die Optimierung von UserB
    //...
    ```

9.  **UserB:** Schließe den Merge ab.

    ```bash
    git add BubbleSort.cs
    git commit # Es öffnet sich ein Editor mit einer vorgefertigten Merge-Nachricht. Speichern & schließen.
    git push
    ```

10. **Beide User:** Schaut euch den Verlauf an. Ihr seht nun einen "Merge-Bubble".

    ```bash
    git log --graph --oneline --all
    ```

### 4.2 Der zweite Konflikt (mit Rebase lösen)

Ein Rebase vermeidet den Merge-Commit und sorgt für eine saubere, lineare Historie.

1.  **UserA & UserB:** Stellt sicher, dass ihr beide auf dem neuesten Stand seid (`git pull`).
2.  **UserA:** Ändere den Kommentar `// Die innere Schleife durchläuft das Array` zu `// Die innere Schleife vergleicht benachbarte Elemente`.
3.  **UserA:** Committe und pushe.

    ```bash
    git add BubbleSort.cs
    git commit -m "Docs: Verbessere Kommentar in Sortierfunktion"
    git push
    ```

4.  **UserB:** Ändere den **gleichen** Kommentar zu `// Innere Schleife für den Sortiervorgang`.
5.  **UserB:** Committe lokal.

    ```bash
    git add BubbleSort.cs
    git commit -m "Docs: Passe Kommentar an"
    ```

6.  **UserB:** Führe nun einen Pull mit Rebase durch.

    ```bash
    git pull --rebase
    # FEHLER! Du erhältst wieder einen Konflikt.
    ```

7.  **UserB:** Löse den Konflikt wie zuvor, indem du den Kommentar manuell auf einen finalen Stand bringst (z.B. den von UserA).
8.  **UserB:** Schließe den Rebase ab.

    ```bash
    git add BubbleSort.cs
    git rebase --continue
    ```

9.  **UserB:** Pushe deine Änderungen.

    ```bash
    git push
    # Möglicherweise ist ein --force-with-lease nötig, da du deine Historie umgeschrieben hast.
    # Git wird dir den korrekten Befehl vorschlagen.
    ```

10. **Beide User:** Schaut euch den Verlauf an. Er ist linear, ohne Merge-Commit.

---

## 5. Mit Branches arbeiten

### 5.1 Branches erstellen und wechseln

1.  **UserA:** Erstelle einen Branch für dein neues Feature und wechsle dorthin.

    ```bash
    git checkout -b feature/bunte-ausgabe-A
    ```

2.  **UserB:** Mache dasselbe für dein Feature.

    ```bash
    git checkout -b feature/bunte-ausgabe-B
    ```

3.  **Beide:** Übt das Wechseln.

    ```bash
    git checkout main      # Wechselt zum main-Branch
    git checkout <euer-branch-name> # Wechselt zurück
    ```

### 5.2 Änderungen zwischenspeichern (`stash`) (UserA)

1.  **UserA:** Beginne auf deinem Branch `feature/bunte-ausgabe-A` mit der Arbeit. Ändere die `DruckeArray`-Methode, aber mache sie unfertig (z.B. nur die erste Zeile):

    ```csharp
    public static void DruckeArray(int[] arr)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        // Hier fehlt noch Code...
    }
    ```

2.  **UserA:** Du musst dringend auf den `main`-Branch wechseln. Speichere deine unfertige Arbeit im "Stash".

    ```bash
    git stash
    git status # Dein Branch ist jetzt sauber
    ```

3.  **UserA:** Wechsle zu `main` und wieder zurück.
4.  **UserA:** Hole deine Änderungen aus dem Stash zurück.

    ```bash
    git stash pop
    ```
    Die unfertige Code-Zeile ist wieder da.

### 5.3 Features implementieren und mergen (Konflikt!)

1.  **UserA:** Implementiere dein Feature fertig. Die Zahlen sollen grün ausgegeben werden.

    ```csharp
    public static void DruckeArray(int[] arr)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(string.Join(", ", arr));
        Console.ResetColor(); // Wichtig: Farbe zurücksetzen
    }
    ```

2.  **UserA:** Committe und pushe deinen Branch.

    ```bash
    git add .
    git commit -m "Feat: Gib Array in grüner Farbe aus"
    git push --set-upstream origin feature/bunte-ausgabe-A
    ```

3.  **UserB:** Implementiere dein Feature. Die Zahlen sollen einen gelben Hintergrund haben.

    ```csharp
    public static void DruckeArray(int[] arr)
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(string.Join(", ", arr));
        Console.ResetColor();
    }
    ```

4.  **UserB:** Committe und pushe deinen Branch.

    ```bash
    git add .
    git commit -m "Feat: Gib Array mit gelbem Hintergrund aus"
    git push --set-upstream origin feature/bunte-ausgabe-B
    ```

5.  **UserA:** Merge dein Feature in den `main`-Branch.

    ```bash
    git checkout main
    git pull
    git merge feature/bunte-ausgabe-A
    git push
    ```

6.  **UserB:** Versuche nun, dein Feature zu mergen.

    ```bash
    git checkout main
    git pull # Hole die Änderungen von UserA
    git merge feature/bunte-ausgabe-B # KONFLIKT!
    ```

7.  **UserB:** Löst den Konflikt in der `DruckeArray`-Methode, indem ihr beide Features kombiniert: grüne Schrift auf gelbem Grund.

    ```csharp
    public static void DruckeArray(int[] arr)
    {
        Console.BackgroundColor = ConsoleColor.Yellow; // von UserB
        Console.ForegroundColor = ConsoleColor.Green;   // von UserA (angepasst von Black)
        Console.WriteLine(string.Join(", ", arr));
        Console.ResetColor();
    }
    ```

8.  **UserB:** Schließe den Merge ab und pushe.

    ```bash
    git add .
    git commit
    git push
    ```

```

# Git-Anleitung: Auf einen alten Commit zurücksetzen (Hard Reset)

Manchmal gerät ein Projekt in eine Sackgasse. Mehrere Commits waren fehlerhaft und du möchtest einfach zu einem früheren, funktionierenden Zustand zurückkehren und so tun, als wären die letzten Änderungen nie passiert.

Genau das macht `git reset --hard`. Es ist ein extrem mächtiger Befehl, der wie eine Zeitmaschine funktioniert, aber auch gefährlich sein kann.

**⚠️ Warnung:** Dieser Prozess löscht die nachfolgende Commit-Historie und alle darin enthaltenen Änderungen endgültig. Führe diese Schritte nur aus, wenn du absolut sicher bist, dass du die neueren Commits nicht mehr benötigst.

---

## Schritt 1: Den Ziel-Commit finden

Zuerst musst du den genauen "Schnappschuss" (Commit) identifizieren, zu dem du zurückkehren möchtest.

1.  Lass dir die Commit-Historie anzeigen. Der Befehl `git log --oneline` ist dafür ideal, da er eine kompakte Übersicht liefert.

    ```bash
    git log --oneline
    ```

2.  Du erhältst eine Ausgabe, die etwa so aussieht:

    ```
    a1b2c3d (HEAD -> main) Feat: Füge kaputtes Feature Z hinzu
    e4f5g6h Refactor: Beginne mit fehlerhaftem Umbau Y
    i7j8k9l Feat: Füge stabiles Feature X hinzu  <-- ZU DIESEM PUNKT WOLLEN WIR ZURÜCK!
    f0g1h2i Docs: Aktualisiere die Readme-Datei
    ```

3.  Kopiere den Hash (die 7-stellige Zeichenkette) des Commits, der dein Ziel ist. In unserem Beispiel ist das **`i7j8k9l`**. Dies ist der letzte stabile Zustand, den du wiederherstellen möchtest.

---

## Schritt 2: Den Reset durchführen (Lokales Repository)

Jetzt setzt du dein lokales Repository auf den exakten Zustand des Ziel-Commits zurück. Alle Commits und Änderungen, die danach kamen, werden verworfen.

1.  Führe den `reset --hard` Befehl mit dem kopierten Hash aus.

    ```bash
    git reset --hard i7j8k9l
    ```

2.  Git gibt eine Bestätigung aus, die so aussieht: `HEAD is now at i7j8k9l Feat: Füge stabiles Feature X hinzu`.

3.  Wenn du jetzt `git log --oneline` erneut ausführst, wirst du sehen, dass die Commits `a1b2c3d` und `e4f5g6h` aus deiner lokalen Historie verschwunden sind. Dein lokales Projekt ist nun exakt auf dem Stand von Commit `i7j8k9l`.

---

## Schritt 3: Den Remote-Server aktualisieren (Überschreiben erzwingen)

Wenn du die "schlechten" Commits bereits auf GitHub (oder einen anderen Remote-Server) gepusht hast, ist dein lokales Repository nun "hinter" dem Remote-Repository. Ein normaler `git push` wird fehlschlagen, weil Git dich davor schützen will, versehentlich Historie zu löschen.

In diesem Fall musst du Git zwingen, den Zustand deines lokalen Repositorys auf den Server zu übertragen und die dortige Historie zu überschreiben.

**⚠️ Warnung:** Das Umschreiben der öffentlichen Historie kann für Teamkollegen, die die alten Commits bereits heruntergeladen haben, zu großen Problemen führen. Führe diesen Schritt nur aus, wenn du alleine am Projekt arbeitest oder dich mit deinem Team abgesprochen hast.

1.  Führe einen "Force Push" durch.

    ```bash
    git push --force
    ```
    *Eine sicherere Alternative ist `git push --force-with-lease`, die nur dann pusht, wenn niemand anderes in der Zwischenzeit neue Änderungen auf den Branch gepusht hat.*

2.  Nach diesem Befehl ist auch das Remote-Repository auf dem alten Stand. Die fehlerhaften Commits sind nun auch dort effektiv gelöscht und der Commit `i7j8k9l` ist der neue `HEAD` des Branches.
```