using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HW_1_18_02_21
{
    
    class Matrix
    {
        public void GetDarkGreen() => Console.ForegroundColor = ConsoleColor.DarkGreen;
        public void GetGreen() => Console.ForegroundColor = ConsoleColor.Green;
        public void GetWhite() => Console.ForegroundColor = ConsoleColor.White;

        Random rng;
        static object locker = new object();
        const string symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public int column { get; set; }
        public bool second { get; set; }
        public Matrix(int column, bool second)
        {
            this.column = column;
            rng = new Random((int)DateTime.Now.Ticks);
            this.second = second;
        }
        char getSymbols()
        {
            return symbols.ToCharArray()[rng.Next(0, 35)];
        }
        public void Running()
        {
            int count;
            int length;
            while (true)
            {
                 count = rng.Next(3, 10);
                 length = 0;
                Thread.Sleep(rng.Next(20, 5000));
                for (int i = 0; i < 42; i++)
                {
                    lock (locker)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.CursorTop = i - length;
                        for (int j = i - length - 1; j < i; j++)
                        {
                            Console.CursorLeft = column;
                            Console.WriteLine(" ");
                        }
                        if (length < count) length++;
                        else if (length == count) count = 0;
                        if (second && i < 20 && i > length + 2 && (rng.Next(1, 5) == 3))
                        {
                            new Thread((new Matrix(column, false)).Running).Start(); second = false;
                        }
                        if (41 - i < length) length--;
                        Console.CursorTop = i - length + 1;
                        GetDarkGreen();
                        for (int j = 0; j < length - 2; j++)
                        {
                            Console.CursorLeft = column;
                            Console.WriteLine(getSymbols());
                        }
                        if (length >= 2)
                        {
                            GetGreen();
                            Console.CursorLeft = column;
                            Console.WriteLine(getSymbols());
                        }
                        else if (length >= 1)
                        {
                            GetWhite();
                            Console.CursorLeft = column;
                            Console.WriteLine(getSymbols());
                        }
                        Thread.Sleep(10);
                    }
                }
            }
        }
    }
}
