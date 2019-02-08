using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static bool Prime(int a) // создаем функцию, чтобы определить, число простое или нет
        {
            bool check = true;
            if (a == 1)
            {
                check = false;
            }
            for(int i = 2; i < a; ++i)
            {
                if(a % i == 0)
                {
                    check = false;
                }
            }
            return check;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // задаю количество элементов в массиве
            int[] arr = new int[n]; // создаю сам массив
            
            for(int i = 1; i <= n; ++i) // заполняю массив
            {
                arr[i - 1] = i;
            }

            int cnt = 0; // создаю счетчик для подсчета простых чисел
            int[] arr2 = new int[n]; // создаю второй массив для заполнения его простыми числами из первого массива

            for(int i = 0; i < n; ++i) //пробегаюсь по первому массиву определяя из него простые числа и закидываю их во второй массив
            {
                if (Prime(arr[i]) == true)
                {
                    arr2[cnt] = arr[i];
                    cnt++;
                }
            }

            Console.Write(cnt); // первая строка вывода - количество простых элементов в массиве
            Console.Write(System.Environment.NewLine); // новая строка

            for(int i = 0; i < cnt; ++i) // вывожу простые числа через пробел
            {
                Console.Write(arr2[i]);
                Console.Write(" ");
            }
        }
    }
}
