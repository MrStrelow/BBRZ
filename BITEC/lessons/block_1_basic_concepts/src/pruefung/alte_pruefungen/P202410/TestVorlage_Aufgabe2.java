package pruefung.alte_pruefungen.P202410;

public class TestVorlage_Aufgabe2 {
    public static final String ANSI_RESET = "\u001B[0m";
    public static final String ANSI_BLACK = "\u001B[30m";
    public static final String ANSI_RED = "\u001B[31m";
    public static final String ANSI_GREEN = "\u001B[32m";
    public static final String ANSI_YELLOW = "\u001B[33m";
    public static final String ANSI_BLUE = "\u001B[34m";
    public static final String ANSI_PURPLE = "\u001B[35m";
    public static final String ANSI_CYAN = "\u001B[36m";
    public static final String ANSI_WHITE = "\u001B[37m";

    public static void main(String[] args) {

        String[] neutralerPostfix = {
                ANSI_YELLOW + "es tut was es soll." + ANSI_RESET,
                ANSI_YELLOW + "meistens gehts gut, aber nicht immer." + ANSI_RESET,
                ANSI_YELLOW + "ich habe meine Erwartungen gesenkt und diese wurden übertroffen, aber um nicht viel." + ANSI_RESET,
                ANSI_YELLOW + "es rattert stark, aber passt scho." + ANSI_RESET,
                ANSI_YELLOW + "es ist laut, aber für den Preis ist es ok." + ANSI_RESET
        };
        String[] positiverPostfix = {
                ANSI_GREEN + "es ist genial, dass es zusätzlich einen Regler hat um das Licht zu dämmen!" + ANSI_RESET,
                ANSI_GREEN + "es wurden meine Erwartungen weit übertroffen!" + ANSI_RESET,
                ANSI_GREEN + "ich kann mir mein Leben nicht ohne dem vorstellen!" + ANSI_RESET,
                ANSI_GREEN + "Shut up, and take my money!" + ANSI_RESET,
                ANSI_GREEN + "es ist der Rasen so dicht wie noch nie!" + ANSI_RESET
        };
        String[] negativerPostfix = {
                ANSI_RED + "es funktioniert dieser @§%&$§!!§$ nicht." + ANSI_RESET,
                ANSI_RED + "es wäre 0/5, aber weniger wie 1/5 geht nicht." + ANSI_RESET,
                ANSI_RED + "es hat mir die Hand fast abgerissen." + ANSI_RESET,
                ANSI_RED + "der Geruch ist unerträglich und es tropft eine flammbare Flüssigkeit daraus." + ANSI_RESET,
                ANSI_RED + "der Ramen ist aus Plastik und sollte aus echtem Gold sein." + ANSI_RESET,
                ANSI_RED + "die Staatsanwaltschaft ermittelt wegen Betrug." + ANSI_RESET
        };

        String[] prefix = {
                "Was aber nicht vergessen werden darf, ",
                "Was noch erwähnenswert ist, ",
                "Was noch fehlt ist, ",
                "Was ich aber hinzufügen will, ",
                "Zudem, ",
                "Problematisch ist, ",
                "Positiv an dem ganzen ist, ",
                "ABER, ",
                "Jedoch, "
        };

        // TODO: Aufgaben
    }
}
