
public class LoadOperation implements Operation{

	private String data;
	OperationException ope = new OperationException("OPERATION FAILED");
	
	public LoadOperation(String data){
		this.data = data;
	}
	
	public AsciiImage execute(AsciiImage img) throws OperationException {
		AsciiImage ret = new AsciiImage(img);		
		int i=0;
		
		while(!data.isEmpty()){
			String line=data.substring(0, data.indexOf('\n'));	
			
			if(ret.getColAnz(0)==line.length() && i < ret.getLineAnz()){
				ret.setLine(i, line.toCharArray());
				i++;
				data=data.substring(data.indexOf('\n')+1);
			}
			else{
				throw ope;
			}
		}
		
		if(i<ret.getLineAnz()){
			throw ope;
		}
		return ret;
	}

}
