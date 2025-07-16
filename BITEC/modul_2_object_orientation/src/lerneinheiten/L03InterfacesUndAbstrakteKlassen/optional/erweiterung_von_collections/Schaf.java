package lerneinheiten.L05InterfacesUndAbstrakteKlassen.optional.erweiterung_von_collections;

public class Schaf implements Ageable {
    private String id;
    private int age;

    public Schaf(String id, int age) {
        this.id = id;
        this.age = age;
    }

    public String getId() {
        return id;
    }

    @Override
    public int getAge() {
        return age;
    }
}