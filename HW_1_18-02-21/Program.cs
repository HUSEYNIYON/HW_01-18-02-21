using System;
using System.Threading;
using System.Threading.Tasks;

namespace HW_1_18_02_21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(170, 42);
            for (int i = 0; i < 160; i++)
            {
                Matrix matrix = new Matrix(i, true);
                new Thread(matrix.Running).Start();
            }
        }
        public static void threadSum()
        {
            Thread thread = new Thread(new ThreadStart(threadSum));
            thread.Start();
        }
        public static void Summa(int begin, int end)
        {
            int result = 0;
            for (int i = begin; i < end; i++)
            {
                result += i;
            }
        }
        static async void SumAsync()
        {
            await Task.Run(() => Summa(1,5));
            await Task.Run(() => Summa(5, 10));
            await Task.Run(() => Summa(2, 5));
            await Task.Run(() => Summa(10, 18));
        }

    }
}
