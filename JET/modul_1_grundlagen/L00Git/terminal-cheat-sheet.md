# Schnellstart: Shell-Grundlagen & Git-Installation

Bevor du Git effektiv nutzen kannst, benötigst du zwei Dinge: die Fähigkeit, dich in einem Terminal (auch "Shell" oder "Kommandozeile" genannt) zu bewegen, und natürlich eine installierte Version von Git.

---

## 1. Grundlegende Shell-Befehle

Das Terminal ist ein textbasiertes Fenster, in dem du deinem Computer direkt Befehle gibst. Hier sind die wichtigsten Navigationsbefehle:

### `ls` (Linux/Mac) oder `dir` (Windows)
**Listet den Inhalt des aktuellen Verzeichnisses auf.** Du siehst alle Dateien und Ordner an deinem aktuellen Standort.

```bash
# Auf Mac oder Linux
ls

# Auf Windows
dir
```

### `cd`
**Change Directory** - der wichtigste Befehl, um dich zu bewegen.

```bash
# Wechsle in einen Unterordner namens "Dokumente"
cd Dokumente

# Gehe ein Verzeichnis nach oben
cd ..

# Gehe in dein persönliches "Home"-Verzeichnis
cd ~
# oder einfach nur
cd
```

### `pwd`
**Print Working Directory** - zeigt dir an, in welchem Verzeichnis du dich gerade befindest. Sehr nützlich, wenn du die Orientierung verloren hast.

```bash
pwd
# Mögliche Ausgabe: /Users/deinname/Projekte
```

### `mkdir`
**Make Directory** - erstellt einen neuen Ordner.

```bash
# Erstellt einen neuen Ordner namens "Mein-Git-Projekt"
mkdir Mein-Git-Projekt
```

### Tab-Vervollständigung
**Dein bester Freund im Terminal!** Tippe die ersten paar Buchstaben eines Befehls, einer Datei oder eines Ordners und drücke die `Tab`-Taste. Die Shell vervollständigt den Namen automatisch für dich. Das spart Zeit und vermeidet Tippfehler.

---

## 2. Git-Installation

Überprüfe zuerst, ob Git vielleicht schon installiert ist, indem du diesen Befehl eingibst:

```bash
git --version
```

Wenn du eine Versionsnummer siehst (z.B. `git version 2.37.1`), bist du fertig. Wenn nicht, befolge die Anleitung für dein Betriebssystem.

### Windows

1.  Die beste Methode ist die Installation von **Git for Windows**. Dies gibt dir nicht nur Git, sondern auch eine nützliche Shell (Git Bash), die sich wie ein Linux-Terminal verhält.
2.  Lade das Installationsprogramm von der offiziellen Webseite herunter: [git-scm.com/download/win](https://git-scm.com/download/win)
3.  Führe die heruntergeladene `.exe`-Datei aus. Die Standardeinstellungen sind in der Regel für den Anfang völlig ausreichend. Klicke dich einfach durch die Installation.

### macOS

Git ist auf den meisten modernen macOS-Systemen bereits vorinstalliert. Wenn der Befehl `git --version` fehlschlägt, gibt es zwei einfache Wege:

1.  **Xcode Command Line Tools (empfohlen):** Das System wird dich wahrscheinlich automatisch fragen, ob du die "command line developer tools" installieren möchtest, wenn du `git` zum ersten Mal ausführst. Stimme einfach zu. Alternativ kannst du die Installation manuell starten:
    ```bash
    xcode-select --install
    ```
2.  **Homebrew:** Wenn du den Paketmanager Homebrew verwendest, kannst du Git einfach damit installieren:
    ```bash
    brew install git
    ```

### Linux (Debian/Ubuntu)

Auf den meisten Debian-basierten Linux-Distributionen (wie Ubuntu) kannst du Git direkt mit dem Paketmanager `apt` installieren.

1.  Öffne ein Terminal.
2.  Aktualisiere zuerst deine Paketlisten:
    ```bash
    sudo apt update
    ```
3.  Installiere Git:
    ```bash
    sudo apt install git
    ```

Nach der Installation solltest du `git --version` erneut ausführen, um sicherzustellen, dass alles geklappt hat.