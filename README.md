# CodeForFun
## LeetCode 
- https://leetcode.com/lag945/
- Problems Solved
  - 2021.10.06: 0024
  - 2021.11.03: 0100
  - 2021.12.05: 0173
  - 2021.12.24: 0200
  - What a season challenge journey! To be continued.
  - 2022.04.28: 0300
  - 2022.11.28: 0400
## Algorithm
- Rabin-Karp algorithm: Pattern Searching/Matching
  - https://leetcode.com/problems/longest-duplicate-substring/
- Monotonic Stack
  - https://leetcode.com/tag/monotonic-stack/
  - https://leetcode.com/problems/daily-temperatures/
  - https://haogroot.com/2020/09/01/monotonic-stack-leetcode/
- Topological sort
  - http://web.ntnu.edu.tw/~algo/DirectedAcyclicGraph.html
  - https://leetcode.com/problems/course-schedule-ii/
- Spell checker(trie/prefix tree)
  - https://leetcode.com/problems/implement-trie-prefix-tree/solution/
  - https://leetcode.com/problems/design-add-and-search-words-data-structure/
- Priority queue(time complexity = sort = nlog(n))
  - https://leetcode.com/problems/last-stone-weight/
  - https://leetcode.com/problems/kth-largest-element-in-a-stream/
- Binary tree Traversal，preodrer=first node is root，inorder=split left right by root,postorder=last node is root
  - https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal
  - https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal
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
## Linked List
- Reverse singly linked list (T=O(n),S=O(1))
	- https://leetcode.com/problems/reverse-linked-list/
	- https://leetcode.com/problems/palindrome-linked-list/
## System Design
- [Design URL Shortening service like TinyURL](https://leetcode.com/discuss/interview-question/124658/Design-a-URL-Shortener-(-TinyURL-)-System/)
- [LRU Cache](https://leetcode.com/problems/lru-cache/)
  - https://en.wikipedia.org/wiki/Cache_replacement_policies#LRU
  - https://en.wikipedia.org/wiki/Cache_replacement_policies#Time_aware_least_recently_used_(TLRU)
  - https://en.wikipedia.org/wiki/Cache_replacement_policies#Least-frequently_used_(LFU)
- [Browser History](https://leetcode.com/problems/design-browser-history/)
  -   https://medium.com/@lag945/%E7%B3%BB%E7%B5%B1%E8%A8%AD%E8%A8%88-%E7%80%8F%E8%A6%BD%E5%99%A8%E6%AD%B7%E5%8F%B2-1aa024408535
## GIS problems
- https://leetcode.com/problems/queries-on-number-of-points-inside-a-circle/
- https://leetcode.com/problems/interval-list-intersections/
- https://leetcode.com/problems/merge-intervals/
- https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/
- (Quick-SELECT)[https://leetcode.com/problems/k-closest-points-to-origin/]
- (Sort)[https://leetcode.com/problems/remove-covered-intervals/]
- Best Path
	- https://leetcode.com/problems/path-with-minimum-effort/
	- https://leetcode.com/problems/shortest-path-in-binary-matrix/
## Concurrency
- Mutex
  - https://leetcode.com/problems/print-in-order/
- Thread synchronization I
  - https://leetcode.com/problems/fizz-buzz-multithreaded/
  - https://leetcode.com/problems/print-zero-even-odd/
- Thread synchronization II - sequence
  - https://leetcode.com/problems/print-foobar-alternately/
  - https://leetcode.com/problems/building-h2o/
- Deadlock - Dining philosophers problem
  - https://leetcode.com/problems/the-dining-philosophers/
## Others
- Attentiveness test(Hard to pass once)
  - https://leetcode.com/problems/word-pattern/
