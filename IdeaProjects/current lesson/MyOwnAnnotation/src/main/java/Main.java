public class Main {
    public static void main(String[] args) {
        MyClass myClass = new MyClass();

        // After the initialization aspect has been applied
        System.out.println(myClass.getMyField()); // Should print the new Object
        System.out.println(myClass.getMyString()); // Should print the new String
    }
}
