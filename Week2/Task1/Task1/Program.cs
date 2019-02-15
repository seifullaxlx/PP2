using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        public static bool Palindrome(string s)
        {
            for(int i = 0; i < s.Length; ++i)
            {
                if(s[i] != s[s.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\Users\user\Desktop\palindrome.txt");
            string s = sr.ReadLine();
            sr.Close();
            if(Palindrome(s))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
