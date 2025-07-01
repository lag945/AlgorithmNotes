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
    string line;
    getline(cin, line);
    const string keyboard = "`1234567890-=QWERTYUIOP[]\\ASDFGHJKL;'ZXCVBNM,./";
    unordered_map<char, char> map;
    for (size_t i = 2; i < keyboard.size(); ++i)
        map[keyboard[i]] = keyboard[i - 2];

    string output;
    for(int i=0;i<line.size();i++)
    {
        char ch = line[i];
        if (ch == ' ')
        {
            output += ' ';
        }
        else
        {
            auto it = map.find(toupper(ch));
            if (it != map.end()) 
            {
                // If the character is found in the map, decode it
                char decoded = it->second;
                output += tolower(decoded);
            }
        }     
    }   

    cout << output << endl;

    return 0;
}
