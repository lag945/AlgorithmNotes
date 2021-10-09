// L0212_Word_Search_IICPP.cpp : 此檔案包含 'main' 函式。程式會於該處開始執行及結束執行。
//

#include <iostream>
#include <vector>

using namespace std;

bool dfs(vector<vector<char>>& board, int i, int j, string& word) {
    if (!word.size())
        return true;
    if (i < 0 || i >= board.size() || j < 0 || j >= board[0].size() || board[i][j] != word[0])
        return false;
    char c = board[i][j];
    board[i][j] = '*';
    string s = word.substr(1);
    bool ret = dfs(board, i - 1, j, s) || dfs(board, i + 1, j, s) || dfs(board, i, j - 1, s) || dfs(board, i, j + 1, s);
    board[i][j] = c;
    return ret;
}
class Solution {
public:
    static vector<string> findWords(vector<vector<char>>& v, vector<string>& s) {
        vector<string> ans;
        for (auto& x : s) {
            int p = 0;
            reverse(x.begin(), x.end());
            for (int i = 0; i < v.size(); i++) {
                for (int j = 0; j < v[0].size(); j++) {
                    if (dfs(v, i, j, x)) {
                        p = 1; break;
                    }
                }
                if (p)break;
            }
            if (p) {
                reverse(x.begin(), x.end());
                ans.push_back(x);
            }
        }
        return ans;
    }
};

int main()
{
    //std::cout << "Hello World!\n";
    vector<vector<char> > a;

    vector<char> temp;
    temp.push_back('o');
    temp.push_back('a');
    temp.push_back('a');
    temp.push_back('n');
    a.push_back(temp);
    temp.clear();
    temp.push_back('e');
    temp.push_back('t');
    temp.push_back('a');
    temp.push_back('e');
    a.push_back(temp);
    temp.clear();
    temp.push_back('i');
    temp.push_back('h');
    temp.push_back('k');
    temp.push_back('r');
    a.push_back(temp);
    temp.clear();
    temp.push_back('i');
    temp.push_back('f');
    temp.push_back('l');
    temp.push_back('v');
    a.push_back(temp);
    vector<string> b;
	b.push_back("oath");// , "pea", "eat", "rain"})
    b.push_back("pea");
    b.push_back("eat");
    b.push_back("rain");
    vector<string> ret  = Solution::findWords(a, b);

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
