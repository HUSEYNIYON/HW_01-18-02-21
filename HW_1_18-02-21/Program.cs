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
            for (int i = 0; i < 160; i++)
            {
                Matrix matrix = new Matrix(i, true);
                new Thread(matrix.Running).Start();
            }
        }
        public static void threadSum()
        {
            Thread thread = new Thread(new ThreadStart(GetSumma));
            thread.Start();
        }
       
        static async void SumAsync()
        {
            await Task.Run(() => Summa(1,5));
            await Task.Run(() => Summa(5, 10));
            await Task.Run(() => Summa(2, 5));
            await Task.Run(() => Summa(10, 18));
        }
        static void ParallelSum()
        {
            Parallel.Invoke(GetSumma, () => GetSumma(), () => GetSumma());
        }
        static void GetSumma()
        {
            int result = 0;
            for (int i = 1; i <= 10; i++)
            {
                result += i;
                Console.WriteLine(result);
                Thread.Sleep(1000);
            }
            Console.WriteLine($"Сумма от 1 до 10 рaвен {result}");
        }
       
        public static void Summa(int begin, int end)
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
