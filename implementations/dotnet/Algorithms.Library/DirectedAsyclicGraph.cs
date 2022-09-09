using System.Collections.Generic;
public class DirectedAsyclicGraph<T>
{
    
    public Dictionary<T,List<T>> AdjacencyList { get; set; }
}