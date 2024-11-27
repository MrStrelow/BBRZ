package lerneinheiten.L05CollectionsUndDictionaries.mylist;

public class Node {
    // Feld
    private int value;

    // Hat-Beziehungen
    private Node nachbar;

    // Konstruktor
    public Node(int value) {
        this.value = value;
    }

    // Methoden
    // get-set Methoden
    public int getValue() {
        return value;
    }

    public Node getNachbar() {
        return nachbar;
    }

    public void setNachbar(Node nachbar) {
        this.nachbar = nachbar;
    }
}
