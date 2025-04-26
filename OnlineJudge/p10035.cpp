#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
	//unsigned integers less than 10 digits = 0~999999999
	unsigned int a = 0, b = 0;
	while (cin >> a >> b)
	{
		if (a == 0 && b == 0)
			break;
		//a = 1;
		//b = 999999999;

		int count = 0;
		int carry = 0;
		int i = 1;
		while (a != 0 || b != 0)
		{
			int d = 10;
			int digit_a = a % d;
			int digit_b = b % d;
			int sum = digit_a + digit_b + carry;
			if (sum >= 10)
			{
				count++;
				carry = 1;
			}
			else
				carry = 0;

			a = (unsigned int)(a / d);
			b = (unsigned int)(b / d);
		}


		//output 0~9
		//No carry operation.
		// 3 carry operations.
		// 1 carry operation.
		if (count == 0)
		{
			cout << "No carry operation." << endl;
		}
		else if (count == 1)
		{
			cout << count << " carry operation." << endl;
		}
		else
		{
			cout << count << " carry operations." << endl;
		}
	}

	return 0;
}