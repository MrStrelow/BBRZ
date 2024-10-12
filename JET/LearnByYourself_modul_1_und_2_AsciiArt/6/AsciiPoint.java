
public class AsciiPoint {
	
	private int x;
	private int y;
	
	public AsciiPoint(int x, int y){
		this.x=x;
		this.y=y;
	}
	
	public String toString(){
		return "("+x+","+y+")";
	}
	
	public int getY(){
		return y;
	}
	
	public int getX(){
		return x;
	}
}
