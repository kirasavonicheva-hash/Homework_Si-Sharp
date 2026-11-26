using System;

class Program
{
    // Значения базисных многочленов ℓi в точке x
    static double[] Basis(double[] xs, double x)
    {
        double[] li = new double[xs.Length];
        for (int i = 0; i < xs.Length; i++)
        {
            li[i] = 1;
            for (int j = 0; j < xs.Length; j++)
                if (j != i) // свой узел пропустила
                    li[i] *= (x - xs[j]) / (xs[i] - xs[j]);
        }
        return li;
    }

    // Сборка P(x)
    static double Lagrange(double[] xs, double[] ys, double x)
    {
        double[] li = Basis(xs, x);
        double p = 0;
        for (int i = 0; i < xs.Length; i++) p += ys[i] * li[i];
        return p;
    }

    static void Main()
    {
        Console.WriteLine("Задание.1");
        double[] xs = { 1, 2, 4 };
        double[] ys = { 3.5, 4.6, 6.7 };

        // 1. Базис в точке 3
        double[] b = Basis(xs, 3);
        double sum = 0;
        for (int i = 0; i < b.Length; i++) { Console.WriteLine($"l{i}(3) = {b[i]:F6}"); sum += b[i]; }
        Console.WriteLine($"Сумма = {sum}");
        Console.WriteLine($"P(3) = {Lagrange(xs, ys, 3):F4}");

        // 2. Проверка в узлах
        for (int i = 0; i < xs.Length; i++)
            Console.WriteLine($"P({xs[i]}) - y{i} = {Lagrange(xs, ys, xs[i]) - ys[i]:E3}");

        // 3. Парабола
        double[] px = { 2, 3, 5 }, py = { 4, 9, 25 };
        foreach (double x in new[] { 2.5, 3.8, 4.4 }) 
            Console.WriteLine($"P({x}) = {Lagrange(px, py, x):F6}, x^2 = {x * x:F6}, разн. = {Math.Abs(Lagrange(px, py, x) - x * x):E3}");

        Console.WriteLine("Задание.2");
        double[] xs4 = { 1, 2, 4, 6 };
        double[] ys4 = { 3.5, 4.6, 6.7, 9.8 };
        Console.WriteLine("x3 узла 4 узла");
        foreach (double x in new[] { 1.5, 2.5, 3, 3.5, 5 })
            Console.WriteLine($"{x}\t{Lagrange(xs, ys, x):F4}\t{Lagrange(xs4, ys4, x):F4}");

        // Погрешность sin: 3 узла
        double[] sx = { 0, 0.5, 1.0 };
        double[] sy = new double[sx.Length];
        for (int i = 0; i < sx.Length; i++) sy[i] = Math.Sin(sx[i]);

        // 4 узла
        double[] sx4 = { 0, 0.5, 1.0, 1.5 };
        double[] sy4 = new double[sx4.Length];
        for (int i = 0; i < sx4.Length; i++) sy4[i] = Math.Sin(sx4[i]);

        Console.WriteLine("sin: x |P-sin| 3 узла |P-sin| 4 узла");
        double max3 = 0, max4 = 0;
        for (double x = 0; x <= 1.0001; x += 0.1)
        {
            double e3 = Math.Abs(Lagrange(sx, sy, x) - Math.Sin(x));
            double e4 = Math.Abs(Lagrange(sx4, sy4, x) - Math.Sin(x));
            if (e3 > max3) max3 = e3;
            if (e4 > max4) max4 = e4;
            Console.WriteLine($"{x:F1}\t{e3:F5}\t\t{e4:F5}");
        }
        Console.WriteLine($"Максимум: 3 узла = {max3:F5}, 4 узла = {max4:F5}");

        // x = 1.4
        double e3ext = Math.Abs(Lagrange(sx, sy, 1.4) - Math.Sin(1.4));
        double e4ext = Math.Abs(Lagrange(sx4, sy4, 1.4) - Math.Sin(1.4));
        Console.WriteLine($"x=1.4: ошибка 3 узла = {e3ext:F4}, 4 узла = {e4ext:F4}");
    }
}