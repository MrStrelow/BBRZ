
import java.util.ArrayList;



public class AsciiImage {

	private int yImage;
	private int xImage;
	private char[][] image; 
	char clearChar='.';
	ArrayList<Character> uniqueCharList = new ArrayList<Character>();
	private char[] charset;
	
	public AsciiImage(int x, int y, char[] charset){
		Operation operation=new ClearOperation();
		this.yImage = y;
		this.xImage = x;
		this.charset = charset;
		image=new char[y][x];
		try {
			image=operation.execute(this).image;
		} catch (OperationException e) {
			e.getMessage();
		}
	}
	
	public AsciiImage(AsciiImage img){
		this.yImage = img.yImage;
		this.xImage = img.xImage;
		this.charset = img.charset;
		image=new char[yImage][xImage];
		
		for(int i = 0; i < img.image.length; i++){
			for(int j = 0; j < img.image[i].length; j++){
				this.image[i][j] = new Character(img.image[i][j]);
			}
		}	
	}
	
	public ArrayList<AsciiPoint> getPointList(char c){
		ArrayList<AsciiPoint> characterPoints = new ArrayList<AsciiPoint>();
		int pointCnt=0;
		
		for(int i=0; i<image.length; i++){
			for(int j=0; j<image[i].length; j++){
				if(getPixel(j, i)==c){
					characterPoints.add(new AsciiPoint(j, i));
					pointCnt++;
				}
			}
		}
		if(pointCnt==0){
			return null;
		}
		else{
			return characterPoints;	
		}
	}
	
	public char[][] getImage(){
		return new AsciiImage(this).image;
	}
	
	public AsciiImage getArea(AsciiPoint center, int area){
		AsciiImage ret = new AsciiImage(area, area, charset);
		int yPoint=center.getY()-area/2; // bewegung zum rand
		
		for(int yRet=0; yRet<area; yRet++){
			
			int xPoint=center.getX()-area/2; // bewegung zum rand
			
			for(int xRet=0; xRet<area; xRet++){
				ret.setPixel(xRet, yRet, this.getPixel(xPoint++, yPoint));
			}
			yPoint++;
		}	
		return ret;
	}
	
	public String toString(){
		String ret = "";
		
		for(char[] a : image){
			for(char b : a){
				ret+=b;
			}
			ret+="\n";
		}
		
		return ret;
	}
	
	public String getLine(int index){
		return new String(image[index]);	
	}
	
	public void setLine(int y, char[] newLine){
		if(y<yImage){
			image[y]=newLine;	
		}
		else{
			//System.out.println("nope");
		}
	}
	
	public int getLineAnz(){ // getWidth
		return image.length;
	}

	public int getColAnz(int index) { // getHight
		return xImage;
	}
	
	public int getUniqueCharsAnz(){
		ArrayList<Character> ucl = new ArrayList<Character>();
		
		for(char[] a : image){
			for(int i = 0; i < a.length; i++){
				if(!ucl.contains(a[i])){
					ucl.add(a[i]);
				}
			}
		}
		return ucl.size();
	}
	
	public void setImage(char[][] arg){
		image=arg;
	}
	
	public char getPixel(int x, int y)throws ArrayIndexOutOfBoundsException{
		if(x<=xImage || y<=yImage){
			return image[y][x];
		}else{
			throw new ArrayIndexOutOfBoundsException();
		}
	}
	
	//gibt, analog zur Methode public char getPixel(int x, int y), das Zeichen, an der durch p spezifizierten Stelle, zurück.
	public char getPixel(AsciiPoint point) throws ArrayIndexOutOfBoundsException{
		if(point.getX()<=xImage || point.getY()<=yImage){
			return image[point.getY()][point.getX()];
		}else{
			throw new ArrayIndexOutOfBoundsException();
		}
	}

	public void setPixel(int x, int y, char c) throws ArrayIndexOutOfBoundsException{
		if(getCharSet().indexOf(c) >= 0){
			image[y][x]=c;
		}else{
			throw new ArrayIndexOutOfBoundsException();
		}
	}
	
	public void setPixel(AsciiPoint point, char c) throws ArrayIndexOutOfBoundsException{
		if(getCharSet().indexOf(c) >= 0){
			image[point.getY()][point.getX()]=c;
		}else{
			throw new ArrayIndexOutOfBoundsException();
		}
	}

	public String getCharSet() {
		return new String(charset);
	}

}