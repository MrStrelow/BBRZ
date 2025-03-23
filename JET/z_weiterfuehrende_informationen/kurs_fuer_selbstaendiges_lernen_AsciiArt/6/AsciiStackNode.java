
public class AsciiStackNode {
	
	private AsciiImage image;
	private AsciiStackNode next;

	public AsciiStackNode(AsciiImage image, AsciiStackNode next){
		this.image=image;
		this.next=next;
	}
	
	public AsciiImage getImage(){
		return new AsciiImage(image);
	}
	
	public AsciiStackNode getNext(){
		return next;
	}
	
	public void setNext(AsciiStackNode next){
		this.next=next;
	}
	
	public int size(int ret){
		if(next!=null){
			ret++;
			return next.size(ret);	
		}else{
			return ++ret;
		}
	}
}
