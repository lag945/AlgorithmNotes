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
    long s = 1;
    long long d=1;
    while(cin>>s>>d)
    {
        long long  days = 0;
        while(days < d)
        {
            days += s;
            s++;
        }

        s--;

        cout<<s<<endl;
    }
    return 0;
}
