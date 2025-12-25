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
    int n = 0;
    cin>> n;
    for(int i=0;i<n;i++)
    {
        string input;
        cin>>input;
        // 0~9999
        int dec = stoi(input);
        //Brian Kernighan’s Algorithm
        int dec_cnt = 0;
        while (dec) 
        {
            dec &= (dec - 1);  // 每次消掉一個最低的 1
            dec_cnt++;
        }

        int hex_cnt = 0;

        for (char c : input)
        {
            int hex = c - '0';   // '0' 的 ASCII = 48，'1'=49 ...
            while (hex) 
            {
                hex &= (hex - 1);  // 每次消掉一個最低的 1
                hex_cnt++;
            }
        }    

        cout<<dec_cnt<<" "<<hex_cnt<<endl;
    }
    return 0;
}
