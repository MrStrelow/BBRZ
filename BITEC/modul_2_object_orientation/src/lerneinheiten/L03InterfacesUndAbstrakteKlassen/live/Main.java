package lerneinheiten.L03InterfacesUndAbstrakteKlassen.live;

import lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Dreieck;
import lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Orientation;

import static lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Direction.*;
import static lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Orientation.SOUTH;

public class Main {
    public static void main(String[] args) {
        Dreieck triangle = new Dreieck(7, 7, "🌱", "👀", BOT_LEFT);
        System.out.println(triangle);

        Dreieck tria2 = new Dreieck(7, 7, "🌱", "👀", TOP_RIGHT);
        System.out.println(tria2.attach(triangle, SOUTH));

        Dreieck tria3 = new Dreieck(7, 7, "🌱", "👀", BOT_RIGHT);
        System.out.println(tria3);

        Dreieck tria4 = new Dreieck(7, 7, "🌱", "👀", TOP_LEFT);
        System.out.println(tria4);

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
