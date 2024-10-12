/**
 * A distance function, i.e., a (mathematical) metric or semimetric. 
 */
public interface Metric<T> {
    /**
     * Calculates the distance between two arguments. The result can be used
     * as a measure of similarity. The implementor must ensure that the following
     * properties of a metric are fulfilled:
     * 1.) <code>distance(x,y) >= 0</code>. It is also required that <code>distance(x,y) == 0</code>, 
     * if <code>x.equals(y)</code>. Note that <code>distance(x,y) == 0</code> might hold, 
     * even if <code>!x.equals(y)</code> (semimetric).
     * 2.) Symmetry: <code>distance(x,y) == distance(y,x)</code>
     * 3.) Triangle inequality: <code>distance(x,y) <= distance(x,z) + 
     * distance(z,y)</code>
     * @param o1 the first argument
     * @param o2 the second argument
     * @return the distance
     */
	public int distance(T o1, T o2); 
}
