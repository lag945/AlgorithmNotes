// L0721_accounts-mergeCPP.cpp : 此檔案包含 'main' 函式。程式會於該處開始執行及結束執行。
//

#include <iostream>
#include <vector>
#include <string>
#include <unordered_map>
#include <unordered_set>
#include <algorithm>

using namespace std;
class Solution {
public:
    unordered_set<string> visited;
    unordered_map<string, vector<string>> adjacent;

    void DFS(vector<string>& mergedAccount, string& email) {
        visited.insert(email);
        // Add the email vector that contains the current component's emails
        mergedAccount.push_back(email);

        for (string& neighbor : adjacent[email]) {
            if (visited.find(neighbor) == visited.end()) {
                DFS(mergedAccount, neighbor);
            }
        }
    }

    vector<vector<string>> accountsMerge(vector<vector<string>>& accountList) {
        int accountListSize = accountList.size();

        for (vector<string>& account : accountList) {
            int accountSize = account.size();

            // Building adjacency list
            // Adding edge between first email to all other emails in the account
            string accountFirstEmail = account[1];
            for (int j = 2; j < accountSize; j++) {
                string email = account[j];
                adjacent[accountFirstEmail].push_back(email);
                adjacent[email].push_back(accountFirstEmail);
            }
        }

        // Traverse over all th accounts to store components
        vector<vector<string>> mergedAccounts;
        for (vector<string>& account : accountList) {
            string accountName = account[0];
            string accountFirstEmail = account[1];

            // If email is visited, then it's a part of different component
            // Hence perform DFS only if email is not visited yet
            if (visited.find(accountFirstEmail) == visited.end()) {
                vector<string> mergedAccount;
                // Adding account name at the 0th index
                mergedAccount.push_back(accountName);
                DFS(mergedAccount, accountFirstEmail);
                // Skip the first element (name)
                // Name should be the first element, we only need to sort the emails
                sort(mergedAccount.begin() + 1, mergedAccount.end());
                mergedAccounts.push_back(mergedAccount);
            }
        }

        return mergedAccounts;
    }
};

int main()
{
    std::cout << "Hello World!\n";
    Solution s;
    vector< vector<string>> accountList;
    vector<string> a1;
    vector<string> a2;
    vector<string> a3;
    vector<string> a4;
    a1.push_back("John");
    a1.push_back("johnsmith@mail.com");
    a1.push_back("john_newyork@mail.com");
    a2.push_back("John");
    a2.push_back("johnsmith@mail.com");
    a2.push_back("john00@mail.com");
    a3.push_back("Mary");
    a3.push_back("mary@mail.com");
    a4.push_back("John");
    a4.push_back("johnnybravo@mail.com");
    accountList.push_back(a1);
    accountList.push_back(a2);
    accountList.push_back(a3);
    accountList.push_back(a4);
    vector< vector<string>> ret = s.accountsMerge(accountList);

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
