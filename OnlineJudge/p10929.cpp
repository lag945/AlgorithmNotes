#include <iostream>
#include <vector>
#include <algorithm>
#include <string>

using namespace std;

int main()
{
	//The given numbers can contain up to 1000 digit
	string str;
	while (cin >> str)
	{
		if (str == "0")
			break;

		int remainder = 0;
		string target = str;
		while (target.size() > 0)
		{
			string leftOne = target.substr(0, 1);

			int number = stoi(leftOne);
			remainder = remainder * 10 + number;
			remainder %= 11;
			target.erase(0, 1);
		}

		//5038297 is a multiple of 11.
		//112234 is not a multiple of 11.

		if (remainder == 0)
		{
			cout << str <<" is a multiple of 11." << endl;
		}
		else
		{
			cout << str << " is not a multiple of 11." << endl;
		}
	}

	return 0;
}