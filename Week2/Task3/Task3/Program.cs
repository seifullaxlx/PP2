using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    { 
        static void Printspaces(int spaces)
        {
            for(int i = 0; i < spaces; ++i)
            {
                Console.Write(" ");
            }
        }

        static void Task(DirectoryInfo directory, int spaces)
        {
            FileInfo[] files = directory.GetFiles();
            DirectoryInfo[] directories = directory.GetDirectories();

            foreach(FileInfo file in files)
            {
                Printspaces(spaces);
                Console.WriteLine(file.Name);
            }

            foreach(DirectoryInfo d in directories)
            {
                Printspaces(spaces);
                Console.WriteLine(d.Name);
                Task(d, spaces + 1);
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\user\Desktop\lol");
            Task(d, 1);
        }
    }
}
