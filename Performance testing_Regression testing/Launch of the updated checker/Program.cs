using System;

class Program
{
    static void Main()
    {
        RunNewTests();
    }

    static double CalcDelivery(double weight, bool isExpress)
    {
        double price = 250; 

        if (isExpress) price += 100; 

        if (weight > 20)
        {
            price = price * 0.95; 
        }

        return price;
    }
    
    static void RunNewTests()
    {
        Console.WriteLine("Запуск обновленного проверяльщика");
        int failedCount = 0;
        
        failedCount += AssertTest("Тест 1 (Обычная, вес 5кг)", CalcDelivery(5, false), 250);
        failedCount += AssertTest("Тест 2 (Экспресс, вес 5кг)", CalcDelivery(5, true), 350);
        
        failedCount += AssertTest("Новый Тест (Вес 25кг - скидка ЕСТЬ)", CalcDelivery(25, false), 237.5);
        failedCount += AssertTest("Новый Тест (Вес 3кг - скидки НЕТ)", CalcDelivery(3, false), 250);
        failedCount += AssertTest("Новый Тест (Вес 20кг - граница, скидки НЕТ)", CalcDelivery(20, false), 250);
        
        if (failedCount == 0)
        {
            Console.WriteLine("\nРЕЗУЛЬТАТ: Всё зелёное! Изменения успешно приняты.");
        }
        else
        {
            Console.WriteLine($"\nРЕЗУЛЬТАТ: Красный прогон. Упало тестов: {failedCount}");
        }
    }

    static int AssertTest(string testName, double actual, double expected)
    {
        if (Math.Abs(actual - expected) < 0.001)
        {
            Console.WriteLine($"[OK] {testName}");
            return 0;
        }
        else
        {
            Console.WriteLine($"[FAIL] {testName}: Ожидали {expected}, пришло {actual}");
            return 1;
        }
    }
}