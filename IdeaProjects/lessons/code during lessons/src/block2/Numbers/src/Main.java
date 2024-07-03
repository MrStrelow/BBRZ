public class Main
{
	public static void main(String[] args) {
		Zahl aBinaryNumber       = new Binary("111011");
		Zahl anotherBinaryNumber = new Binary("1011");

        System.out.println("First:\t" + aBinaryNumber);
		System.out.println("Second:\t" + anotherBinaryNumber);

		Zahl[] binaryNumbers = new Zahl[1];
		binaryNumbers[0] = anotherBinaryNumber;
		
		System.out.println("Result:\t" + aBinaryNumber.sum(binaryNumbers));
	}
}

