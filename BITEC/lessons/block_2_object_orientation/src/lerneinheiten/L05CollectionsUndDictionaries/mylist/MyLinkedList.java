package lerneinheiten.L05CollectionsUndDictionaries.mylist;

public class MyLinkedList<Typ> {
    // Felder
    // ??

    // Hat-Beziehungen
    private MyNode<Typ> head;

    // Konstruktor
    // ??

    // Methoden
    public void add(Typ value) {
        MyNode<Typ> myNode = new MyNode<>(value);

        if (head == null) {
            head = myNode;

        } else {
            // Sieht wer einen Fehler hier?
//            Node nachbar = head.getNachbar();
//
//            while (nachbar != null) {
//                nachbar = nachbar.getNachbar();
//            }
//
//            nachbar=node;

            MyNode<Typ> current = head;

            while (current.getNachbar() != null) {
                current = current.getNachbar();
            }

            current.setNachbar(myNode);
        }
    }

    public Typ removeAt(int position) {
        // guard 1
        if (head == null) {
            System.out.println("Fehler! Die Liste ist leer.");
            return null;
        }

        // guard 2
        if (position < 0) {
            System.out.println("Fehler! Die angegebene Position ist negativ (" + position + "). Muss positiv sein.");
            return null;
        }

        // logik
        if (position == 0) {
            Typ ret = head.getValue();
            head = head.getNachbar();
            return ret;

        } else {
            MyNode<Typ> current = head;
            int index = 1;

            while (index < position) { // current.getNachbar() != null
                current = current.getNachbar();
                index++;
            }

            if (current.getNachbar() == null) {
                System.out.println("Fehler! Out of Bounds Exception!");
                return null;
            }

            Typ ret = current.getNachbar().getValue();
            current.setNachbar(current.getNachbar().getNachbar());

            return ret;
        }
    }

    public int removeElement(int element) { // fehler? :( aber warum?
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
        MyNode current = head;

        while (current != null) {
            System.out.print("(" + current.getValue() + ") --> ");
            current = current.getNachbar(); // das hier ist eine Art "i++;"
        }
        System.out.println("null");

        // TODO: Warum geben wir hier nicht alles aus?
//        while (current.getNachbar() != null) {
//            System.out.print("(" + current.getValue() + ") --> ");
//            current = current.getNachbar();
//        }
//        System.out.println("null");

        // TODO: Warum funktioniert das hier wieder?
//        while (current.getNachbar() != null) {
//            System.out.print("(" + current.getValue() + ") --> ");
//            current = current.getNachbar();
//        }
//        System.out.println("(" + current.getValue() + ") --> null");
    }
}
