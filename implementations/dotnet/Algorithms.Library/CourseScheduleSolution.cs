using System.Collections.Generic;
using System;
using System.Linq;

namespace Algorithms.Library
{


    public class CourseScheduleSolution
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            return CanFinishTopological(numCourses, prerequisites);
        }

        private bool CanFinishTopological(int numCourses, int[][] prerequisites)
        {
            List<int> inDegree = new List<int>(new int[numCourses]);
            HashSet<int>[] AdjacencyList = new HashSet<int>[numCourses];

            for (int i = 0; i < numCourses; i++)
                AdjacencyList[i] = new HashSet<int>();

            foreach (var connection in prerequisites)
            {
                AdjacencyList[connection[1]].Add(connection[0]);
                inDegree[connection[0]]++;
            }

            int topElements = 0;
            int count = inDegree.Count;
            HashSet<int> visited = new HashSet<int>();
            while (topElements < count)
            {
                int nextIndex = findIndex(inDegree,visited);
                if (nextIndex == -1)
                    return false;
                else
                {
                    topElements++;
                    visited.Add(nextIndex);
                }

                foreach (var neighbor in AdjacencyList[nextIndex])
                {
                    inDegree[neighbor]--;
                }


            }

            return true;

        }

        private int findIndex(List<int> inDegree, HashSet<int> visited)
        {
            for(int i= 0;i<inDegree.Count;i++)
            {
                if(inDegree[i]==0&&!visited.Contains(i))
                    return i;
            }
            return -1;
        }

        public bool CanFinishDFS(int numCourses, int[][] prerequisites)
        {
            HashSet<int>[] AdjacencyList = new HashSet<int>[numCourses];

            for (int i = 0; i < numCourses; i++)
                AdjacencyList[i] = new HashSet<int>();

            foreach (var connection in prerequisites)
            {
                AdjacencyList[connection[1]].Add(connection[0]);
            }

            for (int i = 0; i < numCourses; i++)
            {
                HashSet<int> visited = new();
                visited.Add(i);
                if (isCicle(source: i, AdjacencyList, visited))
                    return false;
            }
            return true;
        }
        public static bool isCicle(int source, HashSet<int>[] AdjacencyList, HashSet<int> visited)
        {
            if (AdjacencyList[source].Count == 0) return false;
            bool response = false;
            foreach (var neighbor in AdjacencyList[source])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    response = isCicle(source: neighbor, AdjacencyList, visited);
                    visited.Remove(neighbor);
                    if (response) return true;
                }
                else
                    return true;

            }
            return response;
        }
    }

}