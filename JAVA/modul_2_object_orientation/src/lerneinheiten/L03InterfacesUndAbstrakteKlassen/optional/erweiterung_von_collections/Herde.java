package lerneinheiten.L05InterfacesUndAbstrakteKlassen.optional.erweiterung_von_collections;

import java.util.ArrayList;

class Herde extends ArrayList<Schaf> implements AgeableCollection {

    public int getTotalAge() {
        int totalAge = 0;

        for (Schaf schaf : this) {
            totalAge += schaf.getAge();
        }

        return totalAge;
    }

    @Override
    public int compareTo(AgeableCollection other) {
        return this.getTotalAge() - other.getTotalAge();
    }
}