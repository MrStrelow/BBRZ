package lerneinheiten.L05CollectionsUndDictionaries.typbeziehungen;

import java.util.*;

public class temp {
    public static void main(String[] args) {
        String[] myArray = new String[2];
        myArray[0] = "s";
        String ergebnis = myArray[0];

        // List:
        ArrayList<String> stringList = new ArrayList<>();
        // CRUD
        // (C)reate
        stringList.add("hallo");
        stringList.add("du");
        System.out.println("Create: " + stringList);

        stringList.add(1, "Hallo");
        System.out.println("Create: " + stringList);

        // (R)ead
        String result = stringList.get(0);
        System.out.println("Read: " + result);

        // (U)pdate
        stringList.set(1, "wie gehts dir");
        System.out.println("Update: " + stringList);

        // (D)elete
        boolean worked = stringList.remove("ik");
        System.out.println("Delete: " + stringList);
        System.out.println(worked);

        worked = stringList.remove("hello");
        System.out.println(worked);

        System.out.println("Delete: " + stringList);

        String removed = stringList.remove(0);
        System.out.println(removed);

        new LinkedList<String>().addLast("a");
        new LinkedList<String>().addFirst("a");
//        new ArrayList<String>().addFirst("a");
//        new ArrayList<String>().addLast("a");

        Iterator<String> iterator = stringList.iterator();

        while (iterator.hasNext()) {
            System.out.println(iterator.next());
        }

        for (String element : stringList) {
            System.out.println(element);
        }

        ArrayList<String> copiedList = new ArrayList<>(stringList);
        for (String element : stringList) {
//            System.out.println(element);
            copiedList.add(element);
        }

        System.out.println(stringList);
        System.out.println(copiedList);

        for (int i = 0; i < stringList.size(); i++) {
            String element = stringList.get(i);

//            System.out.println(element);
        }

//        stringList.addLast("a");

        // Map:
        HashMap<String, String> myMap = new HashMap<>();
        HashMap<String, List<String>> myMapWithLists = new HashMap<>();
        // CRUD
        // (C)reate
        myMap.put("myKey300", "myData4000");
        myMap.put("myKey300", "myData3000");

        List<String> entry = new ArrayList<>();
        entry.add("sugar");
        entry.add("eiweiß");
        myMapWithLists.put("cola", entry);

        // (R)ead
        System.out.println(myMap.get("myKey300"));

        // (U)pdate
        System.out.println(myMap.replace("myKey400", "someData"));
        System.out.println(myMap.replace("myKey300", "someData"));
        System.out.println(myMap);

        // (D)elete
//        myMap.remove("myKey300");
//        System.out.println(myMap);

        for (String element : myMap.keySet()) {
            System.out.println(element);
        }

        for (String element : myMap.values()) {
            System.out.println(element);
        }

        for (Map.Entry<String, String> element: myMap.entrySet()) {
            System.out.println(element.getKey());
            System.out.println(element.getValue());
        }
    }
}
