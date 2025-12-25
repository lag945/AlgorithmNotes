#include <iostream>
#include <vector>
#include <string>

using namespace std;

int main()
{   
    int s, n;
    while(cin >> s >> n)
    {
        if (s == 0 && n == 0)
            break;

        int arr[10][5] = {
            {1, 4, 0, 4, 1},  // 0
            {0, 3, 0, 3, 0},  // 1
            {1, 3, 1, 2, 1},  // 2
            {1, 3, 1, 3, 1},  // 3
            {0, 4, 1, 3, 0},  // 4
            {1, 2, 1, 3, 1},  // 5
            {1, 2, 1, 4, 1},  // 6
            {1, 3, 0, 3, 0},  // 7
            {1, 4, 1, 4, 1},  // 8
            {1, 4, 1, 3, 1}   // 9
        };

        // 轉換為數字列表
        string num_str = to_string(n);
        vector<int> target;
        for(char c : num_str)
        {
            target.push_back(c - '0');
        }

        // 顯示 5 行
        for(int step = 0; step < 5; step++)
        {
            int rows = (step == 0 || step == 2 || step == 4) ? 1 : s;
            
            for(int row = 0; row < rows; row++)
            {
                for(int idx = 0; idx < target.size(); idx++)
                {
                    int num = target[idx];
                    int t = arr[num][step];
                    
                    if(t == 0)  // 空白
                    {
                        for(int i = 0; i < s + 2; i++)
                            cout << " ";
                    }
                    else if(t == 1)  // 橫線
                    {
                        cout << " ";
                        for(int i = 0; i < s; i++)
                            cout << "-";
                        cout << " ";
                    }
                    else if(t == 2)  // 左邊豎線
                    {
                        cout << "|";
                        for(int i = 0; i < s + 1; i++)
                            cout << " ";
                    }
                    else if(t == 3)  // 右邊豎線
                    {
                        for(int i = 0; i < s + 1; i++)
                            cout << " ";
                        cout << "|";
                    }
                    else if(t == 4)  // 兩邊豎線
                    {
                        cout << "|";
                        for(int i = 0; i < s; i++)
                            cout << " ";
                        cout << "|";
                    }
                    
                    // 數字之間的空格（最後一個數字後面不加）
                    if(idx < target.size() - 1)
                        cout << " ";
                }
                cout << endl;
            }
        }
        
        cout << endl;  // 每組輸出後空一行
    }
    return 0;
}