#include "bipartitegraph.h"

bool bipartitegraph::isBipartite(vector<vector<int>> &graph)
{

    vector<int> colors(graph.size(), -1);
    
    for (int i = 0; i < graph.size(); i++)
    {

        if (colors[i] == -1)
        {
            colors[i] = 1;
            if (!BFS(i, colors, graph))
                return false;
        }
    }

    return true;
}

bool bipartitegraph::BFS(int source, vector<int> colors, vector<vector<int>> &graph)
{

    queue<int> my_queue;
    my_queue.push(source); // enqueueing the source

    while (!my_queue.empty())
    {
        int uSource = my_queue.front();
        my_queue.pop();

        for (int vecino : graph[uSource])
        {
            

            if (colors[vecino] == -1)
            {
                // coloreo con el color opuesto al mio;
                colors[vecino] = 1 - colors[uSource];
                my_queue.push(vecino);
            }
            else if (colors[vecino] == colors[uSource])
                return false; // hay arista, pero el vecino esta coloreado como yo
            else
                continue;
        }
    }

    return true;
}