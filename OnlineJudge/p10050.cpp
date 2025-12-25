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
    int case_size;
    cin >> case_size;
    cin.ignore();
    while (case_size--)
    {
        int days = 0;
        cin >> days;
        int partys = 0;
        cin >> partys;
        vector<bool> strike(days + 1, false); // day 1~N    
        vector<int> party_days(partys, 0);
        for (int i = 0; i < partys; i++)
        {
            cin >> party_days[i];
        } 

        for (int i = 0; i < partys; i++)
        {
            for(int j = party_days[i]; j <= days; j += party_days[i])
            {
                if (j % 7 == 6 || j % 7 == 0) 
                    continue;
                strike[j] = true; // mark the day as a strike day
            }
        }       
        int strike_days = 0;
        for(int i=1;i<=days ;i++)
        {
            if (strike[i]) 
                strike_days++;
        }

        cout << strike_days << endl;
        //cout << "days = " << days << ", partys = " << partys << endl;
    }
    return 0;
}
