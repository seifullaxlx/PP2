using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Student     //создаем класс студент
    {
        public string Name { get; set; }  //присваиваем и считываем значения свойств с помощью аксессоров
        public string Id { get; set; }
        public int Year { get; set; }
        
        public Student ( string Name, string Id) //создаем конструктор с двумя параметрами, принимающий значение имени и айди студента
        {
            this.Name = Name;
            this.Id = Id;
        }

        public void NextYear() //увеличиваем год обучения студента
        {
            Year++;
        }

       
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter your name: "); //принимаем имя, айди и год студента
            string name = Console.ReadLine();
            Console.WriteLine("Enter your id: ");
            string id = Console.ReadLine();
            Console.WriteLine("Enter your year of study: ");
            Student student1 = new Student(name, id)
            {
                Year = int.Parse(Console.ReadLine())
            };

            Console.WriteLine("Student: " + student1.Name); //выводим все данные
            Console.WriteLine("ID: " + student1.Id);
            Console.WriteLine("Year of sudy: " + student1.Year);
            student1.NextYear(); //увеличиваем год студента, вызывая функцию
            Console.WriteLine(); //выводим измененные данные
            Console.WriteLine("Student has progressed to the next year of study.");
            Console.WriteLine("Student: " + student1.Name);
            Console.WriteLine("ID: " + student1.Id);
            Console.WriteLine("Year of sudy: " + student1.Year);
        }
    }
}