package lerneinheiten.L05InterfacesUndAbstrakteKlassen.optional.erweiterung_von_collections;

public class Hund implements Ageable {
    private int age;
    private String name;

    public Hund(String name, int age) {
        this.name = name;
        this.age = age;
    }

    @Override
    public int getAge() {
        return age;
    }

    public String getName() {
        return name;
    }
}
