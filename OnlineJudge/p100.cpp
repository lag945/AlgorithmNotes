#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int calc_cycle_length(int n)
{
	int count = 1;
	while (n != 1)
	{
		if (n % 2 == 0)
			n = n / 2;
		else
			n = 3 * n + 1;
		count++;
	}
	return count;
}

int main()
{
	int i, j;
	while (cin >> i >> j)
	{
		int start = min(i, j);
		int end = max(i, j);

		int max_cycle = 0;
		for (int k = start; k <= end; ++k)
		{
			int cycle_len = calc_cycle_length(k);
			if (cycle_len > max_cycle)
				max_cycle = cycle_len;
		}

		cout << i << " ";
		cout << j << " ";
		cout << max_cycle << endl;
	}

	return 0;
}