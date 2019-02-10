using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // считываем кол-во элементов в "массиве"
            for(int i = 0; i < n; ++i) // из-за того, что наш "массив" двумерный, мы создаем форик в форике 
            {
                int cnt = 0; //создаем счетчик для того, чтобы определять кол-во звездочек в строке 
                for(int j = 0; j < n; ++j)
                {
                    Console.Write("[*]");
                    cnt++;
                    if (cnt == i + 1) break; //если кол-во звездочек совпадает с нумерацией строки, то выходим со второго форика 
                }
                Console.Write(System.Environment.NewLine); //новая строка
            }
        }
    }
}
