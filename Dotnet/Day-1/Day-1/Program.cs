using System;

class Addition
{
    static public int sum(int a, int b)
    {
        return a + b;
    }

    static public void OEsum()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];
        int e = 0, c = 0;

        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            if (arr[i] % 2 == 0)
                e += arr[i];
            else
                c += arr[i];
        }

        Console.WriteLine($"even sum {e}");
        Console.WriteLine($"odd sum {c}");
    }

    static public int Multiply(int a, int b)
    {
        return a * b;
    }

    static public int Max(int a, int b)
    {
        return a > b ? a : b;
    }

    static public void CheckPrime(int n)
    {
        int count = 0;
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
                count++;
        }

        if (count == 2)
            Console.WriteLine("Prime number");
        else
            Console.WriteLine("Not a prime number");
    }

    static public void ReverseNumber(int n)
    {
        int rev = 0;
        while (n > 0)
        {
            rev = rev * 10 + (n % 10);
            n /= 10;
        }
        Console.WriteLine($"Reversed number {rev}");
    }

    static public void CountDigits(int n)
    {
        int count = 0;
        while (n > 0)
        {
            count++;
            n /= 10;
        }
        Console.WriteLine($"Digit count {count}");
    }
}

namespace Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = Addition.sum(10, 20);
            Console.WriteLine(r);

            Console.WriteLine(Addition.Multiply(5, 4));
            Console.WriteLine(Addition.Max(10, 25));

            Addition.CheckPrime(7);
            Addition.ReverseNumber(1234);
            Addition.CountDigits(56789);

            Addition.OEsum();
        }
    }
}
