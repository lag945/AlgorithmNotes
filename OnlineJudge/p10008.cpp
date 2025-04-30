#include <iostream>
#include <cmath>
#include <string>
#include <iomanip>
#include <map>
#include <sstream>
#include <cctype>
#include <vector> 
#include <algorithm>
using namespace std;


int main()
{
    //input 1
    //input ccbba
    //output
    // C 2
    // B 2
    // A 1
    int line_size = 0;
    cin >> line_size;
    cin.ignore();
    
    map<char, int> charCount;
    //map<char, int> charOrder;
    //int order = 0;
    for(int i=0;i<line_size;i++)
    {
        string line;
        getline(cin, line);
        for(int j=0;j<line.size();j++)
        {
            char c = line[j];
            if(isalpha(c))
            {
                c = toupper(c);
                charCount[c]++;
                //if(charOrder.find(c) == charOrder.end())
                //{
                //    charOrder[c] = order++;
                //}   
            }

        }   
    }

    vector<pair<char, int>> sortedList(charCount.begin(), charCount.end());

    sort(sortedList.begin(), sortedList.end(),
         [](const pair<char, int>& a, const pair<char, int>& b)//[&charOrder](const pair<char, int>& a, const pair<char, int>& b)
        {
            if(a.second > b.second)
                return true;
            else if(a.second == b.second)
            {
                //return charOrder[a.first] < charOrder[b.first];
                return a.first < b.first;
            }
            else
                return false;
        });
    
    for (const auto& entry : sortedList)
    {
        cout << entry.first << " " << entry.second << endl;
    }

    return 0;
}
