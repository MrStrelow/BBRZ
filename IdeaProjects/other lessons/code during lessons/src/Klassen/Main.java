package Klassen;

import javax.swing.text.html.HTML;
import java.util.Random;

public class Main {
    public static void main(String[] args) {
        Hund gilbert = new Hund(5, .8);
        Tagesablauf tagesablauf = new Tagesablauf(gilbert);

        gilbert.schlafen();
        tagesablauf.postWirdGebracht();
    }
}


//        Hund[] myHunde = {gilbert, gilbert};
//
//        String[] myArray = new String[8];
//        Random randomObject = new Random();
//        randomObject.nextInt();
//
//        Math.random();
//        Integer.parseInt();
