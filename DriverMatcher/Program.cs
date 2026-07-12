using BenchmarkDotNet.Running;

class Program
{
    static void Main()
    {

        BenchmarkRunner.Run<Benchmark>();

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}