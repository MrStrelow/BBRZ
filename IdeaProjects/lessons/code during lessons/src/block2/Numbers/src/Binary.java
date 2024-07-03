public class Binary extends Zahl {

    public Binary(String value) {
        super.value = value;
    }
    
    public Binary() {
        super.value = null;
    }
    
    public Zahl sum(Zahl[] zahlen) {
        Zahl previousZahl = null;
        
        for (Zahl zahl : zahlen) {
            
            if (previousZahl != null) {
                zahl = this.sum(zahl, previousZahl);
            }
            
            previousZahl = zahl;
            
        }
        
        return this.sum(this, previousZahl);
    }
    
    private Zahl sum(Zahl firstZahl, Zahl secondZahl) {
        String first = "0" + firstZahl.toString();
        String second = "0" + secondZahl.toString();
        
        Integer numberOfBits = Math.max(first.length(), second.length());
        Integer diffOfBits = Math.abs(first.length() - second.length());
        
        String chosenOne = first.length() < second.length() ? first : second;
        String otherOne  = first.length() < second.length() ? second : first;
        
        String padding = "";
        
        for(int i=0; i<diffOfBits; i++) {
            chosenOne = "0" + chosenOne;
        }
        
        char[] result = new char[numberOfBits];
        
        Boolean hasCarry = false;
        
        for(int i=numberOfBits-1; i>=0; i--) {
            char firstBit  = chosenOne.charAt(i);
            char secondBit = otherOne.charAt(i);
            
            if( firstBit == '0' && secondBit == '0') {
                result[i] = '0';
                
                if(hasCarry) {
                   result[i] = '1';
                }
                
                hasCarry = false;
            
            } else if( (firstBit == '1' && secondBit == '0') || (firstBit == '0' && secondBit == '1')) {
                
                if(hasCarry) {
                    result[i] = '0';
                    hasCarry = true;
                } else {
                    result[i] = '1';
                    hasCarry = false;
                }
                
            } else {
                result[i] = '0';
                
                if(hasCarry) {
                   result[i] = '1';
                }
                
                hasCarry = true;
            }
        
        }
        
        super.value = String.copyValueOf(result);
        
        return this;
        
    }
    
    public Zahl mult(Zahl[] zahlen) {
        System.out.println("is work, yes");
        return null;
    }
    
    public Zahl transformTo(Zahl zahl) {
        return null;
    }
    
}