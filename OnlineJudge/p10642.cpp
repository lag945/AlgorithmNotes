#include <iostream>
#include <cmath>
#include <string>
#include <iomanip>
#include <map>
#include <sstream>
#include <cctype>
#include <vector> 
#include <algorithm>
#include <unordered_map>
using namespace std;

int main()
{   
    int case_size;
    cin >> case_size;
    cin.ignore();
    for(int i=1; i<=case_size; i++)
    {
        long long answer = 0;
        int x = 0, y = 0;
        cin >> x >> y;
        long long a =  ((x+y)*(x+y+1))/2 + x;
        cin >> x >> y;
        long long b =  ((x+y)*(x+y+1))/2 + x;
        cout << "Case " << i << ": "<< b - a << endl;
        
    }
    return 0;
}
