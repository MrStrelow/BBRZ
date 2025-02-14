package lerneinheiten.L05InterfacesUndAbstrakteKlassen.erweiterung_von_collections;

public interface AgeableCollection extends Comparable<AgeableCollection> {
    int getTotalAge();
}