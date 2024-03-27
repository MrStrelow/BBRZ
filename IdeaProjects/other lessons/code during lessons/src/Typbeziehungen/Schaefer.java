package Typbeziehungen;

public class Schaefer extends Hund {

    public Schaefer(Integer alter, String name) throws Exception {
        super(alter, name);
    }

    public void hueten(Schaf schaf) {
        System.out.println("Me, " + getName() + " is se Dog, I em " + getAlter() + " alt, and ich huete " + schaf);
    }
}
