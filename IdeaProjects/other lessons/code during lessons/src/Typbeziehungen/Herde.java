package Typbeziehungen;

import java.util.Random;

public class Herde {
    private Integer size;
    private Schaf[] schafe;

    public Herde(Integer size) {
        this.size = size;
        this.schafe = new Schaf[size];
        Random random = new Random();

        for (int i = 0; i < size; i++) {
            char zufallsName = (char) random.nextInt(97, 97 + 26);
            String name = Character.toString(zufallsName);

            schafe[i] = new Schaf(name);
        }
    }

    public void wirdGehuetet(Horde hunde) {
//        for (int i_hund = 0; i_hund < size; i_hund++) {
//            for (int i_schaf = 0; i_schaf < schafe.getSize(); i_schaf++) {
        for (Schaf schaf : schafe) {
            for (Hund hund : hunde.getHunde()) {
                schaf.wirdGehuetet(hund);
            }
        }
    }

    public String printName() {
        String ausgabe = "";

        for (Schaf schaf : schafe) {
            ausgabe += schaf.getName() + "\n";
        }

        return ausgabe;
    }

    public Integer getSize() {
        return size;
    }

    public void setSize(Integer size) {
        this.size = size;
    }

    public Schaf[] getSchafe() {
        return schafe;
    }

    public void setSchafe(Schaf[] schaf) {
        this.schafe = schaf;
    }
}
