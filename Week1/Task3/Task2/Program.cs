using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; ++i)
            {
                int cnt = 0;
                for(int j = 0; j < n; ++j)
                {
                    Console.Write("[*]");
                    cnt++;
                    if (cnt == i + 1) break;
                }
                Console.Write(System.Environment.NewLine);
            }
        }
    }
}
