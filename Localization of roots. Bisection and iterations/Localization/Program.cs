using System;

class Program
{
    static void Main(string[] args)
    {
        double f (double x) => x * x * x + x - 3;

        for (double x = 0; x <= 2; x += 0.5)
        {
            Console.WriteLine($"f({x}) = {f(x)}");
        }

        for (double x = 0; x < 2; x += 0.5)
        {
            if (f(x) * f(x + 0.5) < 0)
            {
                Console.WriteLine($"Отрезок: [{x}; {x + 0.5}]");
                Console.WriteLine($"Условие: {f(x)} * {f(x + 0.5)} = {f(x) * f(x + 0.5)} < 0");
            }
        }
    }
}