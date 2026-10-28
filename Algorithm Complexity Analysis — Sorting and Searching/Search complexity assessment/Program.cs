using System;

long comparisons = 0; 
int[] sizes = { 1000, 10000, 100000, 1000000 };

foreach (int n in sizes)
{
    int[] a = new int[n];
    for (int i = 0; i < n; i++) a[i] = i * 2 + 1; 

    comparisons = 0;
    LinearSearch(a, a[n - 1]);       
    long linHit = comparisons;
 
    comparisons = 0;
    LinearSearch(a, a[n - 1] + 1);    
    long linMiss = comparisons;
 
    comparisons = 0;
    BinarySearch(a, a[n / 2]);
    long binHit = comparisons;
 
    comparisons = 0;
    BinarySearch(a, a[n - 1] + 2);
    long binMiss = comparisons;
 
    Console.WriteLine(n + ": линейный " + linHit + "/" + linMiss + ", двоичный " + binHit + "/" + binMiss);
}

static int LinearSearch(int[] a, int key)
{
    for (int i = 0; i < a.Length; i++)
    {
        comparisons++;
        if (a[i] == key) return i;
    }
    return -1;
}
 
static int BinarySearch(int[] a, int key)
{
    int left = 0;
    int right = a.Length - 1;
    while (left <= right)
    {
        int mid = (left + right) / 2;
        comparisons++;
        if (a[mid] == key) return mid;
        if (a[mid] < key) left = mid + 1;
        else right = mid - 1;
    }
    return -1;
}