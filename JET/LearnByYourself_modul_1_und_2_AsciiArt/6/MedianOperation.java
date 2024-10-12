import java.util.ArrayList;
import java.util.Collections;


public class MedianOperation implements Operation{
	
	public AsciiImage execute(AsciiImage img) throws OperationException {
		AsciiImage ret = new AsciiImage(img);
		
		for(int i=0; i<ret.getLineAnz(); i++){
			for(int j=0; j<ret.getLine(i).length(); j++){
				ret.setPixel(j, i, getMedian(img, i, j));
			}
		}
		
		return ret;
	}
	
	public char getMedian(AsciiImage image, int i, int j){
		int grow=1;
		int area=3;
		char ret;
		ArrayList<Character> medianList = new ArrayList<Character>();
		char[][] temp = growImage(image, grow).getArea(new AsciiPoint(j+grow, i+grow), area).getImage();
		
		for(int e=0; e<temp.length; e++){
			for(int r=0; r<temp[e].length; r++){
				medianList.add(temp[e][r]);	
			}
		}
		
		ret=sort(medianList, image).get(medianList.size()/2);
		return ret;
	}
	
	public AsciiImage growImage(AsciiImage image, int grow){
		AsciiImage ret = new AsciiImage(image.getColAnz(0)+2*grow, image.getLineAnz()+2*grow, image.getCharSet().toCharArray());
		
		for(int i=grow; i<=image.getLineAnz(); i++){
			for(int j=grow; j<=image.getLine(i-grow).length(); j++){
				ret.setPixel(j, i, image.getPixel(new AsciiPoint(j-grow, i-grow)));
			}
		}
		
		return ret;
	}
	
	public ArrayList<Character> sort(ArrayList<Character> list, AsciiImage image){
		ArrayList<Character> ret = new ArrayList<Character>();
		ArrayList<Integer> number = new ArrayList<Integer>();
		
		for(Character c : list){
			for(int i=0; i<image.getCharSet().toCharArray().length; i++){
				if(c==image.getCharSet().toCharArray()[i]){
					number.add(i);
				}
			}
		}
		
		Collections.sort(number);
		
		for(Integer a : number){
			ret.add(image.getCharSet().toCharArray()[a]);
		}
		
		return ret;
	}
}
