abstract class Zahl  {
    public String value;
    
    public abstract Zahl transformTo(Zahl zahl);
    public abstract Zahl sum(Zahl[] zahlen);
    public abstract Zahl mult(Zahl[] zahlen);
    
    @Override
    public String toString() {
        return value;
    }
}