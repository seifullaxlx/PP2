using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //считываем кол-во элементов в массиве 
            string a = Console.ReadLine(); //считываем элементы массива
            string[] arr = a.Split(); 
            for(int i = 0; i < n; ++i) //создаем форик, чтобы пробегаться по элементам массива
            {
                for(int j = 0; j < 2; ++j) //еще один форик, для вывода элементов по два раза 
                {
                    Console.Write(arr[i] + " "); //выведение элементов массива
                }
            }
        }
    }
}
