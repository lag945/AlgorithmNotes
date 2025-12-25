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

// 函數聲明，方便主函數或遞歸調用
int digit_sum(std::string number);
int digit_sum(int number);

// 1. 處理字串輸入的版本
// 計算字串中所有數字字符（'0'-'9'）的數值總和
int digit_sum(std::string number)
{
    int sum = 0;
    // 使用範圍-based for loop 是 C++11 的慣用寫法
    for (char digit_char : number)
    {
        // 確保字符是數字，然後將其轉換為對應的整數值
        if (digit_char >= '0' && digit_char <= '9') {
            // '1' - '0' = 1, '9' - '0' = 9。這是標準且高效的字符轉數字方法
            sum += digit_char - '0';
        }
    }

    // 遞歸調用，直到結果為個位數
    if (sum >= 10)
    {
        // 將新的總和(int)轉換回字串(std::string)才能遞歸調用
        return digit_sum(sum); // 這裡將會調用 digit_sum(int)
    }

    return sum;
}

// 2. 處理整數輸入的版本
// 使用 std::stringstream (C++ 標準方法) 將整數轉換為字串
int digit_sum(int number) {
    if (number < 10) {
        return number; // 個位數直接返回
    }

    // 將整數轉換為字串
    std::stringstream ss;
    ss << number;
    std::string str_number = ss.str();

    // 調用字串版本的 digit_sum
    return digit_sum(str_number);
}

int main()
{   
    string line;
    getline(cin, line);
    while(line != "0")
    {
        int result = digit_sum(line);
        cout<<result<<endl;
        getline(cin, line);
    }
    return 0;
}
