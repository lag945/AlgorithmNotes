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

bool isVowels(char c)
{
    string vowels = "aiueo";

    for(int i=0;i<vowels.size();i++)
    {
        if (c == vowels[i])
            return true;
    }

    return false;
}
int main()
{   
    int case_size;
    cin >> case_size;
    cin.ignore();
    while (case_size--)
    {
        string a,b;
        getline(cin, a);
        getline(cin, b);

        if(a.size() != b.size())
        {
            cout<<"No"<<endl;
        }
        else
        {
            bool showYes = true;
            for(int i=0;i<a.size();i++)
            {
                bool is_a_vowels =  isVowels(a[i]);
                bool is_b_vowels =  isVowels(b[i]);
                if(is_a_vowels && !is_b_vowels)
                {
                    showYes = false;
                    break;
                }
                if(!is_a_vowels && is_b_vowels)
                {
                    showYes = false;
                    break;
                }
               if(!is_a_vowels && !is_b_vowels)
                {
                    if(a[i] != b[i])
                    {
                        showYes = false;
                        break;
                    }
                }
            }
            if(showYes)
                cout<<"Yes"<<endl;
            else
                cout<<"No"<<endl;
        }  
            
    }
    return 0;
}
