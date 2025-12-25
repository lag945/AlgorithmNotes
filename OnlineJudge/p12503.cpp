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
    int test_case = 0;
    cin>> test_case;
    int instructions[101];
    for(int i=0;i<test_case;i++)
    {
        int ins_cnt = 0;
        cin>>ins_cnt;
        int p = 0;
        for(int j=1;j<=ins_cnt;j++)
        {
            string input;
            cin>>input;
            if(input == "LEFT")
            {
                instructions[j] = -1;
            }
            else if(input == "RIGHT")
            {
                instructions[j] = 1;
            }
            else if (input == "SAME")
            {
                cin>>input;
                cin>>input;
                instructions[j] = instructions[stoi(input)];
            }    

            p+=instructions[j];
        }

        cout<<p<<endl;
    }
    return 0;
}
