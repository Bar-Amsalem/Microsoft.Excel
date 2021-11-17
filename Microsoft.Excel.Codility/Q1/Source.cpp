#include <stdlib.h>


int comp(const int* num1, const int* num2) {
    if (*num1 < *num2)
        return -1;
    if (*num1 > *num2)
        return 1;
    return 0;
}


int solution(int* A, int N) {
    qsort(A, N, sizeof(int), (_CoreCrtNonSecureSearchSortCompareFunction)comp);
    int first = 0, last = N - 1;

    while (first < last) {
        if (A[first] = -A[last])
            return A[last];

        if (A[first] > -A[last])
            last -= 1;
        else
            first += 1;
    }

    return 0;
}

int main()
{
    int A[]{ 4, -4, 3, -3, 2 };
    int len = sizeof(A) / sizeof(int);
    int res = solution(A, len);
    int B[]{ -4 };
    len = sizeof(B) / sizeof(int);
    res = solution(B, len);
}