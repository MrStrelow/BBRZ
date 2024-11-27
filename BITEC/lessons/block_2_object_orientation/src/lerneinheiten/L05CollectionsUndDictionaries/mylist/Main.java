package lerneinheiten.L05CollectionsUndDictionaries.mylist;

public class Main {
    public static void main(String[] args) {
        // Erstelle Nodes (Objekte) welche auch dessen Wert setzten.
        Node firstNode = new Node(3);
        Node secondNode = new Node(4);
        Node thirdNode = new Node(5);

        // Setze die Nachbarn!
        firstNode.setNachbar(secondNode);
        secondNode.setNachbar(thirdNode);
//        thirdNode.setNachbar(firstNode);

        // lösche second node aus der Liste
        firstNode.setNachbar(thirdNode);
        secondNode = null;


        // vs.
        LinkedList myList = new LinkedList();
        myList.add(3);
        myList.add(4);
        myList.add(5);
        myList.add(6);
        myList.add(7);
        myList.add(8);
        myList.display();

        myList.removeAt(3);
//        myList.removeAt(0);
//        myList.removeAt(-1);
//        myList.removeAt(10);
//        myList.removeAt(3);
        myList.display();
    }
}
