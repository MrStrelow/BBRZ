package lerneinheiten.L05CollectionsUndDictionaries.horde;

import java.util.*;
import java.util.function.Consumer;
import java.util.function.IntFunction;
import java.util.function.Predicate;
import java.util.stream.Stream;

public class Horde implements Comparable<Horde>, Collection<Hund> {
    // ####################### hier sind die Attribute #######################
    private Integer size;
    private Hund[] hunde;

    // ####################### hier sind die Konstruktoren #######################
    public Horde(Integer size) {
        this.size = size;
        this.hunde = new Hund[size];
        Random random = new Random();

        int j = 0;

        for (int i = 0; i < size; i++) {
            Integer alter = random.nextInt(3, 6);

            char zufallsName = (char) random.nextInt(97, 97 + 26);
            String name = Character.toString(zufallsName);

            try {

                hunde[i] = new Hund(alter, name);

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
            }

        }
    }

    // ####################### hier sind eigenen Methodne der Horde #######################
    public void huetet(Herde schafe) {
//        for (int i_hund = 0; i_hund < size; i_hund++) {
//            for (int i_schaf = 0; i_schaf < schafe.getSize(); i_schaf++) {
        for (Hund hund : hunde) {
            for (Schaf schaf : schafe.getSchafe()) {
                hund.hueten(schaf);
            }
        }
    }

    public String printName() {
        String ausgabe = "";

//        for (int i = 0; i < size; i++) {
//            ausgabe += hund[i].getName() + "\n";
//        }
        for (Hund hund : hunde) {
            ausgabe +=  hund.getName() + "\n";
        }

        ausgabe += "Die Horde hat die groesse " + size;

        return ausgabe;
    }

    // ####################### hier sind die Methoden von Comparable #######################
    public int compareTo(Horde horde) {

        // speichere das alter der gesamten horde
        Integer alterDerHorde = 0;
        Integer alterDerAnderenHorde = 0;

        // rechne alter aller hunde aus
        for (Hund hund : this.hunde) {
            // rechne alter eines hundes aus
            alterDerHorde += hund.getAlter();
        }

        // rechne alter aller hunde aus
        for (Hund hund : horde.hunde) {
            // rechne alter eines hundes aus
            alterDerAnderenHorde += hund.getAlter();
        }

        return -(alterDerHorde - alterDerAnderenHorde);
    }

    // ####################### hier sind die Methoden von Collection #######################
    public int size() {
        // gehen wir die hunde durch und zaehlen die elemente was nicht null sind.
        int size = 0;

        for (Hund hund : hunde) {
            if(hund != null) {
                size++;
            }
        }

        this.size = size; //ACHTUNG! nur wenn size aufgerufen wird, dann ist auch das Attribut size richtig!
        return size;
    }


    public boolean isEmpty() {
        for (Hund hund : hunde) {
            if(hund != null) {
                return false;
            }
        }

        return true;
    }


    public boolean contains(Object o) {
        if (o == null) {
            return false;
        }

        if (!(o instanceof Hund)) {
            return false;
        }

        Hund hund = (Hund) o;

        int index = find(hund);

        if(index == -1) {
            return false;
        }

        return true;

//        return index == -1 ? false : true;
    }


    public Iterator<Hund> iterator() {
        return null;
    }

    @Override
    public void forEach(Consumer<? super Hund> action) {
        Collection.super.forEach(action);
    }

    @Override
    public Object[] toArray() {
        return new Object[0];
    }

    @Override
    public <T> T[] toArray(T[] a) {
        return null;
    }

    @Override
    public <T> T[] toArray(IntFunction<T[]> generator) {
        return Collection.super.toArray(generator);
    }


    public boolean add(Hund hund) {
        // hat das array überhaupt noch platz?
        boolean platzVorhanden = this.size() != hunde.length;

        if(platzVorhanden) {
            //suche leeren platz und füge element ein.
            for (int i = 0; i < hunde.length; i++) {
                if( hunde[i] == null ) {
                    hunde[i] = hund;
                    return true;
                }
            }

            return false;

        } else {
            // lege neues array mit doppelter groesse an
            Hund[] biggerBetter = new Hund[hunde.length * 2];

            // altes array in neues reinschreiben
            for (int i = 0; i < hunde.length; i++) {
                biggerBetter[i] = hunde[i];
            }

            // neues element einfuegen
            biggerBetter[hunde.length] = hund;

            // neues array in der horde speichern!
            // also altes hunde array überschreiben mit neuem!
            hunde = biggerBetter;

            return true;
        }
    }


    public boolean remove(Object o) {
        if (o == null) {
            return false;
        }

        if (!(o instanceof Hund)) {
            return false;
        }

        Hund hund = (Hund) o;
        int index = find(hund);

        if(index == -1) {
            return false;
        }

        // die business logic

        hunde[index] = null;
        return true;
    }

    private int find(Hund hund) {
        // array durchgehen und abfragen, ob es gleich ist, also suche es.
        for (int i = 0; i < hunde.length; i++) {
            if(hunde[i] != null) {
                if (hunde[i].equals(hund)) {
                    return i;
                }
            }
        }

        return -1;
    }

    @Override
    public boolean containsAll(Collection<?> c) {
        return false;
    }

    @Override
    public boolean addAll(Collection<? extends Hund> c) {
        return false;
    }

    @Override
    public boolean removeAll(Collection<?> c) {
        return false;
    }

    @Override
    public boolean removeIf(Predicate<? super Hund> filter) {
        return Collection.super.removeIf(filter);
    }

    @Override
    public boolean retainAll(Collection<?> c) {
        return false;
    }

    @Override
    public void clear() {

    }

    @Override
    public Spliterator<Hund> spliterator() {
        return Collection.super.spliterator();
    }

    @Override
    public Stream<Hund> stream() {
        return Collection.super.stream();
    }

    @Override
    public Stream<Hund> parallelStream() {
        return Collection.super.parallelStream();
    }

    // hier sind die getter und setter
    public Integer getSize() {
        return size;
    }

    public void setSize(Integer size) {
        this.size = size;
    }

    public Hund[] getHunde() {
        return hunde;
    }

    public void setHunde(Hund[] hunde) {
        this.hunde = hunde;
    }
}
