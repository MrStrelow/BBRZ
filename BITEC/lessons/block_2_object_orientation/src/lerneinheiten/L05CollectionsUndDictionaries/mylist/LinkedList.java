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
        // guard 1
        if (head == null) {
            System.out.println("Fehler! Die Liste ist leer.");
            return -1;
        }

        // guard 2
        if (position < 0) {
            System.out.println("Fehler! Die angegebene Position ist negativ (" + position + "). Muss positiv sein.");
            return -2;
        }

        // logik
        if (position == 0) {
            int ret = head.getValue();
            head = head.getNachbar();
            return ret;

        } else {
            Node current = head;
            int index = 0;

            while (index < position) { // current.getNachbar() != null
                current = current.getNachbar();
                index++;
            }

            if (current.getNachbar() == null) {
                System.out.println("Fehler! Out of Bounds Exception!");
                return -3;
            }

            int ret = current.getNachbar().getValue();
            current.setNachbar(current.getNachbar().getNachbar());

            return ret;
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
            System.out.print("(" + current.getValue() + ") --> ");
            current = current.getNachbar();
        }
        System.out.print("(" + current.getValue() + ") --> null");
//        System.out.println("null");
    }
}
