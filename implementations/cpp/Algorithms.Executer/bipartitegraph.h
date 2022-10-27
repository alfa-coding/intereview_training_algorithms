#include <iostream>
#include <vector>
#include <queue>

#ifndef BIPARTITEGRAPH_H
#define BIPARTITEGRAPH_H

using namespace std;
class bipartitegraph {
public:
    bool isBipartite(vector<vector<int>>& graph);
private:
    bool BFS(int source, vector<int> colors, vector<vector<int>>& graph);
};

#endif 
