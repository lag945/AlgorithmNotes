# CodeForFun
## LeetCode 
- https://leetcode.com/lag945/
- Problems Solved
  - 2021.10.06: 0024
  - 2021.10.10: 0035
  - 2021.10.18: 0050
  - 2021.10.24: 0070
  - 2021.10.31: 0086
  - 2021.11.03: 0100
  - 2021.11.12: 0119
  - 2021.11.19: 0139
## Algorithm
- Rabin-Karp algorithm: Pattern Searching/Matching
  - https://leetcode.com/problems/longest-duplicate-substring/
- Monotonic Stack
  - https://leetcode.com/tag/monotonic-stack/
  - https://leetcode.com/problems/daily-temperatures/
  - https://haogroot.com/2020/09/01/monotonic-stack-leetcode/
## Bit Manipulation
- C# use BitArray class
  - BitArray ba = new BitArray(BitConverter.GetBytes(int32));
- [Hamming distance](https://leetcode.com/problems/hamming-distance/)
- XOR
  - A XOR B writes A ^ B (C#)
  - A XOR B XOR A = B
- Count
  - Count 1: (1) while(n>0){n = n&(n-1);count++;} (2) for(int i=0;i<32;i++){ n&1==1?count++:; n = n >>1; } (3) foreach( bool b in bitarray) if(b) count++;
  - Count 0: (1) 32-(Count 1) (2) foreach( bool b in bitarray) if(!b) count++;
## System Design
- [Design URL Shortening service like TinyURL](https://leetcode.com/discuss/interview-question/124658/Design-a-URL-Shortener-(-TinyURL-)-System/)
## GIS problems
- https://leetcode.com/problems/queries-on-number-of-points-inside-a-circle/
- https://leetcode.com/problems/interval-list-intersections/
