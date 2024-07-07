package Klassen3;

public class Main {
    public static void main(String[] args) {
//        String[] kenntnisse = new String[2];
//        kenntnisse[0] = "alles";
//        kenntnisse[1] = "nichts";
        String[] kenntnisse = {"alles", "nichts"};

//        Personal asdf = new Personal();
        Personal otto = new MedizinderIn(65, "Otto Mayr", "Dr.Mad.", kenntnisse);
        MedizinderIn anna = new MedizinderIn(63, "Anna Hannah", "Dr.Med.", kenntnisse);
        Tiere glibert = new Tiere(1, 5, false);

//        ((MedizinderIn) otto).kastrieren(glibert);
//        otto.kastrieren(); // :(


        System.out.println(glibert.getKastriert());
        System.out.println(glibert.getAmLeben());
        anna.behandeln(glibert);

        System.out.println(glibert.getKastriert());
        anna.behandeln(glibert);
        System.out.println(glibert.getAmLeben());

        glibert.setAmLeben(true);
        glibert.setAggressiv(false);

        anna.kastrieren(glibert);
        anna.einschlaefern(glibert);
    }
}
