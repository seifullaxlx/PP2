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
        public static bool isPrime(int a)
        {
            if (a == 1) return false;
            for(int i = 2; i < a; ++i)
            {
                if(a % 2 == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void Prime()
        {
            StreamReader sr = new StreamReader(@"C:\Users\user\Desktop\input.txt");
            string[] arr = sr.ReadLine().Split();
            StreamWriter sw = new StreamWriter(@"C:\Users\user\Desktop\output.txt");
            int[] arr2 = new int[10000];
            for(int i = 0; i < arr.Length; ++i)
            {
                if (isPrime(int.Parse(arr[i])))
                {
                    sw.Write(int.Parse(arr[i]) + " ");
                }
            }
            sr.Close();
            sw.Close();
        }

        static void Main(string[] args)
        {
            Prime();
        }
    }
}
