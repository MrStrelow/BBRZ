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
    }
}