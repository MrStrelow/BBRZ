package lerneinheiten.L03InterfacesUndAbstrakteKlassen.live;

import lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Dreieck;
import lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Orientation;

import static lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Direction.*;
import static lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Orientation.SOUTH;
import static lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Orientation.WEST;

public class Main {
    public static void main(String[] args) {
        Dreieck topRight = new Dreieck(7, 7, "⬜", "🌱", TOP_RIGHT);
        System.out.println(topRight);

        Dreieck botRight = new Dreieck(7, 7, "⬜", "🌱", BOT_RIGHT);
        System.out.println(botRight);

        Dreieck botLeft = new Dreieck(7, 7, "⬜", "🌱", BOT_LEFT);
        System.out.println(botLeft);

        Dreieck topLeft = new Dreieck(7, 7, "⬜", "🌱", TOP_LEFT);
        System.out.println(topLeft);

        System.out.println(topRight.attach(topLeft, WEST));

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
