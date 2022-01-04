# System design: Design Browser History
- https://leetcode.com/problems/design-browser-history/
## Time complex first.
- visit T:O(1)(best case)
- forward(int steps)  T:O(1)
- back(int steps) T:O(1)
# General design
- forward(int steps=1)
- back(int steps=1)
# Back-of-the-envelope calculation
- Memory Constraints: 10MB. How many websites you can store?
	- 10MB = 1024*1024*1024 bytes.
	- url max length ? 2000 char , depends on browser/web server
	- url average length ? 50 char
	- char/string memory , depends on encoding/language
		- C++ char average:2,0,000,000 min: 500,000
		- C# unicode char average:1,0,000,000 min: 250,000