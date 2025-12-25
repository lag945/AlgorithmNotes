#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

static int mod = 0; 
bool mySort(int a,int b)
{
    int ma = a % mod;
    int mb = b % mod;

    if(ma < mb)
        return true;
    if(ma > mb)
        return false;

    bool odda = a % 2;
    bool oddb = b % 2; 

    if(odda != oddb)
    {
        return odda;
    }

    if(odda)
    {
        return a>b;
    }    
    else
    {
        return a<b;
    }

    return true;
}

int main()
{   
    int N,M;
    while(cin>>N>>M)
    {
        cout << N << " " << M << endl;
        if(N == 0 && M == 0)
            break;
        mod = M;
        vector<int> numbers;
        for(int i=0;i<N;i++)
        {
            int num = 0;
            cin>>num;
            numbers.push_back(num);
        }
        // sort
        sort(numbers.begin(),numbers.end(),mySort);
        // export
        for(int i=0;i<N;i++)
        {
            cout<<numbers[i]<<endl;
        }
    }
    return 0;
}
