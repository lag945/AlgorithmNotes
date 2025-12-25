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
#include <cstring> 
using namespace std;

int main()
{   
    int test_case = 0;
    cin>> test_case;
    for(int i=0;i<test_case;i++)
    {
        int matrix[100][100];
        memset(matrix,0,sizeof(int)*100*100);
        int unsecured = 10000;
        int weak_secured = 0;
        int strong_secured = 0;

        int input[8];
        for(int j=0;j<8;j++)
        {
            int temp=0;
            cin>>temp;
            input[j]=temp;
        }

        int area_a = 0;
        int area_b = 0;
        int overlapped = 0;

        
        area_a = (input[2]-input[0]) * (input[3]-input[1]);
        area_b = (input[6]-input[4]) * (input[7]-input[5]);

        int x1 = input[0], y1 = input[1], x2 = input[2], y2 = input[3];
        int x3 = input[4], y3 = input[5], x4 = input[6], y4 = input[7];

        int ix1 = max(x1, x3);
        int iy1 = max(y1, y3);
        int ix2 = min(x2, x4);
        int iy2 = min(y2, y4);

        if (ix1 < ix2 && iy1 < iy2) {
            overlapped = (ix2 - ix1) * (iy2 - iy1);
        }
        strong_secured = overlapped;
        weak_secured = area_a + area_b - (strong_secured*2);// substract each area, so times 2.
        unsecured = unsecured - weak_secured - strong_secured;

        //cout<< area_a <<" "<< area_b<<endl;
        cout<<"Night " << (i+1)<<": " << strong_secured <<" "<< weak_secured<<" " << unsecured<<endl;
    }
    return 0;
}
