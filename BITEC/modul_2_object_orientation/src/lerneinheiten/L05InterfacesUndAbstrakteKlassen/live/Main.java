package lerneinheiten.L05InterfacesUndAbstrakteKlassen.live;

import lerneinheiten.L05InterfacesUndAbstrakteKlassen.live.klassen.Dreieck;
import lerneinheiten.L05InterfacesUndAbstrakteKlassen.live.klassen.Form;
import static lerneinheiten.L05InterfacesUndAbstrakteKlassen.live.klassen.Direction.*;

public class Main {
    public static void main(String[] args) {
        Dreieck triangle = new Dreieck(7, 7, "🌱", "👀", BOT_LEFT);

//        Diamant diamiant = new Diamant(triangle);
//        Diamant diamant = new Diamant(10, 10, "⬜", "👀");
//
//        ArrayList<Form> box = new ArrayList<>();
//        box.add(diamiant);
//        box.add(triangle);
//
//        for (Form form : box) {
//            System.out.println(form);
//        }
    }
}
