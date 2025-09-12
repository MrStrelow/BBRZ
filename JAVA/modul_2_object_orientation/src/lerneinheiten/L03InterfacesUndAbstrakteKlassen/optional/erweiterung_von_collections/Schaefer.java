package lerneinheiten.L05InterfacesUndAbstrakteKlassen.optional.erweiterung_von_collections;

public class Schaefer extends Hund {
    public Schaefer(String name, int age) {
        super(name, age);
    }

    public void hueten(Schaf schaf) {
        System.out.println(getName() + " hütet ein schaf mit der ID: " + schaf.getId());
    }
}