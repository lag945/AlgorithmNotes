import sys

def vito_house(test_cases):
    results = []
    for case in test_cases:
        relatives = sorted(case)
        median = relatives[len(relatives) // 2]
        total_distance = sum(abs(r - median) for r in relatives)
        results.append(total_distance)
    return results

def main():
    input = sys.stdin.read
    data = input().splitlines()
    test_cases = []
    n = int(data[0])
    for i in range(1, n + 1):
        line = list(map(int, data[i].split()))
        test_cases.append(line[1:])
    results = vito_house(test_cases)
    for res in results:
        print(res)

if __name__ == "__main__":
    main()
