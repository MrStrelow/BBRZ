
public class AsciiStack {
		
	private AsciiStackNode head;
	
	public AsciiStack(){
		head=new AsciiStackNode(null, null);
	}
	
	public boolean empty(){
		return head.getNext()==null;
	}
	
	public int size(){
		int ret=0;
		if(head.getNext()!=null){
			return ret+=head.getNext().size(ret);	
		}else{
			return ret;
		}
	}
	
	public AsciiImage pop(){
		if(!empty()){
			if(size()>1){
				AsciiImage retImage = peek();
				head.setNext(head.getNext().getNext());
				return retImage;	
			}
			else{
				System.out.println("STACK EMPTY");
				return head.getNext().getImage();
			}
		}else{
			System.out.println("STACK EMPTY");
			return null;
		}
	}
	
	
	public AsciiImage peek(){ 
		if(head.getNext()!=null){
			return new AsciiImage(head.getNext().getImage());
		}
		else{
			return null;
		}
	}
	
	public void push(AsciiImage image){ 
		if(head.getNext()!=null){
			AsciiStackNode node = new AsciiStackNode(image, head.getNext());
			head.setNext(node);	
		}
		else{
			AsciiStackNode node = new AsciiStackNode(image, null);
			head.setNext(node);	
		}
	}
}
