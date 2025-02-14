package lerneinheiten.L04CollectionsUndDictionaries.verwendung_von_collections_und_foreach;

import java.util.*;

public class Operationen {
    public static void main(String[] args) {
        // ############################## LIST ##############################
        // Eine Liste sollte verwendet werden, wenn die Reihenfolge der Elemente wichtig ist und
        // die Elemente in der Sammlung dupliziert werden dürfen.
        // Beispiele für Listen sind ArrayList und LinkedList.

        // Variationen von Listen:

        // ArrayList:
        // Die ArrayList ist eine Implementierung der List, die auf einem Array basiert und schnell Zugriff auf Elemente durch Indizes ermöglicht.
        // Sie eignet sich gut für Szenarien,
        // - in denen häufiger auf Elemente über Indizes zugegriffen wird und
        // - ähnlich oft gelöscht, wie hinzugefügt wird

        // LinkedList:
        // Die LinkedList ist eine Implementierung der List, bei der jedes Element ein Verweis auf das vorherige und das nächste Element enthält.
        // Sie eignet sich besser für Szenarien, in denen
        // - häufige Einfügungen und Löschungen am Anfang oder Ende der Liste, sowie
        // - wenig suchen erforderlich sind.

        // Verwende ArrayList als standard Liste.

        // CRUD (Create, Read, Update, Delete) bezieht sich auf die grundlegenden Operationen, die auf Daten angewendet werden.
        // Dieser Begriff stammt ursprünglich aus dem Bereich der Datenbanken, aber er wird auch in der Programmierung für
        // die Arbeit mit Collections wie Listen oder Maps verwendet.
        // CRUD bedeutet:
        // (C)reate: Erstellen von neuen Datenelementen
        // (R)ead: Lesen oder Abrufen von Datenelementen
        // (U)pdate: Aktualisieren von bestehenden Datenelementen
        // (D)elete: Löschen von Datenelementen
        // ArrayList und LinkedList sind beides Implementierungen von Listen in Java, die CRUD-Operationen unterstützen.

        // ArrayList - Syntax:
        ArrayList<String> stringList = new ArrayList<>();
        // CRUD
        // (C)reate
        stringList.add("hallo"); // Fügt "hallo" zur Liste hinzu
        stringList.add("du");    // Fügt "du" zur Liste hinzu
        System.out.println("Create: " + stringList);

        stringList.add(1, "Hallo"); // Fügt "Hallo" an Position 1 ein
        System.out.println("Create: " + stringList);

        // (R)ead
        String result = stringList.get(0); // Liest das Element an Position 0
        System.out.println("Read: " + result);

        // (U)pdate
        stringList.set(1, "wie gehts dir"); // Aktualisiert das Element an Position 1
        System.out.println("Update: " + stringList);

        // (D)elete
        boolean worked = stringList.remove("ik"); // Versucht, "ik" aus der Liste zu entfernen
        System.out.println("Delete: " + stringList);
        System.out.println(worked); // Gibt false aus, da "ik" nicht in der Liste ist

        worked = stringList.remove("hallo"); // Versucht, "hallo" aus der Liste zu entfernen
        System.out.println(worked); // Gibt true aus, wenn "hallo" entfernt wurde

        System.out.println("Delete: " + stringList);

        String removed = stringList.remove(0); // Entfernt das Element an Position 0
        System.out.println(removed);

        // Iterator:
        // Ein Iterator ist ein Objekt, das zum Durchlaufen (Iterieren) über eine Collection verwendet wird.
        // Er stellt Methoden zur Verfügung, um zu überprüfen, ob ein nächstes Element existiert und um das nächste Element
        // zu holen. Die Iterator-Schreibweise ist etwas expliziter, aber flexibel.
        Iterator<String> iterator = stringList.iterator(); // Erstellt einen Iterator für die Liste

        while (iterator.hasNext()) { // Durchläuft die Liste mit dem Iterator
            System.out.println(iterator.next());
        }

        // for-each:
        // Die for-each-Schleife ist eine kompakte und einfache Schreibweise, um über eine Collection zu iterieren.
        // Sie ist besonders praktisch, wenn nur eine einfache Iteration über alle Elemente erforderlich ist.
        // Sie vermeidet das explizite Erstellen eines Iterators.
        for (String element : stringList) { // Durchläuft die Liste mit einer for-each-Schleife
            System.out.println(element);
        }

        // ############################## MAP ##############################
        // Eine Map (z.B. HashMap, TreeMap) sollte verwendet werden, wenn man Daten als Schlüssel-Wert-Paare speichern möchte,
        // wobei der Schlüssel eindeutig sein muss. Die Werte können dupliziert werden, aber jeder Schlüssel kann nur einmal vorkommen.

        // HashMap:
        // Die HashMap ist eine Implementierung der Map, die keine garantierte Reihenfolge bietet.
        // Sie basiert auf einem Hash-Algorithmus und ist besonders schnell bei der Suche, Einfügung und Löschung von Werten.
        // Sie sollte verwendet werden, wenn man eine hohe Leistung bei der Arbeit mit Schlüsseln und Werten benötigt.

        // TreeMap:
        // Die TreeMap ist eine Implementierung der Map, die die Schlüssel in einer bestimmten Reihenfolge speichert (nach natürlicher Reihenfolge oder durch einen Comparator).
        // Sie sollte verwendet werden, wenn man die Schlüssel in einer sortierten Reihenfolge haben möchte.

        // Map:
        HashMap<String, String> myMap = new HashMap<>(); // HashMap speichert Schlüssel-Wert-Paare ohne eine bestimmte Reihenfolge
        HashMap<String, List<String>> myMapWithLists = new HashMap<>();

        // CRUD
        // (C)reate
        myMap.put("myKey300", "myData4000"); // Fügt einen Schlüssel-Wert-Paar zur Map hinzu
        myMap.put("myKey300", "myData3000"); // Überschreibt den Wert für den Schlüssel "myKey300"

        List<String> entry = new ArrayList<>();
        entry.add("sugar");
        entry.add("eiweiß");
        myMapWithLists.put("cola", entry); // Fügt eine Liste als Wert hinzu

        // (R)ead
        System.out.println(myMap.get("myKey300")); // Liest den Wert für den Schlüssel "myKey300"

        // (U)pdate
        System.out.println(myMap.replace("myKey400", "someData")); // Versucht, einen Wert für "myKey400" zu ersetzen
        System.out.println(myMap.replace("myKey300", "someData")); // Ersetzt den Wert für "myKey300"
        System.out.println(myMap);

        // (D)elete
        myMap.remove("myKey300");
        System.out.println(myMap);

        // ForEach loop
        for (String element : myMap.keySet()) { // Gibt alle Schlüssel der Map aus
            System.out.println(element);
        }

        for (String element : myMap.values()) { // Gibt alle Werte der Map aus
            System.out.println(element);
        }

        for (Map.Entry<String, String> element : myMap.entrySet()) { // Durchläuft die Schlüssel-Wert-Paare
            System.out.println(element.getKey());
            System.out.println(element.getValue());
        }


        // ########## Eine Map von Listen ##########

        // Erstellen einer HashMap, die einen String als Key und eine ArrayList als Value speichert
        HashMap<String, List<String>> map = new HashMap<>();

        // Erstellen einer ArrayList mit einigen Werten
        List<String> fruits = new ArrayList<>();
        fruits.add("Apfel");
        fruits.add("Banane");
        fruits.add("Kirsche");

        // Hinzufügen der Liste in die HashMap mit einem Schlüssel
        map.put("Früchte", fruits);

        // Zugriff auf die ArrayList in der HashMap über den Schlüssel
        List<String> retrievedFruits = map.get("Früchte");

        // Ausgabe der Liste
        System.out.println("Fruits List: " + retrievedFruits);

        // Hinzufügen eines weiteren Elements zur ArrayList und Ausgabe der aktualisierten Liste
        retrievedFruits.add("Orange");
        System.out.println("Updated Fruits List: " + retrievedFruits);

        // Zugriff und Ausgabe der aktualisierten Liste aus der HashMap
        System.out.println("Updated List in HashMap: " + map.get("Früchte"));


        // ########## Zu ist beachten ist folgendes bei der Verwendung der ForEach Schleife ##########

        // Beispiel 1: Fehler, wenn die Liste während der Iteration verändert wird
        // Hier versuchen wir, während einer Iteration Elemente aus der Liste zu entfernen.
        // Dies führt zu einer ConcurrentModificationException.
        try {
            for (String element : stringList) {
                System.out.println(element);
                // Versuchen, ein Element zu entfernen, während wir durch die Liste iterieren
                if (element.equals("du")) {
                    stringList.remove(element); // Fehler wird hier geworfen
                }
            }
        } catch (ConcurrentModificationException e) {
            System.out.println("Fehler: ConcurrentModificationException aufgetreten, weil die Liste während der Iteration verändert wurde.");
        }

        // Beispiel 2: Korrektur, um den Fehler zu umgehen
        // Statt die Liste direkt zu ändern, verwenden wir einen Iterator.
        // Der Iterator erlaubt es, sicher Elemente zu entfernen, während wir durch die Liste iterieren.
        iterator = stringList.iterator();

        while (iterator.hasNext()) {
            String element = iterator.next();
            System.out.println(element);
            // Jetzt verwenden wir den Iterator, um das Element zu entfernen
            if (element.equals("du")) {
                iterator.remove(); // Entfernt das Element sicher
            }
        }

        // Ausgabe nach der sicheren Entfernung mit Iterator:
        System.out.println("Liste nach der sicheren Entfernung: " + stringList);

        // Beispiel 3: Lösung mit einer for-each Schleife und einer Kopie der Liste
        // Hier erstellen wir eine Kopie der Liste, damit wir die Kopie während der Iteration manipulieren können,
        // während die Original-Liste durch den Iterator iteriert wird.
        ArrayList<String> copiedList = new ArrayList<>(stringList); // Kopieren der Liste
        for (String element : stringList) {
            System.out.println(element);
            // Manipulation der kopierten Liste (z.B. entfernen von Elementen)
            if (element.equals("hallo")) {
                copiedList.remove(element); // Wir entfernen das Element aus der Kopie
            }
        }

        // Ausgabe der Listen nach der Manipulation:
        System.out.println("Original-Liste nach der Iteration: " + stringList);
        System.out.println("Kopierte Liste nach der Manipulation: " + copiedList);

        // Beispiel 4: Weiterer Versuch, ein Element in einer for-each Schleife zu entfernen
        // Diese Methode führt zu keinem Fehler, weil wir die Liste nicht während der Iteration manipulieren,
        // sondern eine Kopie der Liste verwenden, um Änderungen vorzunehmen.
        ArrayList<String> newCopiedList = new ArrayList<>(stringList); // Neue Kopie der Liste
        for (String element : stringList) {
            System.out.println(element);
            // Manipulation der kopierten Liste
            if (element.equals("wie gehts dir")) {
                newCopiedList.remove(element); // Wir entfernen das Element aus der Kopie
            }
        }

        // Ausgabe der neuen Listen nach der Manipulation:
        System.out.println("Original-Liste nach der Iteration: " + stringList);
        System.out.println("Kopierte Liste nach der Entfernung: " + newCopiedList);
    }
}
