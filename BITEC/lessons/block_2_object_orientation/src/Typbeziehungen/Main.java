package Typbeziehungen;

import java.util.*;

public class Main {
    public static void main(String[] args) throws Exception {

        // [x] ein Hund ist zu alt
        // [] ein huetet zu viel exception

        // []



        try {

            Hund dog = new Hund(10, "welp");

        } catch (ZuAltException alt) {

            System.out.println("Oida, " + alt.getMessage());
            // schreibe in seniorenschutz datenbank
            System.out.println("meldung an seniorenschutz abgesendet.");

        } catch (ZuJungException jung) {

            System.out.println("Deppata, " + jung.getMessage());
            // schreibe in seniorenschutz datenbank
            System.out.println("meldung an jugendschutz abgesendet.");

        } catch (Exception e) {
            throw new RuntimeException(e);
        } finally {
            System.out.println("das im finally block wird gemacht egal ob ein fehler passiert oder nicht.");
        }

        System.out.println("HIER BEGINNT DIE ERSTELLUNG DER HORDE!");

        Horde goDoggo = new Horde((int) Math.pow(10, 2));
        Horde goDuggo = new Horde((int) Math.pow(10, 2));

        // implments comparable
        if( goDoggo.compareTo(goDuggo) > 0 ) {
            System.out.println("goDoggo ist mächtiger.");

        } else if ( goDoggo.compareTo(goDuggo) < 0 ) {
            System.out.println("goDoggo ist schwächer.");

        } else {
            System.out.println("horden sind gleich mächtig.");
        }

        System.out.println(goDoggo.isEmpty());

        Hund frido = new Hund(5,"frido");
        Hund frodo = new Hund(5,"frodo");
        System.out.println(frodo.equals(frido));

        System.out.println("#####################");

        System.out.println(goDoggo.size());
        Hund finder = new Hund(5, "finder");
        goDoggo.add(finder);
        System.out.println(goDoggo.size());
        goDoggo.remove(finder);
        System.out.println(goDoggo.size());


        // wir verwenden jetzt eine Liste von Hunden
        List<Hund> huerde = new ArrayList<>();
        System.out.println(huerde);
        huerde.add(new Hund(5,"BERT"));

        Hund wert = new Hund(3,"WERT");
        huerde.add(wert);

        Hund mert = new Hund(3,"MERT");
        huerde.add(mert);

        huerde.add(new Hund(3,"LERT"));

        System.out.println(huerde);

//        huerde.remove(0);
//        huerde.remove(huerde.size()-1);
//        huerde.remove(mert);

        Hund lastHundStanding = huerde.get(0);

        System.out.println(lastHundStanding == wert);
        System.out.println(lastHundStanding.equals(wert));

        System.out.println(huerde);

        System.out.println("#################################");

//        String[] asdf = {"sadf", "ww"};
//        List<String> afd = List.of(asdf);

        List<String> a = new ArrayList<>(Arrays.asList("a", "b"));
        List<String> b = new ArrayList<>(a); // hier wurde bereits ein copy konstruktor implementiert
        List<String> c = a;

        System.out.println(a);
        System.out.println(b);
        System.out.println(c);

        a.remove("a");

        System.out.println(a);
        System.out.println(b);
        System.out.println(c);

        System.out.println(a.hashCode());
        System.out.println(b.hashCode());
        System.out.println(c.hashCode());

        System.out.println(a == b);
        System.out.println(a == c);

        // for schleife für listen (bzw. collections - aber im prinzip auch arrays!)
        for (Hund h : huerde) {
            System.out.println(h);
        }

        // entferne elemente in der loop
        // das geht leider nicht
//        for (Hund h : huerde) {
//            huerde.remove(h);
//            System.out.println(huerde);
//        }

        // Variante 1 - keine for each verwenden (iteratoren sind das problem, die gibts hier nicht)
//        for (int i = 0; i < huerde.size(); ) {
//            System.out.println(huerde.size());
//            huerde.remove(0);
//        }
//        System.out.println(huerde);

//        int size = huerde.size();
//        for (int i = 0; i < size; i++) {
//            System.out.println(size);
//            huerde.remove(0);
//        }
//        System.out.println(huerde);

        List<Hund> hilfsHuerde = new ArrayList<>(huerde);
        for (Hund h : hilfsHuerde) {
            huerde.remove(h);
            System.out.println(h.hashCode());
//            System.out.println(huerde);
        }

        // wir verwenden jetzt eine Map von Hunden

        Map<Hund, Hund> dogMap = new HashMap<>();
        dogMap.put(wert, mert);
        dogMap.put(mert, wert);

        System.out.println(dogMap.get(mert));
        System.out.println(dogMap.get(wert));

        for (Hund h : huerde) {
            System.out.println(dogMap.get(h));
        }

        // for schleife für map (bzw. collections - aber im prinzip auch arrays!)

        for (Map.Entry<Hund, Hund> entry : dogMap.entrySet()) {
            System.out.println(entry.getKey());
            System.out.println(entry.getValue());
            System.out.println("++++");
        }

        for (Hund h : dogMap.keySet()) {
            System.out.println(h);
            System.out.println(dogMap.get(h));
            System.out.println("++++");
        }

        for (Hund h : dogMap.values()) {
            System.out.println(h);
            System.out.println("keys können wir nicht finden anhand des values!");
            System.out.println("++++");
        }

//        Hund sad = null;
//        System.out.println(sad);
//
//        ArrayList<Hund> asdf = new ArrayList<>();
//        System.out.println(asdf);
//        asdf.add(null);
//        System.out.println(asdf);
//        System.out.println(asdf.isEmpty());


//        // implements Collection
//        goDoggo.add();
//        goDoggo.remove(10);
//        goDoggo.remove(dog);
//
//        for(Hund dog : goDoggo) {
//
//        }

//        Hund frido = new Hund(5,"frido");
//        Hund frodo = new Hund(5,"frido");
//        System.out.println(frido.equals(frodo));
//
//        String sfrido = new String("frido");
//        String sfrodo = new String("frido");
//        System.out.println(sfrido.equals(sfrodo));
//        System.out.println(sfrido == sfrodo);
//        sfrido = sfrodo;
//        System.out.println(sfrido == sfrodo);

        Herde goJeep = new Herde((int) Math.pow(10, 4));

//        goDoggo.huetet(goJeep);
//        goJeep.wirdGehuetet(goDoggo);
    }
}
