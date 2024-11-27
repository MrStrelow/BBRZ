package lerneinheiten.L05CollectionsUndDictionaries.mylist;

public class LinkedList {
    // Felder
    // ??

    // Hat-Beziehungen
    private Node head;

    // Konstruktor
    // ??

    // Methoden
    public void add(int value) {
        Node node = new Node(value);

        if (head == null) {
            head = node;

        } else {
            // Sieht wer einen Fehler hier?
            Node nachbar = head.getNachbar();

            while (nachbar != null) {
                nachbar = nachbar.getNachbar();
            }

            nachbar = node;
        }
    }

    public void remove() {

    }

    public void contains() {

    }

    public void find() {

    }

    public void get() {

    }

    public void display() {
        Node current = head;
        while (current != null) {
            System.out.print(current.getValue() + " -> ");
            current = current.getNachbar();
        }
        System.out.println("null");
    }
}
