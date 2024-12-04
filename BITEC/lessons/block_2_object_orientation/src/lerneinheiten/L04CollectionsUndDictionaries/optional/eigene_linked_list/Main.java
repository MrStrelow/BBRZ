package lerneinheiten.L04CollectionsUndDictionaries.optional.eigene_linked_list;

public class Main {
    public static void main(String[] args) {
        // Erstelle Nodes (Objekte) welche auch dessen Wert setzten.
        MyNode<Integer> firstMyNode = new MyNode<>(3);
        MyNode<Integer> secondMyNode = new MyNode<>(4);
        MyNode<Integer> thirdMyNode = new MyNode<>(5);

        // Setze die Nachbarn!
        firstMyNode.setNachbar(secondMyNode);
        secondMyNode.setNachbar(thirdMyNode);
//        thirdNode.setNachbar(firstNode);

        // lösche second node aus der Liste
        firstMyNode.setNachbar(thirdMyNode);
        secondMyNode = null;


        // vs.
        MyLinkedList<Integer> myList = new MyLinkedList<>();
        myList.add(3);
        myList.add(4);
        myList.add(5);
        myList.add(6);
        myList.add(7);
        myList.add(8);
        myList.display();

        myList.removeAt(3);
        myList.removeAt(0);
        myList.removeAt(-1);
        myList.removeAt(4); // TODO: null pointer
//        myList.removeAt(3);
        myList.display();

        MyLinkedList<String> myStringList = new MyLinkedList<>();
        myStringList.add("3");
        myStringList.add("4");
        myStringList.add("5");
        myStringList.add("6");
        myStringList.add("7");
        myStringList.add("8");
        myStringList.display();

        myList.removeAt(3);
        myList.removeAt(0);
        myList.removeAt(-1);
        myList.removeAt(4); // TODO: null pointer
//        myList.removeAt(3);
        myList.display();
    }
}
