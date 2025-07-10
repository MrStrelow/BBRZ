package lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.schnittstellen;

import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.schnittstellen.implementation.Arrow;
import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.schnittstellen.implementation.Diamant;
import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.schnittstellen.implementation.Dreieck;
import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.schnittstellen.implementation.Form;

import static lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.schnittstellen.implementation.Dreieck.Orientation.*;

public class Main {
    public static void main(String[] args) {
        Dreieck triangle = new Dreieck(5, 5, "~", "#", BOT_LEFT);
//        Dreieck triangle = new Dreieck(5, 5, "~", "#");
        System.out.println(triangle);

        System.out.println(new Dreieck(triangle, TOP_LEFT));
        System.out.println(new Dreieck(triangle, TOP_RIGHT));
        
        System.out.println(new Dreieck(triangle, BOT_RIGHT));

//        Form diamant = new Diamant(triangle.getHoehe() * 2, triangle.getBreite() * 2, triangle.getBackground(), triangle.getFiller());
        Form diamant = new Diamant(triangle, 2);
        System.out.println(diamant);

        Form arrow = new Arrow(triangle.getHoehe() * 2, triangle.getBreite() * 2, triangle.getBackground(), triangle.getFiller(), Arrow.Orientation.DOWN);
        System.out.println(arrow);

        System.out.println(new Arrow(triangle.getHoehe() * 2, triangle.getBreite() * 2, triangle.getBackground(), triangle.getFiller(), Arrow.Orientation.UP));
        System.out.println(new Arrow(triangle.getHoehe() * 2, triangle.getBreite() * 2, triangle.getBackground(), triangle.getFiller(), Arrow.Orientation.LEFT));
        System.out.println(new Arrow(triangle.getHoehe() * 2, triangle.getBreite() * 2, triangle.getBackground(), triangle.getFiller(), Arrow.Orientation.RIGHT));
    }
}