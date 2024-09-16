package Klassen3;

public class MedizinderIn extends Personal {
    // --------------------- Attribute ---------------------
    private String titel;
    private String[] kenntnisse;

    // --------------------- Konstruktor ---------------------
    MedizinderIn(Integer alter, String name, String titel, String[] kenntnisse) {
        super(alter, name); // das ist der Konstruktor des Personals
        this.titel = titel;
        this.kenntnisse = kenntnisse;
    }

    // --------------------- Methoden ---------------------
    public void einschlaefern(Tiere tier) {
        if (tier.getAggressiv()) {

            tier.setAmLeben(false);

        } else {

            System.out.println("Ein nicht aggressives Tier darf nicht eingschläfert werden.");

        }
    }

    public void kastrieren(Tiere tier) {
        if (tier.getAggressiv()) {

            tier.setKastriert(true);

        } else {

            System.out.println("Ein nicht aggressives Tier darf nicht kastriert werden.");

        }
    }

    public void behandeln(Tiere tier) {
        if (tier.getAggressiv() && !tier.getKastriert()) {

            this.kastrieren(tier);

        } else if (tier.getAggressiv() && tier.getKastriert()) {

            this.einschlaefern(tier);

        } else {

            System.out.println("Eingriff nicht erforderlich!");

        }
    }

    // --------------------- Get-Set-Methoden ---------------------
    public String getTitel() {
        return titel;
    }

    public void setTitel(String titel) {
        this.titel = titel;
    }

    public String[] getKenntnisse() {
        return kenntnisse;
    }

    public void setKenntnisse(String[] kenntnisse) {
        this.kenntnisse = kenntnisse;
    }
}
