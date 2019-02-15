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
        public int highlight = 0;
        public string path;
        public int size;
        public bool ok;
        DirectoryInfo directory = null;
        FileSystemInfo currentfs = null;

        public FarManager()
        {
            highlight = 0;
        }
        public FarManager(string path)
        {
            this.path = path;
            highlight = 0;
            directory = new DirectoryInfo(path);
            size = directory.GetFileSystemInfos().Length;
            ok = true;
        }

        public void Color(FileSystemInfo fs, int index)
        {
            if (highlight == index)
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Gray;
                currentfs = fs;
            }
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
        }
        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
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
            highlight--;
            if (highlight < 0)
                highlight = size - 1;
        }
        public void Down()
        {
            highlight++;
            if (highlight == size)
                highlight = 0;
        }

        public void Start()
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            while (consoleKey.Key != ConsoleKey.Escape)
            {
                Show();
                consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.UpArrow)
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    Down();
                if (consoleKey.Key == ConsoleKey.RightArrow)
                {
                    ok = false;
                    highlight = 0;
                }
                if (consoleKey.Key == ConsoleKey.LeftArrow)
                {
                    highlight = 0;
                    ok = true;
                }
                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    if (currentfs.GetType() == typeof(DirectoryInfo))
                    {
                        highlight = 0;
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
                    highlight = 0;
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