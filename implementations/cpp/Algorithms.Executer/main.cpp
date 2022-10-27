#include <iostream>
#include <vector>
#include <queue>
#include "bipartitegraph.h"

using namespace std;

int main(int argc, char const *argv[])
{
    vector<int> a{1, 3};
    vector<int> b{0, 2};
    vector<int> c{1, 3};
    vector<int> d{0, 2};
    vector<vector<int>> graphToCheck = { a,b,c,d};

    bipartitegraph bpg;
    bool result = bpg.isBipartite(graphToCheck);    
    cout << result <<std::endl;
    return 0;
}
