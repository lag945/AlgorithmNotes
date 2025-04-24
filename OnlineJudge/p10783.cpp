#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
    int case_size;
    cin >> case_size;

    for(int case_num = 1 ; case_num<= case_size ; case_num++)
    {
        int begin = 0, end = 0, sum = 0;
        cin >> begin;
        cin >> end;
        for (int num = begin; num <= end; num++)
        {
            bool isOdd = (num % 2 != 0);
            if (isOdd)
            {
                sum += num;
            }

        }

        cout << "Case " << case_num << ": " << sum << endl;
    }

    return 0;
}