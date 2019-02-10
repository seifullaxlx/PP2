using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    { 
        public static void Palindrome()
        {
            StreamReader sr = new StreamReader(@"C:\Users\user\Desktop\input.txt");
            string s = sr.ReadLine();
            bool ch = true;
            for(int i = 0; i < s.Length; ++i)
            {
                if(s[i] != s[s.Length - 1 - i])
                {
                    ch = false;
                }
            }
            if (ch) Console.WriteLine("Yes");
            else Console.WriteLine("No");
            sr.Close();
        }
        static void Main(string[] args)
        {
            Palindrome();
        }
    }
}