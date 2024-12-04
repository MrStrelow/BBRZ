package AbstractClassesUndInterfaces.schnittstellen;

import AbstractClassesUndInterfaces.abstractClass.impl.Dreieck;
import AbstractClassesUndInterfaces.schnittstellen.interfaces.Kombinierbar;

import static AbstractClassesUndInterfaces.abstractClass.impl.Dreieck.Orientierung.BOT_RIGHT;

public class Main {
    public static void main(String[] args) {
        System.out.println(new Dreieck(5,5,"~", "#", BOT_RIGHT));
    }
}
