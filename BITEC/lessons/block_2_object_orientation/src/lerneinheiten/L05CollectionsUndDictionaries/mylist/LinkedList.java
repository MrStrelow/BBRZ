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
//            Node nachbar = head.getNachbar();
//
//            while (nachbar != null) {
//                nachbar = nachbar.getNachbar();
//            }
//
//            nachbar=node;

            Node current = head;

            while (current.getNachbar() != null) {
                current = current.getNachbar();
            }

            current.setNachbar(node);
        }
    }

    public int removeAt(int position) {
        if (head == null) {
            head = node;

        } else {
            Node current = head;

            while (current.getNachbar() != null) {
                current = current.getNachbar();
            }

            current.setNachbar(node);
        }
    }

    public int remove(int element) { // fehler? :( aber warum?
        return element;
        // TODO: implemente me b)
    }


    public void contains() {
        // TODO: implemente me c)
    }

    public void find() {

    }

    public void get() {

    }

    public void display() {
        Node current = head;
        while (current.getNachbar() != null) {
            current = current.getNachbar();
            System.out.print("(" + current.getValue() + ") --> ");
        }
        System.out.println("null");
    }
}
