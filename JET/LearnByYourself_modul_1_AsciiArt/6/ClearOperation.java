
public class ClearOperation implements Operation{
	
	public AsciiImage execute(AsciiImage image) throws OperationException {
		AsciiImage ret = new AsciiImage(image);
		
		for(int i=0; i<ret.getImage().length; i++){
			for(int j=0; j<ret.getLine(i).length(); j++){
				ret.setPixel(j, i, ret.getCharSet().charAt(ret.getCharSet().length()-1));
			}
		}
		
		return ret;
	}

}
