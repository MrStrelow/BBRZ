package FreitagNachmittag;

public class Main {
    public static void main(String[] args) {
        Spielfeld spielfeld = new Spielfeld(5);

        Hamster hempter = new Hamster(null, 0, 0);
        System.out.println(hempter.getDarstellung());
    }
}
