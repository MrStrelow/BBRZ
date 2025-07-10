package lerneinheiten.L05InterfacesUndAbstrakteKlassen.optional.erweiterung_von_collections;

public interface AgeableCollection extends Comparable<AgeableCollection> {
    int getTotalAge();
}