import java.util.ArrayList;

/**
 * This Class provides a method to replace all occurrences of a specified char by another specified
 * char. It implements the Operation interface.
 * 
 * @version 7
 * @author PP
 * 
 */
public class ReplaceOperation implements Operation {

	private char oldChar;
	private char newChar;

	/**
	 * Creates a new ReplaceOperation that will replace all oldChars by newChar.
	 * 
	 * @param oldChar
	 *            The char that will be replaced
	 * @param newChar
	 *            The char that will be used for replacing
	 */
	public ReplaceOperation(char oldChar, char newChar) {
		this.oldChar = oldChar;
		this.newChar = newChar;
	}

	/**
	 * Executes this ReplaceOperation and returns as new AsciiImage where all occurrences of the
	 * oldChar are replaced by the newChar. Other chars remain unchanged.
	 * 
	 * @param img
	 *            The AsciiImage to use as basis for executing the Operation, it will remain
	 *            unchanged
	 * @return A new AsciiImage reflecting the result of the executed Operation
	 * @throws OperationException
	 *             Thrown if the newChar is not part of the AsciiImage's charset
	 */
	public AsciiImage execute(AsciiImage img) throws OperationException {

		if (img.getCharset().indexOf(newChar) < 0) {
			throw new OperationException("Invalid char");
		}

		AsciiImage result = new AsciiImage(img);

		ArrayList<AsciiPoint> region = img.getPointList(oldChar);
		for (AsciiPoint p : region) {
			result.setPixel(p, newChar);
		}

		return result;

	}

}
