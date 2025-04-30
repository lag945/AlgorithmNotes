#include <iostream>
#include <cmath>
#include <string>
#include <iomanip>
#include <map>
#include <sstream>
using namespace std;


int main()
{
    int line_size = 0;
    cin >> line_size;
    cin.ignore();
    
    map<string, int> countryCount;
    for(int i=0;i<line_size;i++)
    {
        string line;
        getline(cin, line);
        stringstream ss(line);
        string country;
        ss >> country;
        countryCount[country]++;
    }
    
    for (const auto& entry : countryCount)
    {
        cout << entry.first << " " << entry.second << endl;
    }

    return 0;
}
