package AbstractClassesUndInterfaces.schnittstellen;

import AbstractClassesUndInterfaces.schnittstellen.impl.Diamant;
import AbstractClassesUndInterfaces.schnittstellen.impl.Dreieck;

import static AbstractClassesUndInterfaces.schnittstellen.impl.Dreieck.Orientierung.BOT_RIGHT;

public class Main {
    public static void main(String[] args) {
        System.out.println(new Dreieck(5,5,"~", "#", BOT_RIGHT));
        System.out.println(new Diamant(5,5,"~", "#"));
    }
}
