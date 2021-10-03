// SumOfBitDifferencesAmongAllPairs.cpp : 此檔案包含 'main' 函式。程式會於該處開始執行及結束執行。
//

#include <iostream>
#include <vector>
#include <bitset>
using namespace std;

int sum_bit_diff(vector<int> a)
{
    int n = a.size();
    int ans = 0;

    for (int i = 0; i < n - 1; i++) {
        int count = 0;

        for (int j = i; j < n; j++) {
            // Bitwise and of pair (a[i], a[j])
            int x = a[i] & a[j];
            // Bitwise or of pair (a[i], a[j])
            int y = a[i] | a[j];

            bitset<32> b1(x);
            bitset<32> b2(y);

            // to count set bits in and of two numbers
            int r1 = b1.count();
            // to count set bits in or of two numbers
            int r2 = b2.count();

            // Absolute differences at individual bit positions of two
            // numbers is contributed by pair (a[i], a[j]) in count
            count = abs(r1 - r2);

            // each pair adds twice of contributed count
            // as both (a, b) and (b, a) are considered
            // two separate pairs.
            ans = ans + (2 * count);
        }
    }
    return ans;
}

int main()
{
	std::cout << "Hello World!\n";
	//https://www.geeksforgeeks.org/sum-of-bit-differences-among-all-pairs/

	//vector<int> nums{ 10, 5 };//answer:8
    //vector<int> nums{ 1, 2 };//answer:4
    vector<int> nums{ 1, 3, 5 };//answer:8
	int ans = sum_bit_diff(nums);

	cout << ans;
}


// 執行程式: Ctrl + F5 或 [偵錯] > [啟動但不偵錯] 功能表
// 偵錯程式: F5 或 [偵錯] > [啟動偵錯] 功能表

// 開始使用的提示: 
//   1. 使用 [方案總管] 視窗，新增/管理檔案
//   2. 使用 [Team Explorer] 視窗，連線到原始檔控制
//   3. 使用 [輸出] 視窗，參閱組建輸出與其他訊息
//   4. 使用 [錯誤清單] 視窗，檢視錯誤
//   5. 前往 [專案] > [新增項目]，建立新的程式碼檔案，或是前往 [專案] > [新增現有項目]，將現有程式碼檔案新增至專案
//   6. 之後要再次開啟此專案時，請前往 [檔案] > [開啟] > [專案]，然後選取 .sln 檔案
