package AbstractClassesUndInterfaces.abstractClass;

import AbstractClassesUndInterfaces.abstractClass.impl.Dreieck;
import static AbstractClassesUndInterfaces.abstractClass.impl.Dreieck.Orientierung.*;

public class Main {
    public static void main(String[] args) {
        System.out.println(new Dreieck(5,5,"~", "#", BOT_RIGHT));
    }
}
