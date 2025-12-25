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
    int input = 0;
    while(cin >> input && input != 0)
    {
        long long l = 1, r = 2e9, n = 0;
        while (l <= r) {
            long long mid = (l + r) / 2;
            long long sum = mid * (mid + 1) / 2;
            if (sum >= input) {
                n = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }

        long long sum = n * (n + 1) / 2;

        if(sum > input)
        {
            cout << sum-input << " " << n << endl;
        }
        else if(sum == input)
        {
            cout << n+1 << " " << n+1 << endl;
        }
    }
    return 0;
}
