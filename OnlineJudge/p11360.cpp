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
    int mat[10][10];
    int num = 0;
    int a = 0, b = 0;
    int case_size;
    cin >> case_size;
    for(num = 1; num <= case_size; num++)
    {
        int n = 0;
        cin >> n;

        string line;
        for(int i=1;i<=n;i++)
        {
            cin >> line;
            for(int j=1;j<=n;j++)
            {
                mat[i][j] = line[j-1]-'0';
            }
        }

        int instructions = 0;
        cin >> instructions;
        while(instructions-->0)
        {
            string cmd;
            cin >> cmd;

            if(cmd == "transpose")
            {
                for (int i = 1; i <= n; ++i)
                 {
                    for (int j = i + 1; j <= n; ++j)
                     {
                       swap(mat[i][j], mat[j][i]);
                     }
                 }
            }
            else if(cmd == "row")
            {
                cin>>a>>b;
                for(int i=1; i <= n; ++i)
                {
                    swap(mat[a][i], mat[b][i]);
                }
            }       
            else if(cmd == "col")
            {
                cin>>a>>b;
                for(int i=1; i <= n; ++i)
                {
                    swap(mat[i][a], mat[i][b]);
                }                
            } 
            else if(cmd == "inc")
            {
                for (int i = 1; i <= n; ++i)
                 {
                    for (int j = 1; j <= n; ++j)
                     {
                       mat[i][j] = (mat[i][j] + 1) % 10;
                     }
                 }
            }    
            else if(cmd == "dec")
            {
                for (int i = 1; i <= n; ++i)
                 {
                    for (int j = 1; j <= n; ++j)
                     {
                       mat[i][j] = (mat[i][j] + 9) % 10;
                     }
                 }
            }                                             
        }
        if (num > 1)
        {
            cout << endl;
        }
        cout << "Case #" << num << endl;
        for(int i=1;i<=n;i++)
        {
            for(int j=1;j<=n;j++)
            {
                cout << mat[i][j];
            }
            cout << endl;
        }
        //cout << endl;
    }
    return 0;
}
