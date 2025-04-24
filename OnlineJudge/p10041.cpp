#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
    int case_size;
    cin >> case_size;

    while (case_size--)
    {
        int r;
        cin >> r;

        vector<int> streets(r);
        for (int i = 0; i < r; ++i)
        {
            cin >> streets[i];
        }

        sort(streets.begin(), streets.end());
        int median = streets[(int)(r / 2)]; 
        int total_distance = 0;
        
        for(int i=0;i<streets.size();i++)
        {
            total_distance += abs(streets[i] - median);
        }

        cout << total_distance << endl;
    }

    return 0;
}