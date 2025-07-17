package lerneinheiten.L03InterfacesUndAbstrakteKlassen.live;

import lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Arrow;
import lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Diamant;
import lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Dreieck;
import lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Form;

import static lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Direction.*;
import static lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Orientation.*;

public class Main {
    public static void main(String[] args) {
//        Dreieck topRight = new Dreieck(7, 7, "⬜", "🌱", TOP_RIGHT);
//        System.out.println(topRight);
//
//        Dreieck botRight = new Dreieck(7, 7, "⬜", "🌱", BOT_RIGHT);
//        System.out.println(botRight);
//
//        Dreieck botLeft = new Dreieck(7, 7, "⬜", "🌱", BOT_LEFT);
//        System.out.println(botLeft);
//
//        Dreieck topLeft = new Dreieck(7, 7, "⬜", "🌱", TOP_LEFT);
//        System.out.println(topLeft);
//
//        Form komischeForm = topRight.attach(topLeft, WEST);
//        System.out.println(komischeForm);

//        Diamant diamiant = new Diamant(triangle);
        Diamant diamant = new Diamant(10, 10, "⬜", "🌱");
        System.out.println(diamant);

        Arrow arrow = new Arrow(10, 10, "🥲", "😡", WEST);
        System.out.println(arrow);

//        ArrayList<Form> box = new ArrayList<>();
//        box.add(diamiant);
//        box.add(triangle);
//
//        for (Form form : box) {
//            System.out.println(form);
//        }
    }
}
