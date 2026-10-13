using System;

namespace program;

class Program
{
    static int SumOfDivisors(int n) => 
    Enumerable.Range(1, n / 2).Where(i => n % i == 0).Sum();

    static void Main()
    {
        Console.WriteLine("Програма для пошуку дружніх пар точок зірочок у заданому відрізку.");
        Console.Write("Введіть початок відрізку a: ");
        int.TryParse(Console.ReadLine(), out int a);
        Console.Write("Введіть кінець відрізку b: ");
        int.TryParse(Console.ReadLine(), out int b);

        var friendlyPairs = from i in Enumerable.Range(a, Math.Max(0, b - a + 1))
        let j = SumOfDivisors(i)
        where j > i && j <= b && SumOfDivisors(j) == i
        select (A: i, B: j);
        Console.WriteLine(friendlyPairs.Any() ? string.Join("\n", friendlyPairs.Select(p => $"Знайдено дружню пару точок зірочок: {p.A} та {p.B}")) : "Пари не знайдено.");
    }
}
