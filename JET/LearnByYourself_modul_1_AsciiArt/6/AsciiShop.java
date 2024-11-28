import java.util.Scanner;


public class AsciiShop {

	public static void main(String[] args){
		
		Scanner sc = new Scanner(System.in);
		AsciiStack stack = new AsciiStack();
		AsciiImage image = null;
		//ArrayList<Object> infoList = new ArrayList<Object>();
		
		boolean inputError = false;
		boolean unknownOperation = false;
		Operation operation;
		
		if(sc.next().equals("create")){

			if(sc.hasNextInt()){
				int xCreate=sc.nextInt();
				
				if(sc.hasNextInt()){
					int	yCreate=sc.nextInt();
					
					if(sc.hasNext()){
						String charset = sc.next();
						
						if(xCreate>0 && yCreate>0){
							image = new AsciiImage(xCreate, yCreate, charset.toCharArray());
							stack.push(new AsciiImage(image));
						}else{
							inputError=true;
						}	
					}
				}
			}
			else{
				inputError=true;
			}
		}
		else{
			inputError=true;
		}
		
		while(!inputError && sc.hasNext()){
			String comline = sc.next();
			inputError=false;
			unknownOperation=false;
			
			if(comline.equals("load")){
				String eof = sc.next();
				String data="";
				while(sc.hasNext()){
					String line = sc.next();
					
					if(line.equals(eof)){
						break;
					}
					else{
						data += line;
						data+="\n";
					}
				}
				operation = new LoadOperation(data);
				try {
					image=operation.execute(image);
				} catch (OperationException e) {
					System.out.println(e.getMessage());
				}
				stack.push(new AsciiImage(image));
					
			}else if(comline.equals("clear")){
				
				operation=new ClearOperation();
				try {
					image=operation.execute(image);
				} catch (OperationException e) {
					System.out.println(e.getMessage());
				}
				stack.push(new AsciiImage(image));
					
			}else if(comline.equals("replace")){	
				char oldChar = sc.next().charAt(0);
				char newChar = sc.next().charAt(0);
				
				operation=new ReplaceOperation(oldChar, newChar);
				
				try {
					image=operation.execute(image);
					stack.push(new AsciiImage(image));
				} 
				catch (OperationException e){
					System.out.println(e.getMessage());
				}		
			}
			else if(comline.equals("filter")){
				if(sc.next().equals("median")){
					operation = new MedianOperation();
					try {
						image=operation.execute(image);
						stack.push(image);
					} catch (OperationException e) {
						System.out.println(e.getMessage());
					}
				}else{
					inputError = true;
				}
				
			}
			else if(comline.equals("undo")){				
				image = stack.pop();
			}
			
			else if(comline.equals("print")){
				System.out.println(stack.peek().toString());
				//System.out.println(stack.size());
				//System.out.println(image.getColAnz(0) + " " + image.getLineAnz());
			}
			else{
				unknownOperation=true;
				break;
			}
		}	
		
		if(inputError == true)				System.out.println("INPUT MISMATCH");
		if(unknownOperation == true)		System.out.println("UNKNOWN COMMAND");			
				
		sc.close();
	}	
}
/*
create 6 4 asdf
load t
ssssss
ffdsdf
ddfdfd
dddddd
t
filter median
*/