using System;
using System.Collections.Generic;

namespace Algorithms.Library
{
    public class NodeG
    {
        public int val;
        public IList<NodeG> neighbors;

        public NodeG()
        {
            val = 0;
            neighbors = new List<NodeG>();
        }

        public NodeG(int _val)
        {
            val = _val;
            neighbors = new List<NodeG>();
        }

        public NodeG(int _val, List<NodeG> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public class DeepClone
    {
        HashSet<int> visited = new();
        Dictionary<int, NodeG> constructed = new();

        public NodeG CloneGraph(NodeG nodeG)
        {
            if (nodeG is null) return null;

            NodeG response = new NodeG(nodeG.val);
            visited.Add(nodeG.val);




            DFS(nodeG, response, null);
            return response;

        }

        public void DFS(NodeG source, NodeG copy, NodeG parent)
        {
            if (source == null) return;

            for (int i = 0; i < source.neighbors.Count; i++)
            {
                int key = source.neighbors[i].val;
                if (visited.Contains(key))
                    continue;

                if (constructed.ContainsKey(key))
                {
                    constructed[key].neighbors.Add(copy);
                    copy.neighbors.Add(constructed[key]);
                }
                else
                {
                    constructed.Add(key, new NodeG(key,
                                                new List<NodeG>() { copy })
                                       );
                    copy.neighbors.Add(constructed[key]);
                }
            }

            for (int i = 0; i < source.neighbors.Count; i++)
            {
                int key = source.neighbors[i].val;

                if (visited.Contains(key))
                    continue;
                visited.Add(key);



                DFS(source.neighbors[i], copy.neighbors[i], source);
            }
        }
    }
}