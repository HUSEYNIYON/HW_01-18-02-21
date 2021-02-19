using System;
using System.Threading;
using System.Threading.Tasks;

namespace HW_1_18_02_21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 30);
            for (int i = 0; i < 150; i++)
            {
                Matrix instance = new Matrix(i, true);
                new Thread(instance.Move).Start();
            }
        }
        static void ThreadGetSumm()
        {
            Thread Thread1 = new Thread(new ThreadStart(GetSumm));
            Thread1.Start();
        }
        static async void SummAsync()
        {
            await Task.Run(() => Summ(1, 5));
            await Task.Run(() => Summ(5, 10));
            await Task.Run(() => Summ(2, 5));
            await Task.Run(() => Summ(10, 18));
        }
        static void ParallelSumm()
        {
            Parallel.Invoke(GetSumm, () => GetSumm(), () => GetSumm());
        }
        static void GetSumm()
        {
            int result = 0;
            for (int i = 1; i <= 10; i++)
            {
                result += i;
                System.Console.WriteLine(result);
                Thread.Sleep(1000);
            }
            Console.WriteLine($"Сумма от 1 до 10 ровен {result}");
        }
        static void Summ(int begin, int end)
        {
            int result = 0;
            for (int i = begin; i <= end; i++)
            {
                result += i;
            }
            Console.WriteLine($"Сумма от {begin} до {end} ровен {result}");
        }
    }
}
