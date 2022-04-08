// L0703_kth-largest-element-in-a-streamCPP.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <queue>

using namespace std;

class mycomparison
{
    bool reverse;
public:
    mycomparison(const bool& revparam = false)
    {
        reverse = revparam;
    }
    bool operator() (const int& lhs, const int& rhs) const
    {
        if (reverse) return (lhs > rhs);
        else return (lhs < rhs);
    }
};

class KthLargest {
public:
    priority_queue<int, vector<int>, greater<int>> pq;
    int k = k;

    KthLargest(int k, vector<int>& nums) 
    {
        this->k = k;
        for (int n : nums)
        {
			if ((int)pq.size() == k)
            {
                if(n<pq.top())
                    continue;
            }			
            pq.push(n);
            if ((int)pq.size() > k)
                pq.pop();
        }
    }

	//T:O(n)
    int add(int val) {
        if ((int)pq.size() == k)
        {
            if(val<pq.top())
                return pq.top();
        }               			
        pq.push(val);
        if ((int)pq.size() > k)
            pq.pop();
        return pq.top();
    }
};

int main()
{
    std::cout << "Hello World!\n";
    vector<int> nums;
    nums.push_back(4);
    nums.push_back(5);
    nums.push_back(8);
    nums.push_back(2);
    KthLargest kl(3, nums);
	bool r = kl.add(3) == 4;
    return 0;


}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
