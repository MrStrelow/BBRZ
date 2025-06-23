//package lerneinheiten.L02KlassenUndMethoden.hamster;
//
//public class Main {
//    public static void main(String[] args) throws InterruptedException {
//        Spielfeld spielfeld = new Spielfeld(5);
//
//        while (true) {
//            spielfeld.simulateHamster();
//            spielfeld.simulateSamen();
//
//            spielfeld.printSpielfeld();
//
//            System.out.println("+++++++++++++++++++++++++++++++");
//            Thread.sleep(1000);
//        }
//    }
//}
//

public class Main {
    public static void main(String[] args) {
        String nichtKombinierbar = "null|eins|zehn|elf|zwölf";
        String ersterTeilDreizehnBisNeunZehn = "drei|vier|fünf|acht|neun";
        String zweiterTeilDreihzehnBisNeunzehn = "sech|sieb";
        String dreizehnBisNeunzehn = ersterTeilDreizehnBisNeunZehn + "|" + zweiterTeilDreihzehnBisNeunzehn;
        String einerStellenOhneEins = "zwei|" + ersterTeilDreizehnBisNeunZehn + "|sechs|sieben";
        String basisFuerZehnerStellen = "ein|" + einerStellenOhneEins;
        String dreizehnBisNeunZehn = "(" + dreizehnBisNeunzehn + ")-zehn";
        String zehnerStellen = "zwanzig|dreißig|vierzig|fünfzig|sechzig|siebzig|achtzig|neunzig";
        String zehnerStellenAlsZahl = "20|30|40|50|60|70|80|90";
        String kombinierterRest = "(" + basisFuerZehnerStellen + ")-und-(" + zehnerStellen + ")";
        String hundert = "ein-hundert";

        String pattern =
                "^" +
                    hundert + "|" +
                    "(" + zehnerStellen + ")|" +
                    "(" + kombinierterRest + ")|" +
                    "(" + dreizehnBisNeunZehn + ")|" +
                    "(" + einerStellenOhneEins + ")|" +
                    "(" + nichtKombinierbar + ")" +
                "$";

        System.out.println(pattern);
    }
}
