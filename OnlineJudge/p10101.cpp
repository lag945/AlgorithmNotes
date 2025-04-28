#include <iostream>
#include <cmath>
#include <string>
#include <iomanip>
using namespace std;

int main()
{
    string str;
    int num = 0;
    while (cin >> str)
    {
        if (str.size() == 0)
            break;

        num++;
        cout << setw(4) << num << ".";

        if (str == "0")
        {
            cout << " 0" << endl;
            continue;
        }

        if (str.size() > 14)
        {
            string _str = str.substr(0, str.size() - 14);
            if (_str != "0" && _str != "00")
                cout << " " << stoi(_str);
            cout << " kuti";
            str = str.substr(str.size() - 14);
        }
        if (str.size() > 12)
        {
            string _str = str.substr(0, str.size() - 12);
            if (_str != "0" && _str != "00")
                cout << " " << stoi(_str) << " lakh";
            str = str.substr(str.size() - 12);
        }
        if (str.size() > 10)
        {
            string _str = str.substr(0, str.size() - 10);
            if (_str != "0" && _str != "00")
                cout << " " << stoi(_str) << " hajar";
            str = str.substr(str.size() - 10);
        }
        if (str.size() > 9)
        {
            string _str = str.substr(0, str.size() - 9);
            if (_str != "0" && _str != "00")
                cout << " " << stoi(_str) << " shata";
            str = str.substr(str.size() - 9);
        }
        if (str.size() > 7)
        {
            string _str = str.substr(0, str.size() - 7);
            if (_str != "0" && _str != "00")
                cout << " " << stoi(_str);
            cout << " kuti";
            str = str.substr(str.size() - 7);
        }
        if (str.size() > 5)
        {
            string _str = str.substr(0, str.size() - 5);
            if (_str != "0" && _str != "00")
                cout << " " << stoi(_str) << " lakh";
            str = str.substr(str.size() - 5);
        }
        if (str.size() > 3)
        {
            string _str = str.substr(0, str.size() - 3);
            if (_str != "0" && _str != "00")
                cout << " " << stoi(_str) << " hajar";
            str = str.substr(str.size() - 3);
        }
        if (str.size() > 2)
        {
            string _str = str.substr(0, str.size() - 2);
            if (_str != "0" && _str != "00")
                cout << " " << stoi(_str) << " shata";
            str = str.substr(str.size() - 2);
        }

        if (str != "0" && str != "00")
        {
            cout << " " << stoi(str);
        }
        cout << endl;
    }
    return 0;
}
