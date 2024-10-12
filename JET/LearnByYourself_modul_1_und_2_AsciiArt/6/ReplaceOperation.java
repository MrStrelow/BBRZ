import java.util.ArrayList;


public class ReplaceOperation implements Operation{

	char oldChar;
	char newChar;
	
	public ReplaceOperation(char oldChar, char newChar){
		this.oldChar= oldChar;
		this.newChar = newChar;
	}
	
	public AsciiImage execute(AsciiImage image) throws OperationException {
		AsciiImage ret = new AsciiImage(image);
		char[][] img = ret.getImage();
		
		if(image.getCharSet().indexOf(newChar) < 0){
			throw new OperationException("OPERATION FAILED");
		}
		/*
		for(int i=0; i<img.length; i++){
			for(int j=0; j<img[i].length; j++){
				if(img[i][j]==oldChar){
					ret.setPixel(j, i, newChar);
				}
			}
		}*/

		ArrayList<AsciiPoint> region = image.getPointList(oldChar);
		for (AsciiPoint p : region) {
			ret.setPixel(p, newChar);
		}
		
		return ret;
	}

}
