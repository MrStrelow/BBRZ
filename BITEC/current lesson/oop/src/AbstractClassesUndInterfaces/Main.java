package AbstractClassesUndInterfaces;

import AbstractClassesUndInterfaces.impl.Dreieck;
import static AbstractClassesUndInterfaces.impl.Dreieck.Orientierung.*;

public class Main {
    public static void main(String[] args) {
        System.out.println(new Dreieck(5,5,"~", "#", TOP_LEFT));
    }
}
