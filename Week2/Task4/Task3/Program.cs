using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task
{
    class Program
    {
        class FarManager
        {
            public int cursor;
            public string path;
            public int sz;
            public FileSystemInfo currentfs = null;
            public DirectoryInfo dir = null;
            public FarManager()
            {
                cursor = 0;
            }
            public FarManager(string path)
            {
                this.path = path;
                cursor = 0;
                dir = new DirectoryInfo(path);
                sz = dir.GetFileSystemInfos().Length;//size of a directory(number of directories+ files in it)
            }
            public void Color(FileSystemInfo f, int index)
            {
                if (cursor == index)//to highlight the directory or file,which cursor shows
                {
                    currentfs = f;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (f.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;//if it is directory we paint to green
                }
                else
                    Console.ForegroundColor = ConsoleColor.Yellow;//otherwise to yellow
            }
            public void Show()
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                dir = new DirectoryInfo(path);
                int ind = 1;
                FileSystemInfo[] fs = dir.GetFileSystemInfos();//we add to array all filesysteminfos(directories and files) from given directory
                for (int i = 0; i < fs.Length; i++)
                {
                    Color(fs[i], i);//we try to color each element of the array
                    Console.WriteLine(ind + "." + " " + fs[i]);
                    ind++;
                }
            }
            public void Up()//the function to go up of the list
            {
                cursor--;
                if (cursor < 0)//when we want to go above the first element,it should go to the last element
                {
                    cursor = sz - 1;
                }
            }
            public void Down()//when we want to go under of the last element,it should go to the first
            {
                cursor++;
                if (cursor == sz)
                {
                    cursor = 0;
                }
            }
            public void Start()
            {
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                while (keyinfo.Key != ConsoleKey.Escape)//when I press "Escape" program stops working
                {
                    Show();
                    keyinfo = Console.ReadKey();
                    if (keyinfo.Key == ConsoleKey.UpArrow)
                    {
                        Up();
                    }
                    else if (keyinfo.Key == ConsoleKey.DownArrow)
                    {
                        Down();
                    }
                    if (keyinfo.Key == ConsoleKey.Enter)//I choose the element of an array then press "Enter"
                    {
                        if (currentfs.GetType() == typeof(DirectoryInfo))
                        {//If it is directory,it will return the pass,which includes this directory to,
                         //it means that we go into the directory
                            cursor = 0;
                            path = currentfs.FullName;
                        }
                        if (currentfs.GetType() == typeof(FileInfo))//if it is file,then we open it in the console(textfiles)
                        {
                            cursor = 0;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Black;
                            using (StreamReader sr = new StreamReader(currentfs.FullName))//we read the context of a file
                            {
                                Console.WriteLine(sr.ReadToEnd());//we print with the function ReadtoEnd
                            }
                            Console.ReadKey();
                        }
                    }
                    if (keyinfo.Key == ConsoleKey.Delete)//here we try to delete elements of an array using "delete" button
                    {
                        cursor = 0;
                        if (currentfs.GetType() == typeof(DirectoryInfo))
                        {

                            if (new DirectoryInfo(currentfs.FullName).GetFileSystemInfos().Length == 0)//if it is directory,which is empty then no problem it will be deleted
                            {
                                Directory.Delete(currentfs.FullName);
                            }
                            else//but if this directory has files or subdirectories,we should ask if they sure 
                            {
                                Console.Clear();
                                Console.WriteLine("Are you sure?");
                                if (Console.ReadKey().Key == ConsoleKey.Y)//if yes,then delete
                                {
                                    Directory.Delete(currentfs.FullName, true);
                                }



                            }
                        }

                        else if (currentfs.GetType() == typeof(FileInfo))//deleting files
                        {
                            File.Delete(currentfs.FullName);
                        }
                    }

                    if (keyinfo.Key == ConsoleKey.I)//by pressing "I" we try to rename the given file or directory
                    {
                        cursor = 0;
                        if (currentfs.GetType() == typeof(DirectoryInfo))
                        {
                            Console.Clear();
                            string s = Console.ReadLine();//we write the name,which we want to change
                            string Name = currentfs.Name;//just simple name of a directory
                            string fName = currentfs.FullName;//location of a directory
                            string newpath = "";
                            for (int i = 0; i < fName.Length - Name.Length; i++)
                            {
                                newpath += fName[i];//the path,which keeps the location of a directory
                            }
                            newpath = newpath + s;
                            Directory.Move(fName, newpath);//changes the name
                        }
                        else
                        {
                            Console.Clear();
                            string s = Console.ReadLine();
                            string Name = currentfs.Name;
                            string fName = currentfs.FullName;
                            string newpath = "";
                            for (int i = 0; i < fName.Length - Name.Length; i++)
                            {
                                newpath += fName[i];
                            }
                            newpath = newpath + s;
                            File.Move(fName, newpath);
                        }

                    }
                    if (keyinfo.Key == ConsoleKey.Backspace)//by pressing "Backspace" I return to the last folder
                    {
                        cursor = 0;
                        path = dir.Parent.FullName;
                    }

                }
            }

            static void Main(string[] args)
            {
                string path = @"C:\Program Files";
                FarManager fr = new FarManager(path);
                fr.Start();
            }
        }
    }
}