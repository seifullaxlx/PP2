using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class FarManager
    {
        public int cursor = 0;
        public string path;
        public int sz;
        public bool ok;
        DirectoryInfo directory = null;
        FileSystemInfo currentfs = null;

        public FarManager()
        {
            cursor = 0;
        }
        public FarManager(string path)
        {
            this.path = path;
            cursor = 0;
            directory = new DirectoryInfo(path);
            sz = directory.GetFileSystemInfos().Length;
            ok = true;
        }

        public void Color(FileSystemInfo fs, int index)
        {
            if (cursor == index)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Gray;
                currentfs = fs;
            }
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }
        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.WriteLine(" File Explorer: {0} ", path);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Open -- Enter | Delete -- Del | Rename -- R | Back -- Bakcspace | Exit -- Escape");
            directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            DirectoryInfo[] di = directory.GetDirectories();
            FileInfo[] fi = directory.GetFiles();
            for (int i = 0; i < di.Length; i++)
            {
                fs[i] = di[i];
            }
            for (int i = 0; i < fi.Length; i++)
            {
                fs[i + di.Length] = fi[i];
            }
            for (int i = 0, k = 0; i < fs.Length; i++)
            {
                if (ok == false && fs[i].Name[0] == '.')
                {
                    continue;
                }
                Color(fs[i], k);
                Console.Write(i + 1 + ". ");
                Console.WriteLine(fs[i].Name);
                k++;

            }
        }
        public void Up()
        {
            cursor--;
            if (cursor < 0)
                cursor = sz - 1;
        }
        public void Down()
        {
            cursor++;
            if (cursor == sz)
                cursor = 0;
        }
        public void CalcSz()
        {
            directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            sz = fs.Length;
            if (ok == false)
                for (int i = 0; i < fs.Length; i++)
                    if (fs[i].Name[0] == '.')
                        sz--;
        }

        public void Start()
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            while (consoleKey.Key != ConsoleKey.Escape)
            {
                CalcSz();
                Show();
                consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.UpArrow)
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    Down();
                if (consoleKey.Key == ConsoleKey.RightArrow)
                {
                    ok = false;
                    cursor = 0;
                }
                if (consoleKey.Key == ConsoleKey.LeftArrow)
                {
                    cursor = 0;
                    ok = true;
                }
                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    if (currentfs.GetType() == typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        path = currentfs.FullName;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Clear();
                        string path1 = currentfs.FullName;
                        string s1 = File.ReadAllText(path1);
                        Console.Write(s1);
                        Console.ReadKey();
                    }
                }
                if (consoleKey.Key == ConsoleKey.Backspace)
                {
                    cursor = 0;
                    path = directory.Parent.FullName;
                }
                if (consoleKey.Key == ConsoleKey.Delete)
                {
                    if (currentfs.GetType() == typeof(DirectoryInfo))
                    {
                        string path1 = currentfs.FullName;
                        Directory.Delete(path1, true);

                    }
                    else
                    {
                        string pathFile = currentfs.FullName;
                        File.Delete(pathFile);
                    }
                }
                if (consoleKey.Key == ConsoleKey.R)
                {
                    string path1 = directory.FullName;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.WriteLine("Please write new name, to rename {0}", currentfs.FullName);
                    string name = Console.ReadLine();

                    if (currentfs.GetType() == typeof(FileInfo))
                    {
                        string sourcefile = currentfs.FullName;
                        int ind = 0;
                        string formFile = null;
                        for (int i = 0; i < sourcefile.Length; i++)
                        {
                            if (sourcefile[i] == '.')
                            {
                                ind = i;
                                break;
                            }
                        }
                        for (int i = ind; i < sourcefile.Length; i++)
                        {
                            formFile += sourcefile[i];
                        }
                        string destfile = Path.Combine(path1, name + formFile);
                        File.Move(sourcefile, destfile);
                    }
                    else
                    if (currentfs.GetType() == typeof(DirectoryInfo))
                    {
                        string sourcedir = currentfs.FullName;
                        string destdir = Path.Combine(path1, name);
                        Directory.Move(sourcedir, destdir);
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Program Files";
            FarManager farmanager = new FarManager(path);
            farmanager.Start();
        }
    }
}