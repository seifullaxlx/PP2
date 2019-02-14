using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        static bool IsPrime(int x)
        {
            if (x == 1) return false;
            for(int i = 2; i <= Math.Sqrt(x); ++i)
            {
                if(x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\Users\user\Desktop\lol\input.txt");
            string[] s = sr.ReadToEnd().Split();
            sr.Close();
            StreamWriter sw = new StreamWriter(@"C:\Users\user\Desktop\lol\output.txt");
            foreach(string a in s)
            {
                int b = int.Parse(a);
                if (IsPrime(b))
                {
                    sw.Write(b + " ");
                }
            }
            sw.Close();
        }
    }
}
