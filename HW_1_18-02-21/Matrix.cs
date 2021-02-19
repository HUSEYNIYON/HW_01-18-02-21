using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HW_1_18_02_21
{

    class Matrix
    {
        Random rand;
        static object locker = new object();
        const string litters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public int Colunm { get; set; }
        public bool NeedSecond { get; set; }
        public Matrix(int col, bool needSecond)
        {
            Colunm = col;
            rand = new Random((int)DateTime.Now.Ticks);
            NeedSecond = needSecond;
        }
        char GetChar()
        {
            return litters.ToCharArray()[rand.Next(0, 35)];
        }
        public void Move()
        {
            int lenght;
            int count;
            while (true)
            {
                count = rand.Next(3, 12);
                lenght = 0;
                Thread.Sleep(rand.Next(20, 500));
                for (int i = 0; i < 42; i++)
                {
                    lock (locker)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.CursorTop = i - lenght;
                        for (int j = i - lenght - 1; j < i; j++)
                        {
                            Console.CursorLeft = Colunm;
                            Console.WriteLine(" ");
                        }
                        if (lenght < count)
                            lenght++;
                        else if (lenght == count)
                            count = 0;
                        if (NeedSecond && i < 20 && i > lenght + 2 && (rand.Next(1, 5) == 3))
                        {
                            new Thread((new Matrix(Colunm, false)).Move).Start();
                            NeedSecond = false;
                        }
                        if (41 - i < lenght)
                            lenght--;
                        Console.CursorTop = i - lenght + 1;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        for (int j = 0; j < lenght - 2; j++)
                        {
                            Console.CursorLeft = Colunm;
                            Console.WriteLine(GetChar());
                        }
                        if (lenght >= 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.CursorLeft = Colunm;
                            Console.WriteLine(GetChar());
                        }
                        if (lenght >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.CursorLeft = Colunm;
                            Console.WriteLine(GetChar());
                        }
                        Thread.Sleep(15);
                    }
                }
            }
        }
    }
}