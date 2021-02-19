using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HW_1_18_02_21
{
    class Matrix
    {
        Random rng = new Random();
        string symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public int column { get; set; }
        public bool second { get; set; }
        public Matrix(int column, bool second)
        {
            this.column = column;
            this.second = second;
        }
        private char getSymbols()
        {
            return symbols.ToCharArray()[rng.Next(0, 26)];
        }
        public void Running()
        {
            while (true)
            {
                int count = rng.Next(3, 12);
                int length = 0;
                Thread.Sleep(rng.Next(20, 500));
                for (int i = 0; i < 40; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.CursorTop = i - length;
                    for (int j = i-length-1; j < i; j++)
                    {
                        Console.CursorLeft = column;
                        Console.WriteLine(" ");
                    }
                    if (length < count) length++;
                    else if (length == count) count = 0;
                    if (second == true && i < 20 && i > length + 2 && (rng.Next(1, 5) == 3))
                    {
                        new Thread((new Matrix(column, false)).Running).Start(); second = false;
                    }
                    
                }
            }
        }
    }
}
