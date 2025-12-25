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
    int num = 0;
    int case_size;
    cin >> case_size;
    for(num = 1; num <= case_size; num++)
    {
        int M = 0, Y = 0, C = 0;
        cin >> M >> Y >> C;
        string line;
        cin>>line;
        for(char ch:line)
        {
            if(ch == 'M')
                M--;
            else if(ch == 'Y')
                Y--;
            else if(ch == 'C')
                C--;
            else if(ch == 'R')
                {M--;Y--;}
            else if(ch == 'V')
                {M--;C--;}
            else if(ch == 'G')
                {Y--;C--;}
            else if(ch == 'B')
                {M--;Y--;C--;}
        }

        if( M < 0 || Y < 0 || C < 0 )
            cout << "NO" << endl;
        else
            cout << "YES " << M << " " << Y << " " << C << endl;
    }
    return 0;
}
